namespace ImageRatioTool
{
    partial class TSeriesRoiSelector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            hScrollBar1 = new HScrollBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlDark;
            pictureBox1.Location = new Point(6, 30);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(512, 512);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(hScrollBar1);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(524, 588);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filename (frame)";
            // 
            // hScrollBar1
            // 
            hScrollBar1.LargeChange = 1;
            hScrollBar1.Location = new Point(6, 545);
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(512, 39);
            hScrollBar1.TabIndex = 2;
            // 
            // TSeriesRoiSelector
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "TSeriesRoiSelector";
            Size = new Size(524, 588);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private HScrollBar hScrollBar1;
    }
}
