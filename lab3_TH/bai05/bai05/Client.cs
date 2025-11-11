using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading;

namespace bai05
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        TcpClient tcpclnt = new TcpClient();
        NetworkStream stm;
        StreamWriter writer;
        StreamReader reader;
        Thread recvThread;

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
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

                recvThread = new Thread(ReceiveLoop);
                recvThread.Start();

                MessageBox.Show("Kết nối thành công với server");
            }
            catch (Exception)
            {
            }
        }

        void ReceiveLoop()
        {
            try
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("RANDOM|"))
                    {
                        string value = line.Substring(7);
                        this.BeginInvoke(new Action(() =>
                        {
                            tb_random.Text = value;

                        }));
                    }
                }
            }
            catch { }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (tb.Text == "")
            {
                MessageBox.Show("Nhập tên món ăn");
                return;
            }
            if (!tcpclnt.Connected)
            {
                MessageBox.Show("Chưa kết nối với server");
                return;
            }
            var line = tb.Text.Trim();
            writer.WriteLine(line);
            tb.Clear();
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            tcpclnt.Close();
            MessageBox.Show("Đã ngắt kết nối với server");
        }

        private void btn_random_Click(object sender, EventArgs e)
        {
            if (!tcpclnt.Connected || writer == null)
            {
                MessageBox.Show("Chưa kết nối với server");
                return;
            }
            try
            {
                writer.WriteLine("RANDOM");
            }
            catch
            {
                MessageBox.Show("Gửi RANDOM thất bại.");
            }

        }
    }
}
