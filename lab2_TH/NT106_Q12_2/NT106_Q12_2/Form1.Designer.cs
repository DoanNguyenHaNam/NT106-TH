namespace NT106_Q12_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_1 = new Button();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            btn_bai3 = new Button();
            btn_bai4 = new Button();
            btn_bai5 = new Button();
            btn_bai7 = new Button();
            SuspendLayout();
            // 
            // btn_1
            // 
            btn_1.Font = new Font("Segoe UI", 15F);
            btn_1.Location = new Point(29, 103);
            btn_1.Name = "btn_1";
            btn_1.Size = new Size(133, 38);
            btn_1.TabIndex = 0;
            btn_1.Text = "Bài 1";
            btn_1.UseVisualStyleBackColor = true;
            btn_1.Click += btn_1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(29, 28);
            label1.Name = "label1";
            label1.Size = new Size(247, 28);
            label1.TabIndex = 1;
            label1.Text = "Tên: Đoàn Nguyễn Hà Nam";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(29, 56);
            label2.Name = "label2";
            label2.Size = new Size(161, 28);
            label2.TabIndex = 2;
            label2.Text = "MSSV: 24521100";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15F);
            button1.Location = new Point(29, 164);
            button1.Name = "button1";
            button1.Size = new Size(133, 38);
            button1.TabIndex = 3;
            button1.Text = "Bài 2";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btn_bai3
            // 
            btn_bai3.Font = new Font("Segoe UI", 15F);
            btn_bai3.Location = new Point(29, 227);
            btn_bai3.Name = "btn_bai3";
            btn_bai3.Size = new Size(133, 38);
            btn_bai3.TabIndex = 4;
            btn_bai3.Text = "Bài 3";
            btn_bai3.UseVisualStyleBackColor = true;
            btn_bai3.Click += btn_bai3_Click;
            // 
            // btn_bai4
            // 
            btn_bai4.Font = new Font("Segoe UI", 15F);
            btn_bai4.Location = new Point(29, 293);
            btn_bai4.Name = "btn_bai4";
            btn_bai4.Size = new Size(133, 38);
            btn_bai4.TabIndex = 5;
            btn_bai4.Text = "Bài 4";
            btn_bai4.UseVisualStyleBackColor = true;
            btn_bai4.Click += btn_bai4_Click;
            // 
            // btn_bai5
            // 
            btn_bai5.Font = new Font("Segoe UI", 15F);
            btn_bai5.Location = new Point(206, 103);
            btn_bai5.Name = "btn_bai5";
            btn_bai5.Size = new Size(133, 38);
            btn_bai5.TabIndex = 6;
            btn_bai5.Text = "Bài 5";
            btn_bai5.UseVisualStyleBackColor = true;
            btn_bai5.Click += btn_bai5_Click;
            // 
            // btn_bai7
            // 
            btn_bai7.Font = new Font("Segoe UI", 15F);
            btn_bai7.Location = new Point(206, 227);
            btn_bai7.Name = "btn_bai7";
            btn_bai7.Size = new Size(133, 38);
            btn_bai7.TabIndex = 7;
            btn_bai7.Text = "Bài 7";
            btn_bai7.UseVisualStyleBackColor = true;
            btn_bai7.Click += btn_bai7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_bai7);
            Controls.Add(btn_bai5);
            Controls.Add(btn_bai4);
            Controls.Add(btn_bai3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_1;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button btn_bai3;
        private Button btn_bai4;
        private Button btn_bai5;
        private Button btn_bai7;
    }
}
