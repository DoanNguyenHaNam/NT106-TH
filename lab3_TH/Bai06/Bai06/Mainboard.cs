namespace Bai06
{
    public partial class Mainboard : Form
    {
        public Mainboard()
        {
            InitializeComponent();
        }

        private void btn_server_Click(object sender, EventArgs e)
        {
            Server server = new Server();
            server.Show();
        }

        private void btn_client_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Show();
        }
    }
}
