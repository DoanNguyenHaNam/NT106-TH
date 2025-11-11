namespace bai01
{
    partial class Client
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tb_mess = new TextBox();
            btn_send = new Button();
            tb_ip = new TextBox();
            tb_port = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(151, 135);
            label1.Name = "label1";
            label1.Size = new Size(143, 28);
            label1.TabIndex = 0;
            label1.Text = "IP Remote host";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(533, 135);
            label2.Name = "label2";
            label2.Size = new Size(48, 28);
            label2.TabIndex = 1;
            label2.Text = "Port";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(151, 233);
            label3.Name = "label3";
            label3.Size = new Size(88, 28);
            label3.TabIndex = 2;
            label3.Text = "Message";
            // 
            // tb_mess
            // 
            tb_mess.Location = new Point(151, 273);
            tb_mess.Multiline = true;
            tb_mess.Name = "tb_mess";
            tb_mess.Size = new Size(482, 140);
            tb_mess.TabIndex = 3;
            tb_mess.TextChanged += tb_mess_TextChanged;
            // 
            // btn_send
            // 
            btn_send.Location = new Point(151, 428);
            btn_send.Name = "btn_send";
            btn_send.Size = new Size(107, 38);
            btn_send.TabIndex = 4;
            btn_send.Text = "Send";
            btn_send.UseVisualStyleBackColor = true;
            btn_send.Click += btn_send_Click;
            // 
            // tb_ip
            // 
            tb_ip.Location = new Point(151, 175);
            tb_ip.Name = "tb_ip";
            tb_ip.Size = new Size(204, 34);
            tb_ip.TabIndex = 5;
            // 
            // tb_port
            // 
            tb_port.Location = new Point(533, 175);
            tb_port.Name = "tb_port";
            tb_port.Size = new Size(100, 34);
            tb_port.TabIndex = 6;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 619);
            Controls.Add(tb_port);
            Controls.Add(tb_ip);
            Controls.Add(btn_send);
            Controls.Add(tb_mess);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Client";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tb_mess;
        private Button btn_send;
        private TextBox tb_ip;
        private TextBox tb_port;
    }
}