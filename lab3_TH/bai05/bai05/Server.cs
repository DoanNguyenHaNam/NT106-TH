using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Data;
using Microsoft.Data.SqlClient;

namespace bai05
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }
        Socket[] socket = new Socket[100];
        Random rnd = new Random();
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FoodDB;Integrated Security=True;TrustServerCertificate=True";

        private void button1_Click(object sender, EventArgs e)
        {
            Thread serverThread = new Thread(new ThreadStart(ListenTCP));
            serverThread.Start();
            button1.Enabled = false;
        }
        void ListenTCP()
        {
            try
            {
                IPAddress ipAd = IPAddress.Parse("127.0.0.1");
                TcpListener server = new TcpListener(ipAd, 8080);
                server.Start();

                int count = 0;
                while (true)
                {
                    Socket s = server.AcceptSocket();

                    if (count >= 100)
                    {
                        try { s.Close(); } catch { }
                        continue;
                    }

                    socket[count] = s;

                    Thread listenClientThread = new Thread(RunListenClient);
                    listenClientThread.IsBackground = true;
                    listenClientThread.Start(s);

                    count++;
                }
                server.Stop();
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
                        if (string.Equals(line, "RANDOM", StringComparison.OrdinalIgnoreCase))
                        {
                            string pick = PickRandomFromRtb();
                            SendLine(s, "RANDOM|" + pick);
                            continue;
                        }
                        SaveFoodToDb(line);
                        rtb_food.AppendText(line + Environment.NewLine);
                    }
                }
            }
            catch
            {
            }
        }

        string PickRandomFromRtb()
        {
            string[] lines;
            if (rtb_food.InvokeRequired)
                lines = (string[])rtb_food.Invoke(new Func<string[]>(() => rtb_food.Lines));
            else
                lines = rtb_food.Lines;

            var nonEmpty = lines.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            if (nonEmpty.Length == 0) return "EMPTY";
            return nonEmpty[rnd.Next(nonEmpty.Length)].Trim();
        }

        void SendLine(Socket s, string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text + "\n");
            try { s.Send(data); } catch { }
        }


        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        int GetNextId()
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT ISNULL(MAX(id), 0) + 1 FROM dbo.Table_1";
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        void SaveFoodToDb(string foodName)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "INSERT INTO dbo.Table_1(FoodName) VALUES (@name)";
                cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = foodName });
                cmd.ExecuteNonQuery();
            }
        }

        void LoadFoodsToRtb()
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT FoodName FROM dbo.Table_1 ORDER BY id ASC";
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        string name = rdr.GetString(0);
                        rtb_food.AppendText(name + Environment.NewLine);
                    }
                }
            }
        }

        private void Server_Load(object sender, EventArgs e)
        {
            try { LoadFoodsToRtb(); }
            catch (Exception ex) { MessageBox.Show("Load DB lỗi: " + ex.Message); }
        }
    }
}
