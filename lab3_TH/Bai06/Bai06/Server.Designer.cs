namespace Bai06
{
    partial class Server
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
            btn_listen = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // btn_listen
            // 
            btn_listen.Location = new Point(769, 94);
            btn_listen.Name = "btn_listen";
            btn_listen.Size = new Size(168, 44);
            btn_listen.TabIndex = 0;
            btn_listen.Text = "Listen";
            btn_listen.UseVisualStyleBackColor = true;
            btn_listen.Click += btn_listen_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(133, 94);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(630, 429);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1150, 596);
            Controls.Add(richTextBox1);
            Controls.Add(btn_listen);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Server";
            Text = "Server";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_listen;
        private RichTextBox richTextBox1;
    }
}