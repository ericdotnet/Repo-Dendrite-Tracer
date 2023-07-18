namespace DendriteTracer.Gui
{
    partial class UserInputs
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
            groupBox1 = new GroupBox();
            cbRoiCirular = new CheckBox();
            label2 = new Label();
            label1 = new Label();
            nudRoiRadius = new NumericUpDown();
            nudRoiSpacing = new NumericUpDown();
            groupBox2 = new GroupBox();
            label9 = new Label();
            label10 = new Label();
            nudPixelThresholdMult = new NumericUpDown();
            nudPixelThresholdFloor = new NumericUpDown();
            groupBox3 = new GroupBox();
            label4 = new Label();
            nudBrightness = new NumericUpDown();
            label3 = new Label();
            nudImageSubtractionFloor = new NumericUpDown();
            cbImageSubtractionEnabled = new CheckBox();
            groupBox4 = new GroupBox();
            label8 = new Label();
            btnLoadImage = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudRoiRadius).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRoiSpacing).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPixelThresholdMult).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPixelThresholdFloor).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudBrightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudImageSubtractionFloor).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(cbRoiCirular);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(nudRoiRadius);
            groupBox1.Controls.Add(nudRoiSpacing);
            groupBox1.Location = new Point(3, 283);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(467, 120);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "ROI Dimensions";
            // 
            // cbRoiCirular
            // 
            cbRoiCirular.AutoSize = true;
            cbRoiCirular.Checked = true;
            cbRoiCirular.CheckState = CheckState.Checked;
            cbRoiCirular.Location = new Point(307, 65);
            cbRoiCirular.Name = "cbRoiCirular";
            cbRoiCirular.Size = new Size(96, 29);
            cbRoiCirular.TabIndex = 9;
            cbRoiCirular.Text = "Circular";
            cbRoiCirular.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(166, 37);
            label2.Name = "label2";
            label2.Size = new Size(106, 25);
            label2.TabIndex = 4;
            label2.Text = "Radius (µm)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 37);
            label1.Name = "label1";
            label1.Size = new Size(116, 25);
            label1.TabIndex = 3;
            label1.Text = "Spacing (µm)";
            // 
            // nudRoiRadius
            // 
            nudRoiRadius.Location = new Point(166, 65);
            nudRoiRadius.Name = "nudRoiRadius";
            nudRoiRadius.Size = new Size(106, 31);
            nudRoiRadius.TabIndex = 1;
            nudRoiRadius.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // nudRoiSpacing
            // 
            nudRoiSpacing.Location = new Point(26, 65);
            nudRoiSpacing.Name = "nudRoiSpacing";
            nudRoiSpacing.Size = new Size(106, 31);
            nudRoiSpacing.TabIndex = 0;
            nudRoiSpacing.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(nudPixelThresholdMult);
            groupBox2.Controls.Add(nudPixelThresholdFloor);
            groupBox2.Location = new Point(3, 419);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(467, 121);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Pixel Threshold";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(166, 39);
            label9.Name = "label9";
            label9.Size = new Size(90, 25);
            label9.TabIndex = 4;
            label9.Text = "Threshold";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(26, 39);
            label10.Name = "label10";
            label10.Size = new Size(83, 25);
            label10.TabIndex = 3;
            label10.Text = "Floor (%)";
            // 
            // nudPixelThresholdMult
            // 
            nudPixelThresholdMult.Location = new Point(166, 67);
            nudPixelThresholdMult.Name = "nudPixelThresholdMult";
            nudPixelThresholdMult.Size = new Size(106, 31);
            nudPixelThresholdMult.TabIndex = 1;
            nudPixelThresholdMult.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // nudPixelThresholdFloor
            // 
            nudPixelThresholdFloor.Location = new Point(26, 67);
            nudPixelThresholdFloor.Name = "nudPixelThresholdFloor";
            nudPixelThresholdFloor.Size = new Size(106, 31);
            nudPixelThresholdFloor.TabIndex = 0;
            nudPixelThresholdFloor.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(nudBrightness);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(nudImageSubtractionFloor);
            groupBox3.Controls.Add(cbImageSubtractionEnabled);
            groupBox3.Location = new Point(3, 139);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(467, 128);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Image Background Subtraction";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(297, 40);
            label4.Name = "label4";
            label4.Size = new Size(94, 25);
            label4.TabIndex = 14;
            label4.Text = "Brightness";
            // 
            // nudBrightness
            // 
            nudBrightness.DecimalPlaces = 1;
            nudBrightness.Increment = new decimal(new int[] { 2, 0, 0, 65536 });
            nudBrightness.Location = new Point(297, 71);
            nudBrightness.Name = "nudBrightness";
            nudBrightness.Size = new Size(106, 31);
            nudBrightness.TabIndex = 13;
            nudBrightness.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 40);
            label3.Name = "label3";
            label3.Size = new Size(83, 25);
            label3.TabIndex = 12;
            label3.Text = "Floor (%)";
            // 
            // nudImageSubtractionFloor
            // 
            nudImageSubtractionFloor.Enabled = false;
            nudImageSubtractionFloor.Location = new Point(26, 71);
            nudImageSubtractionFloor.Name = "nudImageSubtractionFloor";
            nudImageSubtractionFloor.Size = new Size(106, 31);
            nudImageSubtractionFloor.TabIndex = 11;
            nudImageSubtractionFloor.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // cbImageSubtractionEnabled
            // 
            cbImageSubtractionEnabled.AutoSize = true;
            cbImageSubtractionEnabled.Enabled = false;
            cbImageSubtractionEnabled.Location = new Point(182, 73);
            cbImageSubtractionEnabled.Name = "cbImageSubtractionEnabled";
            cbImageSubtractionEnabled.Size = new Size(90, 29);
            cbImageSubtractionEnabled.TabIndex = 10;
            cbImageSubtractionEnabled.Text = "Enable";
            cbImageSubtractionEnabled.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(btnLoadImage);
            groupBox4.Location = new Point(3, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(467, 120);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Load Data";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.ControlDark;
            label8.Location = new Point(205, 58);
            label8.Name = "label8";
            label8.Size = new Size(198, 25);
            label8.TabIndex = 8;
            label8.Text = "or drag/drop a TIF here";
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(16, 35);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(159, 70);
            btnLoadImage.TabIndex = 0;
            btnLoadImage.Text = "Select Projection Time Series";
            btnLoadImage.UseVisualStyleBackColor = true;
            // 
            // UserInputs
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "UserInputs";
            Size = new Size(473, 600);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudRoiRadius).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRoiSpacing).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPixelThresholdMult).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPixelThresholdFloor).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudBrightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudImageSubtractionFloor).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private NumericUpDown nudRoiRadius;
        private NumericUpDown nudRoiSpacing;
        private GroupBox groupBox2;
        private Label label9;
        private Label label10;
        private NumericUpDown nudPixelThresholdMult;
        private NumericUpDown nudPixelThresholdFloor;
        private CheckBox cbRoiCirular;
        private GroupBox groupBox3;
        private Label label3;
        private NumericUpDown nudImageSubtractionFloor;
        private CheckBox cbImageSubtractionEnabled;
        private GroupBox groupBox4;
        private Label label8;
        private Button btnLoadImage;
        private Label label4;
        private NumericUpDown nudBrightness;
    }
}
