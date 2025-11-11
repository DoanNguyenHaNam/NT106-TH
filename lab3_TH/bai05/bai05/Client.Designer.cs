namespace bai05
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
            btn_connect = new Button();
            btn_random = new Button();
            btn_disconnect = new Button();
            button1 = new Button();
            tb = new TextBox();
            tb_random = new TextBox();
            SuspendLayout();
            // 
            // btn_connect
            // 
            btn_connect.Location = new Point(874, 121);
            btn_connect.Name = "btn_connect";
            btn_connect.Size = new Size(160, 44);
            btn_connect.TabIndex = 0;
            btn_connect.Text = "Connect";
            btn_connect.UseVisualStyleBackColor = true;
            btn_connect.Click += button1_Click;
            // 
            // btn_random
            // 
            btn_random.Location = new Point(145, 263);
            btn_random.Name = "btn_random";
            btn_random.Size = new Size(160, 44);
            btn_random.TabIndex = 1;
            btn_random.Text = "Random";
            btn_random.UseVisualStyleBackColor = true;
            btn_random.Click += btn_random_Click;
            // 
            // btn_disconnect
            // 
            btn_disconnect.Location = new Point(874, 263);
            btn_disconnect.Name = "btn_disconnect";
            btn_disconnect.Size = new Size(160, 44);
            btn_disconnect.TabIndex = 2;
            btn_disconnect.Text = "Disconnect";
            btn_disconnect.UseVisualStyleBackColor = true;
            btn_disconnect.Click += btn_disconnect_Click;
            // 
            // button1
            // 
            button1.Location = new Point(145, 162);
            button1.Name = "button1";
            button1.Size = new Size(160, 44);
            button1.TabIndex = 4;
            button1.Text = "Add Food";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // tb
            // 
            tb.Location = new Point(311, 167);
            tb.Name = "tb";
            tb.Size = new Size(441, 34);
            tb.TabIndex = 5;
            // 
            // tb_random
            // 
            tb_random.Location = new Point(311, 268);
            tb_random.Name = "tb_random";
            tb_random.ReadOnly = true;
            tb_random.Size = new Size(441, 34);
            tb_random.TabIndex = 6;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1198, 633);
            Controls.Add(tb_random);
            Controls.Add(tb);
            Controls.Add(button1);
            Controls.Add(btn_disconnect);
            Controls.Add(btn_random);
            Controls.Add(btn_connect);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Client";
            Text = "Client";
            Load += Client_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_connect;
        private Button btn_random;
        private Button btn_disconnect;
        private Button button1;
        private TextBox tb;
        private TextBox tb_random;
    }
}