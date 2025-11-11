namespace bai05
{
    public partial class Mainboard : Form
    {
        public Mainboard()
        {
            InitializeComponent();
        }

        private void btn_server_Click(object sender, EventArgs e)
        {
            Server serverForm = new Server();
            serverForm.Show();
        }

        private void btn_client_Click(object sender, EventArgs e)
        {
            Client clientForm = new Client();
            clientForm.Show();
        }
    }
}
