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
using System.Text.Json;

namespace NT106_Q12_2
{
    public partial class bai4 : Form
    {
        public bai4()
        {
            InitializeComponent();
        }

        class Student
        {
            public string ID { get; set; }
            public string name { get; set; }
            public string phone { get; set; }
            public double course1 { get; set; }
            public double course2 { get; set; }
            public double course3 { get; set; }
            public double average
            {
                get
                {
                    return (course1 + course2 + course3) / 3;
                }
            }
            public Student(string ID, string name, string phone, double course1, double course2, double course3)
            {
                this.ID = ID;
                this.name = name;
                this.phone = phone;
                this.course1 = course1;
                this.course2 = course2;
                this.course3 = course3;
            }
            public override string ToString()
            {
                return $"Name: {name}\nID: {ID}\nPhone: {phone}\nCourse1: {course1}\nCourse2: {course2}\nCourse3: {course3}\nAverage: {average}";
            }
        }

        static bool checkPhoneInput(string phone)
        {
            if (phone.Length != 10)
                return false;
            if (phone[0] != '0')
                return false;
            foreach (char c in phone)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        static bool checkCourseInput(string score)
        {
            try
            {
                double temp = Convert.ToDouble(score);
                if (temp < 0 || temp > 10)
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }

        static bool checkIDInput(string ID)
        {
            if (!int.TryParse(ID, out _))
                return false;

            string path = "C:\\Users\\NAM\\Desktop\\NT106\\lab2_TH\\NT106_Q12_2\\NT106_Q12_2\\bai4\\input4.txt";

            if (!File.Exists(path))
                return true;

            try
            {
                string json = File.ReadAllText(path);
                if (string.IsNullOrWhiteSpace(json))
                    return true;

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                Student[] students = JsonSerializer.Deserialize<Student[]>(json, options);

                if (students == null || students.Length == 0)
                    return true;

                return !students.Any(s => s.ID == ID);
            }
            catch
            {
                return false;
            }
        }
        private string path = "C:\\Users\\NAM\\Desktop\\NT106\\lab2_TH\\NT106_Q12_2\\NT106_Q12_2\\bai4\\input4.txt";
        private string input_path = "C:\\Users\\NAM\\Desktop\\NT106\\lab2_TH\\NT106_Q12_2\\NT106_Q12_2\\bai4\\input4.txt";

        //"C:\\Users\\NAM\\Desktop\\NT106\\lab2_TH\\NT106_Q12_2\\NT106_Q12_2\\bai4\\input4.txt"
        static void readFronJson(Student[] a)
        {

        }
        private void btn_add_write_Click(object sender, EventArgs e)
        {
            if (tb_name_write.Text == "" || tb_id_write.Text == "" || tb_phone_write.Text == "" || tb_course1_write.Text == "" || tb_course2_write.Text == "" || tb_course3_write.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (!checkIDInput(tb_id_write.Text))
            {
                MessageBox.Show("ID không hợp lệ hoặc đã tồn tại");
                return;
            }
            if (!checkPhoneInput(tb_phone_write.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
                return;
            }
            if (!checkCourseInput(tb_course1_write.Text) || !checkCourseInput(tb_course2_write.Text) || !checkCourseInput(tb_course3_write.Text))
            {
                MessageBox.Show("Điểm không hợp lệ (0-10)");
                return;
            }
            Student newStudent = new Student(
                tb_id_write.Text,
                tb_name_write.Text,
                tb_phone_write.Text,
                Convert.ToDouble(tb_course1_write.Text),
                Convert.ToDouble(tb_course2_write.Text),
                Convert.ToDouble(tb_course3_write.Text)
            );
            List<Student> studentsList = new List<Student>();
            if (File.Exists(path))
            {
                try
                {
                    string json = File.ReadAllText(path);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        Student[] existingStudents = JsonSerializer.Deserialize<Student[]>(json, options);
                        if (existingStudents != null)
                        {
                            studentsList.AddRange(existingStudents);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi đọc file: {ex.Message}");
                    return;
                }
            }
            studentsList.Add(newStudent);
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonOutput = JsonSerializer.Serialize(studentsList.ToArray(), options);
                File.WriteAllText(path, jsonOutput);
                MessageBox.Show("Thêm sinh viên thành công!");

                tb_id_write.Clear();
                tb_name_write.Clear();
                tb_phone_write.Clear();
                tb_course1_write.Clear();
                tb_course2_write.Clear();
                tb_course3_write.Clear();

                var compactOptions = new JsonSerializerOptions { WriteIndented = false };
                string compactJson = JsonSerializer.Serialize(studentsList.ToArray(), compactOptions);
                richTextBox1.Clear();
                foreach (var student in studentsList)
                {
                    richTextBox1.AppendText(student.ToString() + "\n\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi ghi file: {ex.Message}");
            }
        }

        private void btn_write_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            path = ofd.FileName;
            try
            {
                string json = File.ReadAllText(path);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                Student[] students = JsonSerializer.Deserialize<Student[]>(json, options);
                if (students == null || students.Length == 0)
                {
                    MessageBox.Show("File rỗng hoặc không có dữ liệu hợp lệ.");
                    path = "C:\\Users\\NAM\\Desktop\\NT106\\lab2_TH\\NT106_Q12_2\\NT106_Q12_2\\bai4\\input4.txt";
                    return;
                }
                richTextBox1.Clear();
                foreach (var student in students)
                {
                    richTextBox1.AppendText(student.ToString() + "\n");
                    richTextBox1.AppendText(student.average + "\n\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đọc file: {ex.Message}");
            }
        }

        private int Trang = 0;
        private Student[] students_input = new Student[1];

        private void btn_read_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            input_path = ofd.FileName;
            
            try
            {
                string json = File.ReadAllText(input_path);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                students_input = JsonSerializer.Deserialize<Student[]>(json, options);
                if (students_input == null || students_input.Length == 0)
                {
                    MessageBox.Show("File rỗng hoặc không có dữ liệu hợp lệ.");
                    input_path = "C:\\Users\\NAM\\Desktop\\NT106\\lab2_TH\\NT106_Q12_2\\NT106_Q12_2\\bai4\\input4.txt";
                    return;
                }
                Trang = 1;
                var student = students_input[Trang - 1];
                tb_id_read.Text = student.ID;
                tb_name_read.Text = student.name;
                tb_phone_read.Text = student.phone;
                tb_course1_read.Text = student.course1.ToString();
                tb_course2_read.Text = student.course2.ToString();
                tb_course3_read.Text = student.course3.ToString();
                tb_average_read.Text = student.average.ToString();
                lb_number_page.Text = Trang.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đọc file: {ex.Message}");
            }
        }
        private void ShowPage(int page)
        {
            if (students_input == null || students_input.Length == 0) return;
            if (page < 1 || page > students_input.Length) return;

            var student = students_input[page - 1];
            tb_id_read.Text = student.ID;
            tb_name_read.Text = student.name;
            tb_phone_read.Text = student.phone;
            tb_course1_read.Text = student.course1.ToString();
            tb_course2_read.Text = student.course2.ToString();
            tb_course3_read.Text = student.course3.ToString();
            tb_average_read.Text = student.average.ToString();

            Trang = page;
            lb_number_page.Text = Trang.ToString();
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            if (Trang == 0) { MessageBox.Show("Chưa Chọn File Input."); return; }
            if (Trang <= 1) { MessageBox.Show("Đang ở trang đầu."); return; }
            ShowPage(Trang - 1);
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (Trang == 0) { MessageBox.Show("Chưa Chọn File Input."); return; }
            if (Trang >= students_input.Length) { MessageBox.Show("Đang ở trang cuối."); return; }
            ShowPage(Trang + 1);
        }
    }
}
