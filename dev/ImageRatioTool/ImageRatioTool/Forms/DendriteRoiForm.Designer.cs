namespace ImageRatioTool.Forms;

partial class DendriteRoiForm
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        dendriteTracerControl1 = new Controls.DendriteTracerControl();
        SuspendLayout();
        // 
        // dendriteTracerControl1
        // 
        dendriteTracerControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dendriteTracerControl1.Location = new Point(17, 20);
        dendriteTracerControl1.Margin = new Padding(6, 8, 6, 8);
        dendriteTracerControl1.Name = "dendriteTracerControl1";
        dendriteTracerControl1.Size = new Size(1565, 900);
        dendriteTracerControl1.TabIndex = 0;
        // 
        // DendriteRoiForm
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1597, 937);
        Controls.Add(dendriteTracerControl1);
        Margin = new Padding(4, 5, 4, 5);
        Name = "DendriteRoiForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Image Ratio Tool";
        ResumeLayout(false);
    }

    #endregion

    private Controls.DendriteTracerControl dendriteTracerControl1;
}