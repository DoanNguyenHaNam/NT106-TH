using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai01
{
    public partial class Server : Form
    {
        private static Server instance;

        public Server()
        {
            InitializeComponent();
            instance = this;
        }

        private void btn_listen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_port.Text))
            {
                MessageBox.Show("Please fill in the port field.");
                return;
            }
            if (!int.TryParse(tb_port.Text, out int port))
            {
                MessageBox.Show("Please enter a valid port number.");
                return;
            }
            if (port < 1024 || port > 49151)
            {
                MessageBox.Show("Port number must be between 1024 and 49151.");
                return;
            }
            SocketServer server = new SocketServer(port);
            btn_listen.Enabled = false;
        }
        public static void CallUpdateRTB(string message)
        {
            instance?.UpdateRTB(message);
        }
        public void UpdateRTB(string message)
        {
            if (rtb.InvokeRequired)
            {
                rtb.Invoke(new Action(() => rtb.AppendText(message + Environment.NewLine)));
            }
            else
            {
                rtb.AppendText(message + Environment.NewLine);
            }
        }
        private void rtb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}