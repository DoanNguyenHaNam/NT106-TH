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

namespace Bai06
{
    public partial class Client : Form
    {
        private static int _clientCounter = 0;
        public string ClientId { get; private set; }
        TcpClient tcpclnt;
        NetworkStream stm;
        StreamWriter writer;
        StreamReader reader;
        Thread clientThread;
        Thread receiveThread;

        public Client()
        {
            InitializeComponent();
            _clientCounter++;
            ClientId = $"DoanNguyenHaNam_{_clientCounter}";
            this.Text = ClientId;
            label1.Text = "Tài Khoản: " + ClientId;

            Thread clientThread = new Thread(new ThreadStart(ConnectTCP));
            clientThread.Start();

        }
        void ConnectTCP()
        {
            try
            {
                tcpclnt = new TcpClient();
                tcpclnt.Connect("127.0.0.1", 8080);
                stm = tcpclnt.GetStream();
                writer = new StreamWriter(stm, new UTF8Encoding(false)) { AutoFlush = true };
                reader = new StreamReader(stm, new UTF8Encoding(false));

                MessageBox.Show("Kết nối thành công với server");

                receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception)
            {
            }
        }
        void ReceiveMessages()
        {
            try
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        rtb_chat.AppendText(line + Environment.NewLine);
                    });
                }
            }
            catch
            {
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tb_mess.Text))
                {
                    MessageBox.Show("Vui lòng nhập tin nhắn!");
                    return;
                }

                if (writer != null)
                {
                    string message = $"{ClientId}: {tb_mess.Text}";
                    writer.WriteLine(message);
                    tb_mess.Clear();
                    tb_mess.Focus();
                }
                else
                {
                    MessageBox.Show("Chưa kết nối đến server!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi tin nhắn: {ex.Message}");
            }
        }
    }
}