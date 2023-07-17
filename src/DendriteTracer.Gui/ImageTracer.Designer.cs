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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSpacing).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRadius).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Navy;
            pictureBox1.Location = new Point(3, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(512, 512);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // hScrollBar1
            // 
            hScrollBar1.LargeChange = 1;
            hScrollBar1.Location = new Point(3, 543);
            hScrollBar1.Maximum = 10;
            hScrollBar1.Minimum = 1;
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(512, 39);
            hScrollBar1.TabIndex = 1;
            hScrollBar1.Value = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 582);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 3;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 607);
            label3.Name = "label3";
            label3.Size = new Size(59, 25);
            label3.TabIndex = 4;
            label3.Text = "label3";
            // 
            // nudSpacing
            // 
            nudSpacing.Location = new Point(196, 641);
            nudSpacing.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudSpacing.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSpacing.Name = "nudSpacing";
            nudSpacing.Size = new Size(90, 31);
            nudSpacing.TabIndex = 5;
            nudSpacing.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(115, 643);
            label4.Name = "label4";
            label4.Size = new Size(75, 25);
            label4.TabIndex = 6;
            label4.Text = "Spacing";
            // 
            // nudRadius
            // 
            nudRadius.Location = new Point(196, 678);
            nudRadius.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudRadius.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudRadius.Name = "nudRadius";
            nudRadius.Size = new Size(90, 31);
            nudRadius.TabIndex = 7;
            nudRadius.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(125, 680);
            label5.Name = "label5";
            label5.Size = new Size(65, 25);
            label5.TabIndex = 8;
            label5.Text = "Radius";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(292, 643);
            label6.Name = "label6";
            label6.Size = new Size(87, 25);
            label6.TabIndex = 9;
            label6.Text = "10.12 µm";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(292, 680);
            label7.Name = "label7";
            label7.Size = new Size(87, 25);
            label7.TabIndex = 10;
            label7.Text = "10.12 µm";
            // 
            // ImageTracer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
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
            Name = "ImageTracer";
            Size = new Size(518, 717);
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
    }
}
