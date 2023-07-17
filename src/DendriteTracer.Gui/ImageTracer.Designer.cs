namespace DendriteTracer.Gui
{
    partial class ImageTracer
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
            hScrollBar1 = new HScrollBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            nudSpacing = new NumericUpDown();
            label4 = new Label();
            nudRadius = new NumericUpDown();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnLaunch = new Button();
            btnLoadImage = new Button();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSpacing).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRadius).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Navy;
            pictureBox1.Location = new Point(2, 17);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(358, 307);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // hScrollBar1
            // 
            hScrollBar1.LargeChange = 1;
            hScrollBar1.Location = new Point(2, 326);
            hScrollBar1.Maximum = 10;
            hScrollBar1.Minimum = 1;
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(358, 30);
            hScrollBar1.TabIndex = 1;
            hScrollBar1.Value = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(2, 0);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(2, 349);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 3;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(2, 364);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 4;
            label3.Text = "label3";
            // 
            // nudSpacing
            // 
            nudSpacing.Location = new Point(128, 395);
            nudSpacing.Margin = new Padding(2);
            nudSpacing.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudSpacing.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSpacing.Name = "nudSpacing";
            nudSpacing.Size = new Size(63, 23);
            nudSpacing.TabIndex = 5;
            nudSpacing.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(72, 396);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 6;
            label4.Text = "Spacing";
            // 
            // nudRadius
            // 
            nudRadius.Location = new Point(128, 417);
            nudRadius.Margin = new Padding(2);
            nudRadius.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudRadius.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudRadius.Name = "nudRadius";
            nudRadius.Size = new Size(63, 23);
            nudRadius.TabIndex = 7;
            nudRadius.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(79, 419);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 8;
            label5.Text = "Radius";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(197, 396);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 9;
            label6.Text = "10.12 µm";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(197, 419);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 10;
            label7.Text = "10.12 µm";
            // 
            // btnLaunch
            // 
            btnLaunch.Location = new Point(174, 461);
            btnLaunch.Margin = new Padding(2);
            btnLaunch.Name = "btnLaunch";
            btnLaunch.Size = new Size(122, 26);
            btnLaunch.TabIndex = 11;
            btnLaunch.Text = "Launch Folder";
            btnLaunch.UseVisualStyleBackColor = true;
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(38, 461);
            btnLoadImage.Margin = new Padding(2);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(119, 26);
            btnLoadImage.TabIndex = 12;
            btnLoadImage.Text = "Load Image";
            btnLoadImage.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.ControlDark;
            label8.Location = new Point(69, 491);
            label8.Name = "label8";
            label8.Size = new Size(184, 15);
            label8.TabIndex = 13;
            label8.Text = "Drag/drop a TIF file here to load it";
            // 
            // ImageTracer
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label8);
            Controls.Add(btnLoadImage);
            Controls.Add(btnLaunch);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(nudRadius);
            Controls.Add(label4);
            Controls.Add(nudSpacing);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(hScrollBar1);
            Controls.Add(pictureBox1);
            Margin = new Padding(2);
            Name = "ImageTracer";
            Size = new Size(363, 511);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSpacing).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRadius).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private HScrollBar hScrollBar1;
        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown nudSpacing;
        private Label label4;
        private NumericUpDown nudRadius;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnLaunch;
        private Button btnLoadImage;
        private Label label8;
    }
}
