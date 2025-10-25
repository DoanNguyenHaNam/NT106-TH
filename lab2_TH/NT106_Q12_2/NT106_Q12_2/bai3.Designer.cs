namespace NT106_Q12_2
{
    partial class bai3
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
            rTB = new RichTextBox();
            btn_read = new Button();
            label2 = new Label();
            btn_write = new Button();
            rTB_output = new RichTextBox();
            SuspendLayout();
            // 
            // rTB
            // 
            rTB.Font = new Font("Segoe UI", 15F);
            rTB.Location = new Point(319, 95);
            rTB.Name = "rTB";
            rTB.Size = new Size(469, 143);
            rTB.TabIndex = 9;
            rTB.Text = "";
            // 
            // btn_read
            // 
            btn_read.Font = new Font("Segoe UI", 15F);
            btn_read.Location = new Point(65, 95);
            btn_read.Name = "btn_read";
            btn_read.Size = new Size(173, 60);
            btn_read.TabIndex = 8;
            btn_read.Text = "ĐỌC FILE";
            btn_read.UseVisualStyleBackColor = true;
            btn_read.Click += btn_read_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 21F);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(350, 24);
            label2.Name = "label2";
            label2.Size = new Size(81, 38);
            label2.TabIndex = 7;
            label2.Text = "BÀI 3";
            // 
            // btn_write
            // 
            btn_write.Font = new Font("Segoe UI", 15F);
            btn_write.Location = new Point(65, 178);
            btn_write.Name = "btn_write";
            btn_write.Size = new Size(173, 60);
            btn_write.TabIndex = 6;
            btn_write.Text = "GHI FILE";
            btn_write.UseVisualStyleBackColor = true;
            btn_write.Click += btn_write_Click;
            // 
            // rTB_output
            // 
            rTB_output.Font = new Font("Segoe UI", 15F);
            rTB_output.Location = new Point(319, 296);
            rTB_output.Name = "rTB_output";
            rTB_output.Size = new Size(469, 142);
            rTB_output.TabIndex = 10;
            rTB_output.Text = "";
            // 
            // bai3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rTB_output);
            Controls.Add(rTB);
            Controls.Add(btn_read);
            Controls.Add(label2);
            Controls.Add(btn_write);
            Name = "bai3";
            Text = "bai3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rTB;
        private Button btn_read;
        private Label label2;
        private Button btn_write;
        private RichTextBox rTB_output;
    }
}