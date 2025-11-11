using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Bai06
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }
        Socket[] socket = new Socket[100];
        object locker = new object();
        int clientCount = 0;

        private void btn_listen_Click(object sender, EventArgs e)
        {
            Thread listenThread = new Thread(StartListening);
            listenThread.Start();
            btn_listen.Enabled = false;
        }
        void StartListening()
        {
            try
            {
                IPAddress ipAd = IPAddress.Parse("127.0.0.1");
                TcpListener server = new TcpListener(ipAd, 8080);
                server.Start();

                while (true)
                {
                    Socket s = server.AcceptSocket();

                    if (clientCount >= 100)
                    {
                        try { s.Close(); } catch { }
                        continue;
                    }

                    socket[clientCount] = s;

                    Thread listenClientThread = new Thread(RunListenClient);
                    listenClientThread.IsBackground = true;
                    listenClientThread.Start(s);

                    clientCount++;
                }
            }
            catch (Exception)
            {
            }
        }
        void RunListenClient(object obj)
        {
            Socket s = (Socket)obj;
            try
            {
                using (NetworkStream ns = new NetworkStream(s))
                using (StreamReader reader = new StreamReader(ns, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Trim();
                        if (line.Length == 0) continue;
                        richTextBox1.AppendText(line + Environment.NewLine);
                        Broadcast(line);
                    }
                }
            }
            catch
            {
            }
        }
        void Broadcast(string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text + "\n");
            lock (locker)
            {
                for (int i = 0; i < clientCount; i++)
                {
                    var c = socket[i];
                    if (c == null || !c.Connected) continue;
                    try { c.Send(data); } catch { }
                }
            }
        }
    }
}
