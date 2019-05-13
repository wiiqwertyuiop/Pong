using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public class Connection
    {

        private dynamic _connection;
        public byte[] DataBuffer = null;

        private int HandShake_count = 2;

        public bool Host = true;

        public Connection(int port)
        {
            _connection = new Host(port);
        }

        public Connection(string ip, int port)
        {
            _connection = new Client(ip, port);
            HandShake_count--;
            DataBuffer = new byte[] { 0x24 };
            Host = false;
        }

        // Client:
        //   Check if anything was sent to us, if so try to validate first if able(?), update our data
        //   send data (if we have anything)
        //
        // Host:
        //    Check if anything was sent to us, update our data
        //    send data (if we have anything)

        public bool Initalize(byte[] outgoing)
        {
            byte[] DataRecieved = _connection.Listen(); // Check if anything was sent to us
            if (DataRecieved != null)
            {
                if (DataBuffer == null)
                {
                    DataBuffer = outgoing;
                }
                else if (!Host && DataBuffer.Length == 1 && DataRecieved.Length == outgoing.Length)
                {
                    DataBuffer = DataRecieved;
                }
                else if (Enumerable.SequenceEqual(DataRecieved, DataBuffer))
                {
                    HandShake_count--;
                }
                else return false;
            }

            // If we shook hands the correct amount of times we are OK
            if (HandShake_count == 0)
            {
                if (!Host) _connection.Send(DataBuffer);
                return true;
            }

            // If we have something to send, send it
            if (DataBuffer != null) _connection.Send(DataBuffer);
            
            return false;

        }

        // packet data: [count number] [data]
        // always listen and always send most updated info
        // info listen que > 5 too laggy
        // otherwise choose most recent packet and discard other ones

        public bool Update(byte[] outgoing)
        {
            // Always send most recent 
            if (outgoing != null) _connection.Send(outgoing);

            // Get the number of packets in the que
            int que = _connection.Que();
            //if ((que > 39 * 7)) return false;
            // NOTE: 39 is the correct data size we should be receiving
            if (que == 0 || que < 39) return false; // if there are none or too many (lag) skip

            byte MostRecentPck = 0;

            // Loop through que
            while (que != 0)
            {
                byte[] DataReceived = _connection.Listen();
                if (DataReceived == null) return false;

                if (DataReceived[0] >= MostRecentPck)
                {
                    MostRecentPck = DataReceived[0];
                    DataBuffer = DataReceived;
                }
                que -= 39;
            }

            return true;
        }

        public void Close()
        {
            _connection.Close();
            _connection = null;
        }
    }
}
