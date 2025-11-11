namespace bai01
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btn_client_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Show();
        }

        private void btn_server_Click(object sender, EventArgs e)
        {
            Server server = new Server();
            server.Show();
        }
    }
}
