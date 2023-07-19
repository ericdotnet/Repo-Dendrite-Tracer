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
        roiConfigurator1 = new RoiConfigurator();
        resultsViewer1 = new ResultsViewer();
        SuspendLayout();
        // 
        // imageTracer1
        // 
        imageTracer1.AllowDrop = true;
        imageTracer1.Location = new Point(8, 7);
        imageTracer1.Margin = new Padding(1);
        imageTracer1.Name = "imageTracer1";
        imageTracer1.Size = new Size(380, 572);
        imageTracer1.TabIndex = 0;
        // 
        // roiInspector1
        // 
        roiInspector1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        roiInspector1.Location = new Point(393, 18);
        roiInspector1.Margin = new Padding(1);
        roiInspector1.Name = "roiInspector1";
        roiInspector1.Size = new Size(779, 231);
        roiInspector1.TabIndex = 1;
        // 
        // roiConfigurator1
        // 
        roiConfigurator1.Location = new Point(8, 578);
        roiConfigurator1.Margin = new Padding(2);
        roiConfigurator1.Name = "roiConfigurator1";
        roiConfigurator1.Size = new Size(362, 160);
        roiConfigurator1.TabIndex = 2;
        // 
        // resultsViewer1
        // 
        resultsViewer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        resultsViewer1.Location = new Point(391, 256);
        resultsViewer1.Margin = new Padding(2);
        resultsViewer1.Name = "resultsViewer1";
        resultsViewer1.Size = new Size(778, 627);
        resultsViewer1.TabIndex = 3;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1180, 894);
        Controls.Add(resultsViewer1);
        Controls.Add(roiConfigurator1);
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
    private ResultsViewer roiAnalyzer1;
    private RoiConfigurator userInputs1;
    private RoiConfigurator roiConfigurator1;
    private ResultsViewer resultsViewer1;
}
