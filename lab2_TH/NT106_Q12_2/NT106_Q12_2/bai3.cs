using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT106_Q12_2
{
    public partial class bai3 : Form
    {
        public bai3()
        {
            InitializeComponent();
        }

        //static double calculateNormal(string a)
        //{
        //    string[] calcul = a.Split(' ');
        //    double output = 0;
        //    for (int i=0;i<calcul.Length; i++)
        //    {
        //        if (calcul[i] == "+" && i > 1)
        //        {
        //            double temp = Convert.ToDouble(calcul[i - 1]) + Convert.ToDouble(calcul[i + 1]);
        //            calcul[i-1] = temp.ToString();
        //            calcul[i] = "0";
        //            calcul[i+1] = "0";
        //        }
        //        else if (calcul[i] == "-" && i > 1)
        //        {
        //            double temp = Convert.ToDouble(calcul[i - 1]) - Convert.ToDouble(calcul[i + 1]);
        //            calcul[i - 1] = temp.ToString();
        //            calcul[i] = "0";
        //            calcul[i + 1] = "0";
        //        }
        //        else if (calcul[i] == "*" && i > 1)
        //        {
        //            double temp = Convert.ToDouble(calcul[i - 1]) * Convert.ToDouble(calcul[i + 1]);
        //            calcul[i - 1] = temp.ToString();
        //            calcul[i] = "0";
        //            calcul[i + 1] = "0";
        //        }
        //        else if (calcul[i] == "/" && i > 1)
        //        {
        //            double temp = Convert.ToDouble(calcul[i - 1]) / Convert.ToDouble(calcul[i + 1]);
        //            calcul[i - 1] = temp.ToString();
        //            calcul[i] = "0";
        //            calcul[i + 1] = "0";
        //        }
        //    }
        //    foreach (string s in calcul)
        //    {
        //        if (s != "0")
        //        {
        //            output += Convert.ToDouble(s);
        //        }
        //    }
        //    return output;
        //}

        private string outputTxt = "";

        static double calculateNormal(string a)
        {
            if (string.IsNullOrWhiteSpace(a)) return 0;

            var tokens = new List<string>(a.Split(' ', StringSplitOptions.RemoveEmptyEntries));

            var reduced = new List<string>();
            reduced.Add(tokens[0]);

            for (int i = 1; i < tokens.Count; i += 2)
            {
                string op = tokens[i];
                string nextNum = tokens[i + 1];

                if (op == "*" || op == "/")
                {
                    double left = double.Parse(reduced[^1]);
                    double right = double.Parse(nextNum);

                    double val = op == "*"
                        ? left * right
                        : (right == 0 ? throw new DivideByZeroException("Chia cho 0.") : left / right);

                    reduced[^1] = val.ToString();
                }
                else
                {
                    reduced.Add(op);
                    reduced.Add(nextNum);
                }
            }

            double result = double.Parse(reduced[0]);
            for (int i = 1; i < reduced.Count; i += 2)
            {
                string op = reduced[i];
                double val = double.Parse(reduced[i + 1]);
                result = (op == "+") ? result + val : result - val;
            }

            return result;
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            if (!File.Exists("C:\\Users\\NAM\\Desktop\\NT106\\lab2_TH\\NT106_Q12_2\\NT106_Q12_2\\bai3\\input3.txt"))
            {
                MessageBox.Show("File không tồn tại");
                return;
            }
            FileStream fs = new FileStream("C:\\Users\\NAM\\Desktop\\NT106\\lab2_TH\\NT106_Q12_2\\NT106_Q12_2\\bai3\\input3.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string text = "";
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                text += line + "\n";
                outputTxt += line +" = " + calculateNormal(line).ToString() + "\n";
                rTB.AppendText(line + "\n");
            }

        }

        private void btn_write_Click(object sender, EventArgs e)
        {
            rTB_output.Clear();
            rTB_output.AppendText(outputTxt);
            FileStream fs = new FileStream("C:\\Users\\NAM\\Desktop\\NT106\\lab2_TH\\NT106_Q12_2\\NT106_Q12_2\\bai3\\output3.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(outputTxt);
            sw.Close();
        }
    }
}
