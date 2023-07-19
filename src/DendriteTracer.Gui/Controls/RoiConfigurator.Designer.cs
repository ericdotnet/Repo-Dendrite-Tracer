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
            groupBox2.Controls.Add(cbEnableThreshold);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(nudPixelThresholdMult);
            groupBox2.Controls.Add(nudPixelThresholdFloor);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(554, 132);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "ROI Threshold";
            // 
            // cbEnableThreshold
            // 
            cbEnableThreshold.AutoSize = true;
            cbEnableThreshold.Location = new Point(297, 72);
            cbEnableThreshold.Margin = new Padding(4, 5, 4, 5);
            cbEnableThreshold.Name = "cbEnableThreshold";
            cbEnableThreshold.Size = new Size(101, 29);
            cbEnableThreshold.TabIndex = 5;
            cbEnableThreshold.Text = "Enabled";
            cbEnableThreshold.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(166, 38);
            label9.Name = "label9";
            label9.Size = new Size(90, 25);
            label9.TabIndex = 4;
            label9.Text = "Threshold";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(26, 38);
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
            nudPixelThresholdMult.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // nudPixelThresholdFloor
            // 
            nudPixelThresholdFloor.Location = new Point(26, 67);
            nudPixelThresholdFloor.Name = "nudPixelThresholdFloor";
            nudPixelThresholdFloor.Size = new Size(106, 31);
            nudPixelThresholdFloor.TabIndex = 0;
            nudPixelThresholdFloor.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // RoiConfigurator
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Name = "RoiConfigurator";
            Size = new Size(554, 132);
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
