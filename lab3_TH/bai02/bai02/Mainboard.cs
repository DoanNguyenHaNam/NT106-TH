using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace bai02
{
    public partial class Mainboard : Form
    {
        public Mainboard()
        {
            InitializeComponent();
        }

        private void btn_listen_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        void StartUnsafeThread()
        {
            int bytesReceived = 0;
            byte[] recv = new byte[1];

            Socket clientSocket;

            Socket listenerSocket = new Socket(
                 AddressFamily.InterNetwork,
                 SocketType.Stream,
                 ProtocolType.Tcp
             );

            IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            listenerSocket.Bind(ipepServer);

            listenerSocket.Listen(10);

            clientSocket = listenerSocket.Accept();

            listViewCommand.Items.Add(new ListViewItem("New client connected"));

            while (clientSocket.Connected)
            {
                string text = "";
                do
                {
                    bytesReceived = clientSocket.Receive(recv);
                    if (bytesReceived <= 0) break;

                    text += Encoding.ASCII.GetString(recv, 0, bytesReceived);
                }
                while (text.Length == 0 || (text[^1] != '\n' && text[^1] != '\r'));

                text = text.TrimEnd('\r', '\n');
                if (text.Length > 0)
                    listViewCommand.Items.Add(new ListViewItem(text));
            }

            listenerSocket.Close();
        }

        private void listViewCommand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
