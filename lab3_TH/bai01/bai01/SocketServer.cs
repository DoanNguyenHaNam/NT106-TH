using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace bai01
{
    internal class SocketServer
    {
        public SocketServer(int port)
        {
            Task.Run(() =>
            {
                UdpClient server = new UdpClient(port);
                IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, port);
                string received_data;
                byte[] receive_byte_array;

                while (true)
                {
                    receive_byte_array = server.Receive(ref groupEP);
                    received_data = Encoding.UTF8.GetString(receive_byte_array, 0, receive_byte_array.Length);
                    Server.CallUpdateRTB($"[{groupEP.Address}:{groupEP.Port}] {received_data}");
                }
            });
        }
    }
}