namespace DendriteTracer.Gui
{
    partial class RoiConfigurator
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
            groupBox2 = new GroupBox();
            label9 = new Label();
            label10 = new Label();
            nudPixelThresholdMult = new NumericUpDown();
            nudPixelThresholdFloor = new NumericUpDown();
            groupBox3 = new GroupBox();
            label3 = new Label();
            nudImageSubtractionFloor = new NumericUpDown();
            cbImageSubtractionEnabled = new CheckBox();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPixelThresholdMult).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPixelThresholdFloor).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudImageSubtractionFloor).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(nudPixelThresholdMult);
            groupBox2.Controls.Add(nudPixelThresholdFloor);
            groupBox2.Location = new Point(2, 83);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2);
            groupBox2.Size = new Size(241, 73);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "ROI Threshold";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(116, 23);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(59, 15);
            label9.TabIndex = 4;
            label9.Text = "Threshold";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(18, 23);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(55, 15);
            label10.TabIndex = 3;
            label10.Text = "Floor (%)";
            // 
            // nudPixelThresholdMult
            // 
            nudPixelThresholdMult.Location = new Point(116, 40);
            nudPixelThresholdMult.Margin = new Padding(2);
            nudPixelThresholdMult.Name = "nudPixelThresholdMult";
            nudPixelThresholdMult.Size = new Size(74, 23);
            nudPixelThresholdMult.TabIndex = 1;
            nudPixelThresholdMult.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // nudPixelThresholdFloor
            // 
            nudPixelThresholdFloor.Location = new Point(18, 40);
            nudPixelThresholdFloor.Margin = new Padding(2);
            nudPixelThresholdFloor.Name = "nudPixelThresholdFloor";
            nudPixelThresholdFloor.Size = new Size(74, 23);
            nudPixelThresholdFloor.TabIndex = 0;
            nudPixelThresholdFloor.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(nudImageSubtractionFloor);
            groupBox3.Controls.Add(cbImageSubtractionEnabled);
            groupBox3.Location = new Point(2, 2);
            groupBox3.Margin = new Padding(2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(2);
            groupBox3.Size = new Size(241, 77);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Noise Floor Subtraction";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 24);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 12;
            label3.Text = "Floor (%)";
            // 
            // nudImageSubtractionFloor
            // 
            nudImageSubtractionFloor.Location = new Point(18, 43);
            nudImageSubtractionFloor.Margin = new Padding(2);
            nudImageSubtractionFloor.Name = "nudImageSubtractionFloor";
            nudImageSubtractionFloor.Size = new Size(74, 23);
            nudImageSubtractionFloor.TabIndex = 11;
            nudImageSubtractionFloor.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // cbImageSubtractionEnabled
            // 
            cbImageSubtractionEnabled.AutoSize = true;
            cbImageSubtractionEnabled.Location = new Point(116, 43);
            cbImageSubtractionEnabled.Margin = new Padding(2);
            cbImageSubtractionEnabled.Name = "cbImageSubtractionEnabled";
            cbImageSubtractionEnabled.Size = new Size(61, 19);
            cbImageSubtractionEnabled.TabIndex = 10;
            cbImageSubtractionEnabled.Text = "Enable";
            cbImageSubtractionEnabled.UseVisualStyleBackColor = true;
            // 
            // UserInputPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Margin = new Padding(2);
            Name = "UserInputPanel";
            Size = new Size(245, 159);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPixelThresholdMult).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPixelThresholdFloor).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudImageSubtractionFloor).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox2;
        private Label label9;
        private Label label10;
        private NumericUpDown nudPixelThresholdMult;
        private NumericUpDown nudPixelThresholdFloor;
        private GroupBox groupBox3;
        private Label label3;
        private NumericUpDown nudImageSubtractionFloor;
        private CheckBox cbImageSubtractionEnabled;
    }
}
