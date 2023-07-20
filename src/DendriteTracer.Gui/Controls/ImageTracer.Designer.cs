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
            nudBrightness = new NumericUpDown();
            label2 = new Label();
            cbRois = new CheckBox();
            cbSpines = new CheckBox();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label3 = new Label();
            btnSelectFile = new Button();
            groupBox3 = new GroupBox();
            lblAreaPx = new Label();
            lblRadiusPx = new Label();
            lblSpacingPx = new Label();
            cbRoiCirular = new CheckBox();
            label4 = new Label();
            label5 = new Label();
            nudRoiRadius = new NumericUpDown();
            nudRoiSpacing = new NumericUpDown();
            groupBox4 = new GroupBox();
            label6 = new Label();
            nudImageSubtractionFloor = new NumericUpDown();
            cbImageSubtractionEnabled = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudBrightness).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudRoiRadius).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRoiSpacing).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudImageSubtractionFloor).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Navy;
            pictureBox1.Location = new Point(3, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(511, 512);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // hScrollBar1
            // 
            hScrollBar1.Dock = DockStyle.Fill;
            hScrollBar1.LargeChange = 1;
            hScrollBar1.Location = new Point(0, 0);
            hScrollBar1.Maximum = 10;
            hScrollBar1.Minimum = 1;
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(507, 47);
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
            // nudBrightness
            // 
            nudBrightness.DecimalPlaces = 1;
            nudBrightness.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            nudBrightness.Location = new Point(107, 37);
            nudBrightness.Margin = new Padding(4, 5, 4, 5);
            nudBrightness.Name = "nudBrightness";
            nudBrightness.Size = new Size(90, 31);
            nudBrightness.TabIndex = 3;
            nudBrightness.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 40);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(94, 25);
            label2.TabIndex = 4;
            label2.Text = "Brightness";
            // 
            // cbRois
            // 
            cbRois.AutoSize = true;
            cbRois.Checked = true;
            cbRois.CheckState = CheckState.Checked;
            cbRois.Location = new Point(330, 42);
            cbRois.Margin = new Padding(4, 5, 4, 5);
            cbRois.Name = "cbRois";
            cbRois.Size = new Size(76, 29);
            cbRois.TabIndex = 5;
            cbRois.Text = "ROIs";
            cbRois.UseVisualStyleBackColor = true;
            // 
            // cbSpines
            // 
            cbSpines.AutoSize = true;
            cbSpines.Checked = true;
            cbSpines.CheckState = CheckState.Checked;
            cbSpines.Location = new Point(236, 42);
            cbSpines.Margin = new Padding(4, 5, 4, 5);
            cbSpines.Name = "cbSpines";
            cbSpines.Size = new Size(90, 29);
            cbSpines.TabIndex = 6;
            cbSpines.Text = "Spines";
            cbSpines.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(hScrollBar1);
            panel1.Location = new Point(4, 548);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(509, 49);
            panel1.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(nudBrightness);
            groupBox1.Controls.Add(cbSpines);
            groupBox1.Controls.Add(cbRois);
            groupBox1.Location = new Point(6, 857);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(507, 95);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Display";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(btnSelectFile);
            groupBox2.Location = new Point(6, 608);
            groupBox2.Margin = new Padding(4, 5, 4, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 5, 4, 5);
            groupBox2.Size = new Size(507, 103);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Load Data";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlDark;
            label3.Location = new Point(183, 53);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(198, 25);
            label3.TabIndex = 11;
            label3.Text = "or drag/drop a file here";
            // 
            // btnSelectFile
            // 
            btnSelectFile.Location = new Point(17, 47);
            btnSelectFile.Margin = new Padding(4, 5, 4, 5);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(107, 38);
            btnSelectFile.TabIndex = 10;
            btnSelectFile.Text = "Select File";
            btnSelectFile.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblAreaPx);
            groupBox3.Controls.Add(lblRadiusPx);
            groupBox3.Controls.Add(lblSpacingPx);
            groupBox3.Controls.Add(cbRoiCirular);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(nudRoiRadius);
            groupBox3.Controls.Add(nudRoiSpacing);
            groupBox3.Location = new Point(6, 960);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(507, 136);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "ROI Dimensions";
            // 
            // lblAreaPx
            // 
            lblAreaPx.AutoSize = true;
            lblAreaPx.ForeColor = SystemColors.ControlDark;
            lblAreaPx.Location = new Point(302, 99);
            lblAreaPx.Name = "lblAreaPx";
            lblAreaPx.Size = new Size(73, 25);
            lblAreaPx.TabIndex = 12;
            lblAreaPx.Text = "123 px²";
            // 
            // lblRadiusPx
            // 
            lblRadiusPx.AutoSize = true;
            lblRadiusPx.ForeColor = SystemColors.ControlDark;
            lblRadiusPx.Location = new Point(163, 99);
            lblRadiusPx.Name = "lblRadiusPx";
            lblRadiusPx.Size = new Size(66, 25);
            lblRadiusPx.TabIndex = 11;
            lblRadiusPx.Text = "123 px";
            // 
            // lblSpacingPx
            // 
            lblSpacingPx.AutoSize = true;
            lblSpacingPx.ForeColor = SystemColors.ControlDark;
            lblSpacingPx.Location = new Point(23, 99);
            lblSpacingPx.Name = "lblSpacingPx";
            lblSpacingPx.Size = new Size(66, 25);
            lblSpacingPx.TabIndex = 10;
            lblSpacingPx.Text = "123 px";
            // 
            // cbRoiCirular
            // 
            cbRoiCirular.AutoSize = true;
            cbRoiCirular.Checked = true;
            cbRoiCirular.CheckState = CheckState.Checked;
            cbRoiCirular.Location = new Point(306, 67);
            cbRoiCirular.Name = "cbRoiCirular";
            cbRoiCirular.Size = new Size(96, 29);
            cbRoiCirular.TabIndex = 9;
            cbRoiCirular.Text = "Circular";
            cbRoiCirular.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(161, 35);
            label4.Name = "label4";
            label4.Size = new Size(106, 25);
            label4.TabIndex = 4;
            label4.Text = "Radius (µm)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 35);
            label5.Name = "label5";
            label5.Size = new Size(116, 25);
            label5.TabIndex = 3;
            label5.Text = "Spacing (µm)";
            // 
            // nudRoiRadius
            // 
            nudRoiRadius.Location = new Point(166, 65);
            nudRoiRadius.Name = "nudRoiRadius";
            nudRoiRadius.Size = new Size(106, 31);
            nudRoiRadius.TabIndex = 1;
            nudRoiRadius.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // nudRoiSpacing
            // 
            nudRoiSpacing.Location = new Point(26, 65);
            nudRoiSpacing.Name = "nudRoiSpacing";
            nudRoiSpacing.Size = new Size(106, 31);
            nudRoiSpacing.TabIndex = 0;
            nudRoiSpacing.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(nudImageSubtractionFloor);
            groupBox4.Controls.Add(cbImageSubtractionEnabled);
            groupBox4.Location = new Point(6, 720);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(507, 127);
            groupBox4.TabIndex = 11;
            groupBox4.TabStop = false;
            groupBox4.Text = "Noise Floor Subtraction";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 38);
            label6.Name = "label6";
            label6.Size = new Size(83, 25);
            label6.TabIndex = 12;
            label6.Text = "Floor (%)";
            // 
            // nudImageSubtractionFloor
            // 
            nudImageSubtractionFloor.Location = new Point(26, 72);
            nudImageSubtractionFloor.Name = "nudImageSubtractionFloor";
            nudImageSubtractionFloor.Size = new Size(106, 31);
            nudImageSubtractionFloor.TabIndex = 11;
            nudImageSubtractionFloor.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // cbImageSubtractionEnabled
            // 
            cbImageSubtractionEnabled.AutoSize = true;
            cbImageSubtractionEnabled.Checked = true;
            cbImageSubtractionEnabled.CheckState = CheckState.Checked;
            cbImageSubtractionEnabled.Location = new Point(166, 74);
            cbImageSubtractionEnabled.Name = "cbImageSubtractionEnabled";
            cbImageSubtractionEnabled.Size = new Size(90, 29);
            cbImageSubtractionEnabled.TabIndex = 10;
            cbImageSubtractionEnabled.Text = "Enable";
            cbImageSubtractionEnabled.UseVisualStyleBackColor = true;
            // 
            // ImageTracer
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "ImageTracer";
            Size = new Size(519, 1100);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudBrightness).EndInit();
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudRoiRadius).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRoiSpacing).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudImageSubtractionFloor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private HScrollBar hScrollBar1;
        private Label label1;
        private NumericUpDown nudBrightness;
        private Label label2;
        private CheckBox cbRois;
        private CheckBox cbSpines;
        private Panel panel1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnSelectFile;
        private Label label3;
        private GroupBox groupBox3;
        private CheckBox cbRoiCirular;
        private Label label4;
        private Label label5;
        private NumericUpDown nudRoiRadius;
        private NumericUpDown nudRoiSpacing;
        private GroupBox groupBox4;
        private Label label6;
        private NumericUpDown nudImageSubtractionFloor;
        private CheckBox cbImageSubtractionEnabled;
        private Label lblAreaPx;
        private Label lblRadiusPx;
        private Label lblSpacingPx;
    }
}
