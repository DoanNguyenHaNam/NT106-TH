namespace bai05
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
            button1 = new Button();
            rtb_food = new RichTextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(851, 121);
            button1.Name = "button1";
            button1.Size = new Size(192, 49);
            button1.TabIndex = 0;
            button1.Text = "Listen";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // rtb_food
            // 
            rtb_food.Location = new Point(172, 221);
            rtb_food.Name = "rtb_food";
            rtb_food.Size = new Size(871, 356);
            rtb_food.TabIndex = 2;
            rtb_food.Text = "";
            rtb_food.TextChanged += richTextBox2_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(172, 175);
            label1.Name = "label1";
            label1.Size = new Size(172, 28);
            label1.TabIndex = 3;
            label1.Text = "Danh sách món ăn";
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1209, 633);
            Controls.Add(label1);
            Controls.Add(rtb_food);
            Controls.Add(button1);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Server";
            Text = "Server";
            Load += Server_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private RichTextBox rtb_food;
        private Label label1;
    }
}