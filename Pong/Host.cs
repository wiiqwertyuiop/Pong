using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Pong
{
    class Host
    {
        UdpClient _client;
        IPEndPoint _clientAddr = null;

        public Host(int port)
        {
            _client = new UdpClient(port, AddressFamily.InterNetwork);
        }

        public int Que() { return _client.Available; }

        public byte[] Listen()
        {
            try
            {
                if (_client.Available < 1) return null;
                if (_clientAddr == null) _clientAddr = new IPEndPoint(IPAddress.Any, 0);
                return _client.Receive(ref _clientAddr);
            }
            catch (Exception e)
            {
                Console.WriteLine(" Exception {0}", e.Message);
                return null;
            }
        }

        public void Send(byte[] Data)
        {
            try
            {
                _client.Send(Data, Data.Length, _clientAddr);
                Console.WriteLine("\nSent.\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(" Exception {0}", e.Message);
            }
        }

        public void Close()
        {
            _client.Close();
        }

        ~Host()
        {
            _client.Close();
        }
    }
}
