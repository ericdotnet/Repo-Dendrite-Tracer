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
            cbRoiCirular = new CheckBox();
            label4 = new Label();
            label5 = new Label();
            nudRoiRadius = new NumericUpDown();
            nudRoiSpacing = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudBrightness).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudRoiRadius).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRoiSpacing).BeginInit();
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
            hScrollBar1.Dock = DockStyle.Fill;
            hScrollBar1.LargeChange = 1;
            hScrollBar1.Location = new Point(0, 0);
            hScrollBar1.Maximum = 10;
            hScrollBar1.Minimum = 1;
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(355, 28);
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
            // nudBrightness
            // 
            nudBrightness.DecimalPlaces = 1;
            nudBrightness.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            nudBrightness.Location = new Point(75, 22);
            nudBrightness.Name = "nudBrightness";
            nudBrightness.Size = new Size(63, 23);
            nudBrightness.TabIndex = 3;
            nudBrightness.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 24);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 4;
            label2.Text = "Brightness";
            // 
            // cbRois
            // 
            cbRois.AutoSize = true;
            cbRois.Checked = true;
            cbRois.CheckState = CheckState.Checked;
            cbRois.Location = new Point(231, 25);
            cbRois.Name = "cbRois";
            cbRois.Size = new Size(50, 19);
            cbRois.TabIndex = 5;
            cbRois.Text = "ROIs";
            cbRois.UseVisualStyleBackColor = true;
            // 
            // cbSpines
            // 
            cbSpines.AutoSize = true;
            cbSpines.Checked = true;
            cbSpines.CheckState = CheckState.Checked;
            cbSpines.Location = new Point(165, 25);
            cbSpines.Name = "cbSpines";
            cbSpines.Size = new Size(60, 19);
            cbSpines.TabIndex = 6;
            cbSpines.Text = "Spines";
            cbSpines.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(hScrollBar1);
            panel1.Location = new Point(3, 329);
            panel1.Name = "panel1";
            panel1.Size = new Size(357, 30);
            panel1.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(nudBrightness);
            groupBox1.Controls.Add(cbSpines);
            groupBox1.Controls.Add(cbRois);
            groupBox1.Location = new Point(4, 433);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(356, 57);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Display";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(btnSelectFile);
            groupBox2.Location = new Point(4, 365);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(355, 62);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Load Data";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlDark;
            label3.Location = new Point(128, 32);
            label3.Name = "label3";
            label3.Size = new Size(129, 15);
            label3.TabIndex = 11;
            label3.Text = "or drag/drop a file here";
            // 
            // btnSelectFile
            // 
            btnSelectFile.Location = new Point(12, 28);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(75, 23);
            btnSelectFile.TabIndex = 10;
            btnSelectFile.Text = "Select File";
            btnSelectFile.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(cbRoiCirular);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(nudRoiRadius);
            groupBox3.Controls.Add(nudRoiSpacing);
            groupBox3.Location = new Point(2, 495);
            groupBox3.Margin = new Padding(2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(2);
            groupBox3.Size = new Size(359, 72);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "ROI Dimensions";
            // 
            // cbRoiCirular
            // 
            cbRoiCirular.AutoSize = true;
            cbRoiCirular.Checked = true;
            cbRoiCirular.CheckState = CheckState.Checked;
            cbRoiCirular.Location = new Point(214, 38);
            cbRoiCirular.Margin = new Padding(2);
            cbRoiCirular.Name = "cbRoiCirular";
            cbRoiCirular.Size = new Size(67, 19);
            cbRoiCirular.TabIndex = 9;
            cbRoiCirular.Text = "Circular";
            cbRoiCirular.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(115, 21);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 4;
            label4.Text = "Radius (µm)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 21);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 3;
            label5.Text = "Spacing (µm)";
            // 
            // nudRoiRadius
            // 
            nudRoiRadius.Location = new Point(116, 39);
            nudRoiRadius.Margin = new Padding(2);
            nudRoiRadius.Name = "nudRoiRadius";
            nudRoiRadius.Size = new Size(74, 23);
            nudRoiRadius.TabIndex = 1;
            nudRoiRadius.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // nudRoiSpacing
            // 
            nudRoiSpacing.Location = new Point(18, 39);
            nudRoiSpacing.Margin = new Padding(2);
            nudRoiSpacing.Name = "nudRoiSpacing";
            nudRoiSpacing.Size = new Size(74, 23);
            nudRoiSpacing.TabIndex = 0;
            nudRoiSpacing.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // ImageTracer
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Margin = new Padding(2);
            Name = "ImageTracer";
            Size = new Size(363, 569);
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
    }
}
