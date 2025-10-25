namespace NT106_Q12_2
{
    partial class bai1
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
            btn_write = new Button();
            label2 = new Label();
            btn_read = new Button();
            rTB = new RichTextBox();
            label1 = new Label();
            btn_menu = new Button();
            SuspendLayout();
            // 
            // btn_write
            // 
            btn_write.Font = new Font("Segoe UI", 15F);
            btn_write.Location = new Point(86, 163);
            btn_write.Name = "btn_write";
            btn_write.Size = new Size(173, 60);
            btn_write.TabIndex = 1;
            btn_write.Text = "GHI FILE";
            btn_write.UseVisualStyleBackColor = true;
            btn_write.Click += btn_write_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 21F);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(371, 9);
            label2.Name = "label2";
            label2.Size = new Size(81, 38);
            label2.TabIndex = 3;
            label2.Text = "BÀI 1";
            // 
            // btn_read
            // 
            btn_read.Font = new Font("Segoe UI", 15F);
            btn_read.Location = new Point(86, 80);
            btn_read.Name = "btn_read";
            btn_read.Size = new Size(173, 60);
            btn_read.TabIndex = 4;
            btn_read.Text = "ĐỌC FILE";
            btn_read.UseVisualStyleBackColor = true;
            btn_read.Click += btn_read_Click;
            // 
            // rTB
            // 
            rTB.Font = new Font("Segoe UI", 15F);
            rTB.Location = new Point(340, 80);
            rTB.Name = "rTB";
            rTB.Size = new Size(416, 332);
            rTB.TabIndex = 5;
            rTB.Text = "";
            rTB.TextChanged += rTB_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(358, 65);
            label1.Name = "label1";
            label1.Size = new Size(71, 28);
            label1.TabIndex = 6;
            label1.Text = "SHOW";
            // 
            // btn_menu
            // 
            btn_menu.Font = new Font("Segoe UI", 15F);
            btn_menu.Location = new Point(2, 1);
            btn_menu.Name = "btn_menu";
            btn_menu.Size = new Size(98, 46);
            btn_menu.TabIndex = 7;
            btn_menu.Text = "MENU";
            btn_menu.UseVisualStyleBackColor = true;
            btn_menu.Click += btn_menu_Click;
            // 
            // bai1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_menu);
            Controls.Add(label1);
            Controls.Add(rTB);
            Controls.Add(btn_read);
            Controls.Add(label2);
            Controls.Add(btn_write);
            Name = "bai1";
            Text = "bai1";
            Load += bai1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_write;
        private Label label2;
        private Button btn_read;
        private RichTextBox rTB;
        private Label label1;
        private Button btn_menu;
    }
}