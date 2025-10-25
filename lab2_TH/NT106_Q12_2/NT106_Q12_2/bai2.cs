using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT106_Q12_2
{
    public partial class bai2 : Form
    {
        public bai2()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();                                               //mở hộp thoại (chủ yếu để lấy tên file vì hàm lấy tên
                                                                            //file cần được mở hộp thoại nếu không thì vẫn là rỗng)
            tb_filename.Text = Path.GetFileName(ofd.FileName);
            FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
            tb_url.Text = fs.Name.ToString();                               //ofd.FileName
            StreamReader sr = new StreamReader(fs);
            tb_size.Text = $"{fs.Length} bytes";     
            int lineCount = 0;
            string text = "";
            while (!sr.EndOfStream)
            {
                text += sr.ReadLine() + "\n";
                lineCount++;
            }
            tb_linecount.Text = lineCount.ToString();
            int wordCount = Regex.Matches(text, @"[\p{L}\p{N}]+").Count;    //@"[\p{L}\p{N}]+" \p{L} là chữ cái, \p{N} là chữ số
                                                                            //+ là 1 hoặc nhiều kí tự liền nhau
                                                                            // này là đếm các cụm từ chứ ko liên quan đến có phải là từ có nghĩa ko
            tb_wordcount.Text = wordCount.ToString();
            tb_charactercount.Text = text.Length.ToString();
            rtb.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
