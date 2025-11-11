using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace bai01
{
    internal class SocketClient
    {
        public SocketClient(string IP, int port, string text)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //UdpClient client = new UdpClient(port);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);
            byte[] send_buffer = Encoding.UTF8.GetBytes(text);
            socket.SendTo(send_buffer, ep);
            socket.Close();
            //Byte[] buffer = new byte[1024];
            //socket.Receive(buffer);
            //String data = Encoding.ASCII.GetString(buffer);
        }
    }
}
