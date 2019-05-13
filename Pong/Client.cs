using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Pong
{
    class Client
    {
        private UdpClient _me;
        private IPEndPoint _host;

        public Client(string hostIP, int port)
        {
            _me = new UdpClient(hostIP, port);
        }

        public int Que() { return _me.Available; }

        public byte[] Listen()
        {
            try
            {
                if (_me.Available < 1) return null;

                _host = new IPEndPoint(IPAddress.Any, 0);
                byte[] receive_byte_array = _me.Receive(ref _host);
                //Console.WriteLine("\n\nHost has sent:\n\n\n" + receive_byte_array[0]);

                return receive_byte_array;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nError:\n" + e.Message);
                return null;
            }

        }

        public void Send(byte[] Data)
        {
            try
            {
                _me.Send(Data, Data.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nError:\n" + e.Message);
            }
        }

        public void Close()
        {
            _me.Close();
        }

        ~Client()
        {
            _me.Close();
        }
    }
}
