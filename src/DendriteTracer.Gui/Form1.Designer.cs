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
        imageTracer1 = new ImageTracer();
        roiInspector1 = new RoiInspector();
        roiAnalyzer1 = new RoiAnalyzer();
        SuspendLayout();
        // 
        // imageTracer1
        // 
        imageTracer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        imageTracer1.Location = new Point(8, 7);
        imageTracer1.Margin = new Padding(1);
        imageTracer1.Name = "imageTracer1";
        imageTracer1.Size = new Size(380, 779);
        imageTracer1.TabIndex = 0;
        // 
        // roiInspector1
        // 
        roiInspector1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        roiInspector1.Location = new Point(393, 22);
        roiInspector1.Margin = new Padding(1);
        roiInspector1.Name = "roiInspector1";
        roiInspector1.Size = new Size(779, 231);
        roiInspector1.TabIndex = 1;
        // 
        // roiAnalyzer1
        // 
        roiAnalyzer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        roiAnalyzer1.Location = new Point(393, 255);
        roiAnalyzer1.Margin = new Padding(1);
        roiAnalyzer1.Name = "roiAnalyzer1";
        roiAnalyzer1.Size = new Size(779, 531);
        roiAnalyzer1.TabIndex = 2;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1180, 793);
        Controls.Add(roiAnalyzer1);
        Controls.Add(roiInspector1);
        Controls.Add(imageTracer1);
        Margin = new Padding(2);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Dendrite Tracer";
        ResumeLayout(false);
    }

    #endregion

    private ImageTracer imageTracer1;
    private RoiInspector roiInspector1;
    private RoiAnalyzer roiAnalyzer1;
}
