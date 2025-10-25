namespace NT106_Q12_2
{
    partial class bai7
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
            tv = new TreeView();
            rtb = new RichTextBox();
            pb = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb).BeginInit();
            SuspendLayout();
            // 
            // tv
            // 
            tv.Location = new Point(12, 12);
            tv.Name = "tv";
            tv.Size = new Size(271, 426);
            tv.TabIndex = 0;
            tv.BeforeExpand += tv_BeforeExpand;
            tv.NodeMouseDoubleClick += tv_NodeMouseDoubleClick;
            tv.AfterSelect += tv_AfterSelect;
            // 
            // rtb
            // 
            rtb.Location = new Point(289, 12);
            rtb.Name = "rtb";
            rtb.Size = new Size(499, 426);
            rtb.TabIndex = 1;
            rtb.Text = "";
            rtb.TextChanged += rtb_TextChanged;
            // 
            // pb
            // 
            pb.Location = new Point(289, 12);
            pb.Name = "pb";
            pb.Size = new Size(499, 426);
            pb.TabIndex = 2;
            pb.TabStop = false;
            pb.Click += pb_Click;
            // 
            // bai7
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pb);
            Controls.Add(rtb);
            Controls.Add(tv);
            Name = "bai7";
            Text = "bai7";
            Load += bai7_Load;
            ((System.ComponentModel.ISupportInitialize)pb).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TreeView tv;
        private RichTextBox rtb;
        private PictureBox pb;
    }
}