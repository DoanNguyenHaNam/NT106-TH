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
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_ip.Text) || string.IsNullOrEmpty(tb_port.Text) || string.IsNullOrEmpty(tb_mess.Text))
            {
                MessageBox.Show("Please fill in all fields.");
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
            if (tb_ip.Text.Split('.').Length != 4)
            {
                MessageBox.Show("Please enter a valid IP address.");
                return;
            }
            SocketClient client = new SocketClient(tb_ip.Text, port, tb_mess.Text);
            MessageBox.Show("Message sent successfully!");
            tb_mess.Clear();
        }

        private void tb_mess_TextChanged(object sender, EventArgs e)
        {

        }
    }
}