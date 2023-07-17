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
        SuspendLayout();
        // 
        // imageTracer1
        // 
        imageTracer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        imageTracer1.Location = new Point(12, 12);
        imageTracer1.Name = "imageTracer1";
        imageTracer1.Size = new Size(543, 728);
        imageTracer1.TabIndex = 0;
        // 
        // roiInspector1
        // 
        roiInspector1.Location = new Point(561, 36);
        roiInspector1.Name = "roiInspector1";
        roiInspector1.Size = new Size(393, 496);
        roiInspector1.TabIndex = 1;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1541, 752);
        Controls.Add(roiInspector1);
        Controls.Add(imageTracer1);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    private ImageTracer imageTracer1;
    private RoiInspector roiInspector1;
}
