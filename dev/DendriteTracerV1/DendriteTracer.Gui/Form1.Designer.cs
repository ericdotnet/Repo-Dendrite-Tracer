namespace DendriteTracer.Gui;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        imageTracerControl1 = new ImageTracerControl();
        hScrollBar1 = new HScrollBar();
        panel1 = new Panel();
        nudRoiRadius = new NumericUpDown();
        label1 = new Label();
        label2 = new Label();
        nudRoiSpacing = new NumericUpDown();
        nudMicronsPerPx = new NumericUpDown();
        label3 = new Label();
        hsbRoi = new HScrollBar();
        pbRoi = new PictureBox();
        panel2 = new Panel();
        gbRoi = new GroupBox();
        panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudRoiRadius).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudRoiSpacing).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudMicronsPerPx).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbRoi).BeginInit();
        panel2.SuspendLayout();
        gbRoi.SuspendLayout();
        SuspendLayout();
        // 
        // imageTracerControl1
        // 
        imageTracerControl1.BackColor = SystemColors.ControlDark;
        imageTracerControl1.Location = new Point(17, 20);
        imageTracerControl1.Margin = new Padding(4, 5, 4, 5);
        imageTracerControl1.Name = "imageTracerControl1";
        imageTracerControl1.RoiRadius = 15;
        imageTracerControl1.RoiSpacing = 5;
        imageTracerControl1.Size = new Size(714, 833);
        imageTracerControl1.TabIndex = 0;
        // 
        // hScrollBar1
        // 
        hScrollBar1.Dock = DockStyle.Fill;
        hScrollBar1.Location = new Point(0, 0);
        hScrollBar1.Name = "hScrollBar1";
        hScrollBar1.Size = new Size(711, 38);
        hScrollBar1.TabIndex = 1;
        // 
        // panel1
        // 
        panel1.BorderStyle = BorderStyle.FixedSingle;
        panel1.Controls.Add(hScrollBar1);
        panel1.Location = new Point(17, 863);
        panel1.Margin = new Padding(4, 5, 4, 5);
        panel1.Name = "panel1";
        panel1.Size = new Size(713, 40);
        panel1.TabIndex = 2;
        // 
        // nudRoiRadius
        // 
        nudRoiRadius.Location = new Point(1088, 48);
        nudRoiRadius.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudRoiRadius.Name = "nudRoiRadius";
        nudRoiRadius.Size = new Size(100, 31);
        nudRoiRadius.TabIndex = 4;
        nudRoiRadius.Value = new decimal(new int[] { 5, 0, 0, 0 });
        nudRoiRadius.ValueChanged += nudRoiRadius_ValueChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(1088, 20);
        label1.Name = "label1";
        label1.Size = new Size(100, 25);
        label1.TabIndex = 5;
        label1.Text = "ROI Radius";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(935, 20);
        label2.Name = "label2";
        label2.Size = new Size(110, 25);
        label2.TabIndex = 6;
        label2.Text = "ROI Spacing";
        // 
        // nudRoiSpacing
        // 
        nudRoiSpacing.Location = new Point(935, 48);
        nudRoiSpacing.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudRoiSpacing.Name = "nudRoiSpacing";
        nudRoiSpacing.Size = new Size(100, 31);
        nudRoiSpacing.TabIndex = 7;
        nudRoiSpacing.Value = new decimal(new int[] { 5, 0, 0, 0 });
        nudRoiSpacing.ValueChanged += nudRoiSpacing_ValueChanged;
        // 
        // nudMicronsPerPx
        // 
        nudMicronsPerPx.DecimalPlaces = 5;
        nudMicronsPerPx.Location = new Point(778, 48);
        nudMicronsPerPx.Name = "nudMicronsPerPx";
        nudMicronsPerPx.Size = new Size(126, 31);
        nudMicronsPerPx.TabIndex = 8;
        nudMicronsPerPx.Value = new decimal(new int[] { 117879, 0, 0, 327680 });
        nudMicronsPerPx.ValueChanged += nudMicronsPerPx_ValueChanged;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(778, 20);
        label3.Name = "label3";
        label3.Size = new Size(111, 25);
        label3.TabIndex = 9;
        label3.Text = "microns / px";
        // 
        // hsbRoi
        // 
        hsbRoi.Dock = DockStyle.Fill;
        hsbRoi.Location = new Point(0, 0);
        hsbRoi.Name = "hsbRoi";
        hsbRoi.Size = new Size(254, 30);
        hsbRoi.TabIndex = 10;
        // 
        // pbRoi
        // 
        pbRoi.BackColor = SystemColors.ControlDark;
        pbRoi.BorderStyle = BorderStyle.Fixed3D;
        pbRoi.Location = new Point(6, 34);
        pbRoi.Name = "pbRoi";
        pbRoi.Size = new Size(256, 256);
        pbRoi.TabIndex = 11;
        pbRoi.TabStop = false;
        // 
        // panel2
        // 
        panel2.BorderStyle = BorderStyle.FixedSingle;
        panel2.Controls.Add(hsbRoi);
        panel2.Location = new Point(6, 296);
        panel2.Name = "panel2";
        panel2.Size = new Size(256, 32);
        panel2.TabIndex = 12;
        // 
        // gbRoi
        // 
        gbRoi.Controls.Add(pbRoi);
        gbRoi.Controls.Add(panel2);
        gbRoi.Location = new Point(777, 118);
        gbRoi.Name = "gbRoi";
        gbRoi.Size = new Size(268, 337);
        gbRoi.TabIndex = 13;
        gbRoi.TabStop = false;
        gbRoi.Text = "ROI 5 of 9";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1744, 932);
        Controls.Add(gbRoi);
        Controls.Add(label3);
        Controls.Add(nudMicronsPerPx);
        Controls.Add(nudRoiSpacing);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(nudRoiRadius);
        Controls.Add(panel1);
        Controls.Add(imageTracerControl1);
        Margin = new Padding(4, 5, 4, 5);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Form1";
        panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)nudRoiRadius).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudRoiSpacing).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudMicronsPerPx).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbRoi).EndInit();
        panel2.ResumeLayout(false);
        gbRoi.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ImageTracerControl imageTracerControl1;
    private HScrollBar hScrollBar1;
    private Panel panel1;
    private NumericUpDown nudRoiRadius;
    private Label label1;
    private Label label2;
    private NumericUpDown nudRoiSpacing;
    private NumericUpDown nudMicronsPerPx;
    private Label label3;
    private HScrollBar hsbRoi;
    private PictureBox pbRoi;
    private Panel panel2;
    private GroupBox gbRoi;
}
