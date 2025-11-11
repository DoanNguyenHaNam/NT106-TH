namespace bai03
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
            btn = new Button();
            listViewCommand = new ListView();
            SuspendLayout();
            // 
            // btn
            // 
            btn.Location = new Point(825, 132);
            btn.Name = "btn";
            btn.Size = new Size(188, 44);
            btn.TabIndex = 0;
            btn.Text = "Listen";
            btn.UseVisualStyleBackColor = true;
            btn.Click += btn_Click;
            // 
            // listViewCommand
            // 
            listViewCommand.Location = new Point(153, 199);
            listViewCommand.Name = "listViewCommand";
            listViewCommand.Size = new Size(860, 356);
            listViewCommand.TabIndex = 1;
            listViewCommand.UseCompatibleStateImageBehavior = false;
            listViewCommand.View = View.List;
            listViewCommand.SelectedIndexChanged += listViewCommand_SelectedIndexChanged;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1177, 607);
            Controls.Add(listViewCommand);
            Controls.Add(btn);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Server";
            Text = "Server";
            ResumeLayout(false);
        }

        #endregion

        private Button btn;
        private ListView listViewCommand;
    }
}