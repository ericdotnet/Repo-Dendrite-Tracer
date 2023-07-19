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
            cbEnableThreshold = new CheckBox();
            label9 = new Label();
            label10 = new Label();
            nudPixelThresholdMult = new NumericUpDown();
            nudPixelThresholdFloor = new NumericUpDown();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPixelThresholdMult).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPixelThresholdFloor).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(cbEnableThreshold);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(nudPixelThresholdMult);
            groupBox2.Controls.Add(nudPixelThresholdFloor);
            groupBox2.Location = new Point(2, 2);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2);
            groupBox2.Size = new Size(384, 73);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "ROI Threshold";
            // 
            // cbEnableThreshold
            // 
            cbEnableThreshold.AutoSize = true;
            cbEnableThreshold.Checked = true;
            cbEnableThreshold.CheckState = CheckState.Checked;
            cbEnableThreshold.Location = new Point(208, 43);
            cbEnableThreshold.Name = "cbEnableThreshold";
            cbEnableThreshold.Size = new Size(68, 19);
            cbEnableThreshold.TabIndex = 5;
            cbEnableThreshold.Text = "Enabled";
            cbEnableThreshold.UseVisualStyleBackColor = true;
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
            // RoiConfigurator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Margin = new Padding(2);
            Name = "RoiConfigurator";
            Size = new Size(388, 79);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPixelThresholdMult).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPixelThresholdFloor).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox2;
        private Label label9;
        private Label label10;
        private NumericUpDown nudPixelThresholdMult;
        private NumericUpDown nudPixelThresholdFloor;
        private CheckBox cbEnableThreshold;
    }
}
