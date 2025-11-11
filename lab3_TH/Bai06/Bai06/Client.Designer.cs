namespace Bai06
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
            rtb_chat = new RichTextBox();
            label2 = new Label();
            btn_send = new Button();
            tb_mess = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(155, 96);
            label1.Name = "label1";
            label1.Size = new Size(103, 28);
            label1.TabIndex = 0;
            label1.Text = "Tài khoản: ";
            // 
            // rtb_chat
            // 
            rtb_chat.Location = new Point(155, 182);
            rtb_chat.Name = "rtb_chat";
            rtb_chat.Size = new Size(351, 400);
            rtb_chat.TabIndex = 1;
            rtb_chat.Text = "";
            rtb_chat.TextChanged += richTextBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(155, 151);
            label2.Name = "label2";
            label2.Size = new Size(165, 28);
            label2.TabIndex = 2;
            label2.Text = "Trò chuyện chung";
            // 
            // btn_send
            // 
            btn_send.Location = new Point(761, 233);
            btn_send.Name = "btn_send";
            btn_send.Size = new Size(173, 45);
            btn_send.TabIndex = 3;
            btn_send.Text = "Send";
            btn_send.UseVisualStyleBackColor = true;
            btn_send.Click += btn_send_Click;
            // 
            // tb_mess
            // 
            tb_mess.Location = new Point(647, 182);
            tb_mess.Name = "tb_mess";
            tb_mess.Size = new Size(415, 34);
            tb_mess.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(647, 151);
            label3.Name = "label3";
            label3.Size = new Size(52, 28);
            label3.TabIndex = 5;
            label3.Text = "Chat";
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1208, 630);
            Controls.Add(label3);
            Controls.Add(tb_mess);
            Controls.Add(btn_send);
            Controls.Add(label2);
            Controls.Add(rtb_chat);
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
        private RichTextBox rtb_chat;
        private Label label2;
        private Button btn_send;
        private TextBox tb_mess;
        private Label label3;
    }
}