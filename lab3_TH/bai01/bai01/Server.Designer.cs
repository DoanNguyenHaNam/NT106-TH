namespace bai01
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
            tb_port = new TextBox();
            label1 = new Label();
            btn_listen = new Button();
            label2 = new Label();
            rtb = new RichTextBox();
            SuspendLayout();
            // 
            // tb_port
            // 
            tb_port.Location = new Point(221, 129);
            tb_port.Name = "tb_port";
            tb_port.Size = new Size(141, 34);
            tb_port.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(128, 132);
            label1.Name = "label1";
            label1.Size = new Size(48, 28);
            label1.TabIndex = 1;
            label1.Text = "Port";
            // 
            // btn_listen
            // 
            btn_listen.Location = new Point(574, 128);
            btn_listen.Name = "btn_listen";
            btn_listen.Size = new Size(131, 36);
            btn_listen.TabIndex = 2;
            btn_listen.Text = "Listen";
            btn_listen.UseVisualStyleBackColor = true;
            btn_listen.Click += btn_listen_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(128, 208);
            label2.Name = "label2";
            label2.Size = new Size(170, 28);
            label2.TabIndex = 3;
            label2.Text = "Received Message";
            // 
            // rtb
            // 
            rtb.Location = new Point(128, 251);
            rtb.Name = "rtb";
            rtb.Size = new Size(577, 268);
            rtb.TabIndex = 4;
            rtb.Text = "";
            rtb.TextChanged += rtb_TextChanged;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1168, 588);
            Controls.Add(rtb);
            Controls.Add(label2);
            Controls.Add(btn_listen);
            Controls.Add(label1);
            Controls.Add(tb_port);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Server";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_port;
        private Label label1;
        private Button btn_listen;
        private Label label2;
        private RichTextBox rtb;
    }
}