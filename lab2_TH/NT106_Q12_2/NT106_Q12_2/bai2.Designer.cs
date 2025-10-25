namespace NT106_Q12_2
{
    partial class bai2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_file = new Button();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            button1 = new Button();
            tb_charactercount = new TextBox();
            tb_wordcount = new TextBox();
            tb_url = new TextBox();
            tb_linecount = new TextBox();
            tb_size = new TextBox();
            tb_filename = new TextBox();
            rtb = new RichTextBox();
            SuspendLayout();
            // 
            // btn_file
            // 
            btn_file.Font = new Font("Segoe UI", 15F);
            btn_file.Location = new Point(25, 81);
            btn_file.Name = "btn_file";
            btn_file.Size = new Size(415, 40);
            btn_file.TabIndex = 0;
            btn_file.Text = "Read From File";
            btn_file.UseVisualStyleBackColor = true;
            btn_file.Click += btn_file_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 21F);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(359, 9);
            label2.Name = "label2";
            label2.Size = new Size(81, 38);
            label2.TabIndex = 4;
            label2.Text = "BÀI 2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(25, 138);
            label1.Name = "label1";
            label1.Size = new Size(95, 28);
            label1.TabIndex = 5;
            label1.Text = "File name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(25, 182);
            label3.Name = "label3";
            label3.Size = new Size(47, 28);
            label3.TabIndex = 6;
            label3.Text = "Size";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(25, 226);
            label4.Name = "label4";
            label4.Size = new Size(47, 28);
            label4.TabIndex = 7;
            label4.Text = "URL";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(25, 267);
            label5.Name = "label5";
            label5.Size = new Size(102, 28);
            label5.TabIndex = 8;
            label5.Text = "Line count";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F);
            label6.Location = new Point(25, 314);
            label6.Name = "label6";
            label6.Size = new Size(116, 28);
            label6.TabIndex = 9;
            label6.Text = "Word count";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15F);
            label7.Location = new Point(25, 358);
            label7.Name = "label7";
            label7.Size = new Size(150, 28);
            label7.TabIndex = 10;
            label7.Text = "Character count";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15F);
            button1.Location = new Point(25, 414);
            button1.Name = "button1";
            button1.Size = new Size(415, 40);
            button1.TabIndex = 11;
            button1.Text = "Exit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tb_charactercount
            // 
            tb_charactercount.Font = new Font("Segoe UI", 15F);
            tb_charactercount.Location = new Point(187, 355);
            tb_charactercount.Name = "tb_charactercount";
            tb_charactercount.ReadOnly = true;
            tb_charactercount.Size = new Size(253, 34);
            tb_charactercount.TabIndex = 12;
            // 
            // tb_wordcount
            // 
            tb_wordcount.Font = new Font("Segoe UI", 15F);
            tb_wordcount.Location = new Point(187, 311);
            tb_wordcount.Name = "tb_wordcount";
            tb_wordcount.ReadOnly = true;
            tb_wordcount.Size = new Size(253, 34);
            tb_wordcount.TabIndex = 13;
            // 
            // tb_url
            // 
            tb_url.Font = new Font("Segoe UI", 15F);
            tb_url.Location = new Point(187, 223);
            tb_url.Name = "tb_url";
            tb_url.ReadOnly = true;
            tb_url.Size = new Size(253, 34);
            tb_url.TabIndex = 15;
            // 
            // tb_linecount
            // 
            tb_linecount.Font = new Font("Segoe UI", 15F);
            tb_linecount.Location = new Point(187, 264);
            tb_linecount.Name = "tb_linecount";
            tb_linecount.ReadOnly = true;
            tb_linecount.Size = new Size(253, 34);
            tb_linecount.TabIndex = 14;
            // 
            // tb_size
            // 
            tb_size.Font = new Font("Segoe UI", 15F);
            tb_size.Location = new Point(187, 179);
            tb_size.Name = "tb_size";
            tb_size.ReadOnly = true;
            tb_size.Size = new Size(253, 34);
            tb_size.TabIndex = 16;
            tb_size.TextChanged += textBox5_TextChanged;
            // 
            // tb_filename
            // 
            tb_filename.Font = new Font("Segoe UI", 15F);
            tb_filename.Location = new Point(187, 135);
            tb_filename.Name = "tb_filename";
            tb_filename.ReadOnly = true;
            tb_filename.Size = new Size(253, 34);
            tb_filename.TabIndex = 17;
            // 
            // rtb
            // 
            rtb.Font = new Font("Segoe UI", 15F);
            rtb.Location = new Point(485, 81);
            rtb.Name = "rtb";
            rtb.Size = new Size(335, 373);
            rtb.TabIndex = 18;
            rtb.Text = "";
            // 
            // bai2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 481);
            Controls.Add(rtb);
            Controls.Add(tb_filename);
            Controls.Add(tb_size);
            Controls.Add(tb_url);
            Controls.Add(tb_linecount);
            Controls.Add(tb_wordcount);
            Controls.Add(tb_charactercount);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(btn_file);
            Name = "bai2";
            Text = "bai2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_file;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button button1;
        private TextBox tb_charactercount;
        private TextBox tb_wordcount;
        private TextBox tb_url;
        private TextBox tb_linecount;
        private TextBox tb_size;
        private TextBox tb_filename;
        private RichTextBox rtb;
    }
}