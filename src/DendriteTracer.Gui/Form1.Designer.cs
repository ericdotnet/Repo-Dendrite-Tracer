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
        userInputs1 = new UserInputs();
        SuspendLayout();
        // 
        // imageTracer1
        // 
        imageTracer1.AllowDrop = true;
        imageTracer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        imageTracer1.Location = new Point(11, 12);
        imageTracer1.Margin = new Padding(1, 2, 1, 2);
        imageTracer1.Name = "imageTracer1";
        imageTracer1.Size = new Size(543, 654);
        imageTracer1.TabIndex = 0;
        // 
        // roiInspector1
        // 
        roiInspector1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        roiInspector1.Location = new Point(561, 37);
        roiInspector1.Margin = new Padding(1, 2, 1, 2);
        roiInspector1.Name = "roiInspector1";
        roiInspector1.Size = new Size(1113, 385);
        roiInspector1.TabIndex = 1;
        // 
        // roiAnalyzer1
        // 
        roiAnalyzer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        roiAnalyzer1.Location = new Point(561, 425);
        roiAnalyzer1.Margin = new Padding(1, 2, 1, 2);
        roiAnalyzer1.Name = "roiAnalyzer1";
        roiAnalyzer1.Size = new Size(1113, 885);
        roiAnalyzer1.TabIndex = 2;
        // 
        // userInputs1
        // 
        userInputs1.Location = new Point(15, 596);
        userInputs1.Name = "userInputs1";
        userInputs1.Size = new Size(439, 615);
        userInputs1.TabIndex = 3;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1686, 1322);
        Controls.Add(userInputs1);
        Controls.Add(roiAnalyzer1);
        Controls.Add(roiInspector1);
        Controls.Add(imageTracer1);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Dendrite Tracer";
        ResumeLayout(false);
    }

    #endregion

    private ImageTracer imageTracer1;
    private RoiInspector roiInspector1;
    private RoiAnalyzer roiAnalyzer1;
    private UserInputs userInputs1;
}
