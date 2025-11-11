namespace bai03
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
            tb = new TextBox();
            btn_connect = new Button();
            btn_send = new Button();
            btn_disconnect = new Button();
            SuspendLayout();
            // 
            // tb
            // 
            tb.Location = new Point(179, 154);
            tb.Multiline = true;
            tb.Name = "tb";
            tb.Size = new Size(481, 223);
            tb.TabIndex = 0;
            // 
            // btn_connect
            // 
            btn_connect.Location = new Point(717, 154);
            btn_connect.Name = "btn_connect";
            btn_connect.Size = new Size(166, 45);
            btn_connect.TabIndex = 1;
            btn_connect.Text = "Connect";
            btn_connect.UseVisualStyleBackColor = true;
            btn_connect.Click += btn_connect_Click;
            // 
            // btn_send
            // 
            btn_send.Location = new Point(717, 245);
            btn_send.Name = "btn_send";
            btn_send.Size = new Size(166, 45);
            btn_send.TabIndex = 2;
            btn_send.Text = "Send";
            btn_send.UseVisualStyleBackColor = true;
            btn_send.Click += btn_send_Click;
            // 
            // btn_disconnect
            // 
            btn_disconnect.Location = new Point(717, 332);
            btn_disconnect.Name = "btn_disconnect";
            btn_disconnect.Size = new Size(166, 45);
            btn_disconnect.TabIndex = 3;
            btn_disconnect.Text = "Disconnect";
            btn_disconnect.UseVisualStyleBackColor = true;
            btn_disconnect.Click += btn_disconnect_Click;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1181, 621);
            Controls.Add(btn_disconnect);
            Controls.Add(btn_send);
            Controls.Add(btn_connect);
            Controls.Add(tb);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Client";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb;
        private Button btn_connect;
        private Button btn_send;
        private Button btn_disconnect;
    }
}