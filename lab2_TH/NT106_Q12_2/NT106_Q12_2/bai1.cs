using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NT106_Q12_2
{
    public partial class bai1 : Form
    {
        public bai1()
        {
            InitializeComponent();
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void bai1_Load(object sender, EventArgs e)
        {

        }

        private string output = "";

        private void btn_read_Click(object sender, EventArgs e)
        {
            if (!File.Exists("C:\\Users\\NAM\\Desktop\\NT106\\lab2_TH\\NT106_Q12_2\\NT106_Q12_2\\bai1\\input1.txt"))
            {
                MessageBox.Show("File không tồn tại");
                return;
            }
            FileStream fs = new FileStream("C:\\Users\\NAM\\Desktop\\NT106\\lab2_TH\\NT106_Q12_2\\NT106_Q12_2\\bai1\\input1.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string text = sr.ReadToEnd();
            MessageBox.Show(text);
            rTB.Clear();
            rTB.AppendText("\n");
            rTB.AppendText(text);
            output = text;
            sr.Dispose();
        }

        private void btn_write_Click(object sender, EventArgs e)
        {
            if (!Path.IsPathRooted("C:\\Users\\NAM\\Desktop\\NT106\\lab2_TH\\NT106_Q12_2\\NT106_Q12_2\\bai1\\output1.txt"))
            {
                MessageBox.Show("Đường dẫn không hợp lệ");
                return;
            }
            string ouput_file = output.ToUpper();
            FileStream fs = new FileStream("C:\\Users\\NAM\\Desktop\\NT106\\lab2_TH\\NT106_Q12_2\\NT106_Q12_2\\bai1\\output1.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(ouput_file);
            MessageBox.Show("Ghi file thành công");
            sw.Dispose();
        }

        private void rTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
