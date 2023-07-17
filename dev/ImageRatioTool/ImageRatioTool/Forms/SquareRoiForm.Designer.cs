namespace ImageRatioTool.Forms;

partial class SquareRoiForm
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
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.formsPlot2 = new ScottPlot.FormsPlot();
            this.btnSelectTif = new System.Windows.Forms.Button();
            this.tSeriesRoiSelector1 = new ImageRatioTool.TSeriesRoiSelector();
            this.formsPlot3 = new ScottPlot.FormsPlot();
            this.btnAnalyzeAllFrames = new System.Windows.Forms.Button();
            this.btnCopyResults = new System.Windows.Forms.Button();
            this.btnCopyImage = new System.Windows.Forms.Button();
            this.tbThreshold = new System.Windows.Forms.TrackBar();
            this.lblThreshold = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // formsPlot1
            // 
            this.formsPlot1.Location = new System.Drawing.Point(382, 7);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(400, 251);
            this.formsPlot1.TabIndex = 3;
            // 
            // formsPlot2
            // 
            this.formsPlot2.Location = new System.Drawing.Point(790, 8);
            this.formsPlot2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.formsPlot2.Name = "formsPlot2";
            this.formsPlot2.Size = new System.Drawing.Size(400, 250);
            this.formsPlot2.TabIndex = 4;
            // 
            // btnSelectTif
            // 
            this.btnSelectTif.Location = new System.Drawing.Point(8, 7);
            this.btnSelectTif.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectTif.Name = "btnSelectTif";
            this.btnSelectTif.Size = new System.Drawing.Size(104, 31);
            this.btnSelectTif.TabIndex = 9;
            this.btnSelectTif.Text = "Select TIF";
            this.btnSelectTif.UseVisualStyleBackColor = true;
            this.btnSelectTif.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // tSeriesRoiSelector1
            // 
            this.tSeriesRoiSelector1.Location = new System.Drawing.Point(8, 42);
            this.tSeriesRoiSelector1.Margin = new System.Windows.Forms.Padding(1);
            this.tSeriesRoiSelector1.Name = "tSeriesRoiSelector1";
            this.tSeriesRoiSelector1.Size = new System.Drawing.Size(367, 353);
            this.tSeriesRoiSelector1.TabIndex = 10;
            this.tSeriesRoiSelector1.Threshold = 5D;
            // 
            // formsPlot3
            // 
            this.formsPlot3.Location = new System.Drawing.Point(382, 264);
            this.formsPlot3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.formsPlot3.Name = "formsPlot3";
            this.formsPlot3.Size = new System.Drawing.Size(400, 131);
            this.formsPlot3.TabIndex = 11;
            // 
            // btnAnalyzeAllFrames
            // 
            this.btnAnalyzeAllFrames.Location = new System.Drawing.Point(819, 342);
            this.btnAnalyzeAllFrames.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnalyzeAllFrames.Name = "btnAnalyzeAllFrames";
            this.btnAnalyzeAllFrames.Size = new System.Drawing.Size(86, 41);
            this.btnAnalyzeAllFrames.TabIndex = 12;
            this.btnAnalyzeAllFrames.Text = "Analyze All Frames";
            this.btnAnalyzeAllFrames.UseVisualStyleBackColor = true;
            this.btnAnalyzeAllFrames.Click += new System.EventHandler(this.btnAnalyzeAllFrames_Click);
            // 
            // btnCopyResults
            // 
            this.btnCopyResults.Location = new System.Drawing.Point(909, 342);
            this.btnCopyResults.Margin = new System.Windows.Forms.Padding(2);
            this.btnCopyResults.Name = "btnCopyResults";
            this.btnCopyResults.Size = new System.Drawing.Size(86, 41);
            this.btnCopyResults.TabIndex = 13;
            this.btnCopyResults.Text = "Copy to Clipboard";
            this.btnCopyResults.UseVisualStyleBackColor = true;
            this.btnCopyResults.Click += new System.EventHandler(this.btnCopyResults_Click);
            // 
            // btnCopyImage
            // 
            this.btnCopyImage.Location = new System.Drawing.Point(116, 7);
            this.btnCopyImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnCopyImage.Name = "btnCopyImage";
            this.btnCopyImage.Size = new System.Drawing.Size(104, 31);
            this.btnCopyImage.TabIndex = 14;
            this.btnCopyImage.Text = "Copy Image";
            this.btnCopyImage.UseVisualStyleBackColor = true;
            this.btnCopyImage.Click += new System.EventHandler(this.btnCopyImage_Click);
            // 
            // tbThreshold
            // 
            this.tbThreshold.LargeChange = 20;
            this.tbThreshold.Location = new System.Drawing.Point(819, 292);
            this.tbThreshold.Maximum = 100;
            this.tbThreshold.Minimum = 10;
            this.tbThreshold.Name = "tbThreshold";
            this.tbThreshold.Size = new System.Drawing.Size(369, 45);
            this.tbThreshold.SmallChange = 5;
            this.tbThreshold.TabIndex = 15;
            this.tbThreshold.Value = 50;
            this.tbThreshold.Scroll += new System.EventHandler(this.tbThreshold_Scroll);
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Location = new System.Drawing.Point(819, 274);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(80, 15);
            this.lblThreshold.TabIndex = 16;
            this.lblThreshold.Text = "Threshold: 5.0";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 404);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.tbThreshold);
            this.Controls.Add(this.btnCopyImage);
            this.Controls.Add(this.btnCopyResults);
            this.Controls.Add(this.btnAnalyzeAllFrames);
            this.Controls.Add(this.formsPlot3);
            this.Controls.Add(this.tSeriesRoiSelector1);
            this.Controls.Add(this.btnSelectTif);
            this.Controls.Add(this.formsPlot2);
            this.Controls.Add(this.formsPlot1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Ratio Tool";
            ((System.ComponentModel.ISupportInitialize)(this.tbThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private ScottPlot.FormsPlot formsPlot1;
    private ScottPlot.FormsPlot formsPlot2;
    private Button btnSelectTif;
    private TSeriesRoiSelector tSeriesRoiSelector1;
    private ScottPlot.FormsPlot formsPlot3;
    private Button btnAnalyzeAllFrames;
    private Button btnCopyResults;
    private Button btnCopyImage;
    private TrackBar tbThreshold;
    private Label lblThreshold;
}
