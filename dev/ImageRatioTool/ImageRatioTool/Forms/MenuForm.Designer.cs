namespace ImageRatioTool.Forms;

partial class MenuForm
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
        btnSquareRoi = new Button();
        label1 = new Label();
        btnDendriteRois = new Button();
        btnXmlInfo = new Button();
        SuspendLayout();
        // 
        // btnSquareRoi
        // 
        btnSquareRoi.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        btnSquareRoi.Location = new Point(37, 110);
        btnSquareRoi.Margin = new Padding(4, 5, 4, 5);
        btnSquareRoi.Name = "btnSquareRoi";
        btnSquareRoi.Size = new Size(365, 66);
        btnSquareRoi.TabIndex = 0;
        btnSquareRoi.Text = "Single Manually-Placed ROI";
        btnSquareRoi.UseVisualStyleBackColor = true;
        btnSquareRoi.Click += btnSquareRoi_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        label1.Location = new Point(37, 41);
        label1.Margin = new Padding(4, 0, 4, 0);
        label1.Name = "label1";
        label1.Size = new Size(736, 32);
        label1.TabIndex = 1;
        label1.Text = "This application measures G/R in multi-frame 2-channel TIF images.";
        // 
        // btnDendriteRois
        // 
        btnDendriteRois.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        btnDendriteRois.Location = new Point(37, 202);
        btnDendriteRois.Margin = new Padding(4, 5, 4, 5);
        btnDendriteRois.Name = "btnDendriteRois";
        btnDendriteRois.Size = new Size(365, 66);
        btnDendriteRois.TabIndex = 3;
        btnDendriteRois.Text = "Multiple ROIs Along a Dendrite";
        btnDendriteRois.UseVisualStyleBackColor = true;
        btnDendriteRois.Click += btnDendriteRois_Click;
        // 
        // btnXmlInfo
        // 
        btnXmlInfo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        btnXmlInfo.Location = new Point(37, 292);
        btnXmlInfo.Margin = new Padding(4, 5, 4, 5);
        btnXmlInfo.Name = "btnXmlInfo";
        btnXmlInfo.Size = new Size(365, 66);
        btnXmlInfo.TabIndex = 4;
        btnXmlInfo.Text = "PrairieView XML Information";
        btnXmlInfo.UseVisualStyleBackColor = true;
        btnXmlInfo.Click += btnXmlInfo_Click;
        // 
        // MenuForm
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(828, 390);
        Controls.Add(btnXmlInfo);
        Controls.Add(btnDendriteRois);
        Controls.Add(label1);
        Controls.Add(btnSquareRoi);
        Margin = new Padding(4, 5, 4, 5);
        Name = "MenuForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Image Ratio Tool";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnSquareRoi;
    private Label label1;
    private Button btnDendriteRois;
    private Button btnXmlInfo;
}