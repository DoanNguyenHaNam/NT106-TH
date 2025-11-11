using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace bai03
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        TcpClient tcpClient;
        NetworkStream ns;
        private void btn_connect_Click(object sender, EventArgs e)
        {
            tcpClient = new TcpClient();
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8080);
            tcpClient.Connect(ipEndPoint);
            ns = tcpClient.GetStream();
            MessageBox.Show("Connected to the server");
            btn_connect.Enabled = false;
            btn_disconnect.Enabled = true;
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb.Text))
            {
                MessageBox.Show("Please enter a command to send");
                return;
            }
            if (tcpClient == null || !tcpClient.Connected)
            {
                MessageBox.Show("Not connected to the server");
                return;
            }
            if (ns == null)
            {
                MessageBox.Show("Network stream is not available");
                return;
            }
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(tb.Text + "\n");
            ns.Write(data, 0, data.Length);
            tb.Clear();
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes("Out\n");
            ns.Write(data, 0, data.Length);
            ns.Close();
            tcpClient.Close();
            btn_disconnect.Enabled = false;
            btn_connect.Enabled = true;
        }
    }
}
