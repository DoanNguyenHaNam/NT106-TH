namespace bai02
{
    partial class Mainboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_listen = new Button();
            listViewCommand = new ListView();
            SuspendLayout();
            // 
            // btn_listen
            // 
            btn_listen.Location = new Point(794, 116);
            btn_listen.Name = "btn_listen";
            btn_listen.Size = new Size(232, 46);
            btn_listen.TabIndex = 0;
            btn_listen.Text = "Listen";
            btn_listen.UseVisualStyleBackColor = true;
            btn_listen.Click += btn_listen_Click;
            // 
            // listViewCommand
            // 
            listViewCommand.Location = new Point(141, 227);
            listViewCommand.Name = "listViewCommand";
            listViewCommand.Size = new Size(885, 310);
            listViewCommand.TabIndex = 1;
            listViewCommand.UseCompatibleStateImageBehavior = false;
            listViewCommand.SelectedIndexChanged += listViewCommand_SelectedIndexChanged;
            listViewCommand.View = View.List;
            // 
            // Mainboard
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1189, 616);
            Controls.Add(listViewCommand);
            Controls.Add(btn_listen);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Mainboard";
            Text = "Mainboard";
            ResumeLayout(false);
        }

        #endregion

        private ColumnHeader colMessage;
        private Button btn_listen;
        private ListView listViewCommand;
    }
}
