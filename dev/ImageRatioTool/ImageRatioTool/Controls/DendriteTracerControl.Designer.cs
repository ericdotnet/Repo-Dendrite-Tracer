namespace ImageRatioTool.Controls;

partial class DendriteTracerControl
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
        pictureBox1 = new PictureBox();
        tbRoiSpacing = new TrackBar();
        lblRoiSpacing = new Label();
        lblRoiSize = new Label();
        tbRoiSize = new TrackBar();
        formsPlot1 = new ScottPlot.FormsPlot();
        hScrollBar1 = new HScrollBar();
        btnAnalyzeAllFrames = new Button();
        cbDistributeHorizontally = new CheckBox();
        btnCopyData = new Button();
        btnSaveData = new Button();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)tbRoiSpacing).BeginInit();
        ((System.ComponentModel.ISupportInitialize)tbRoiSize).BeginInit();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.BackColor = SystemColors.ControlDark;
        pictureBox1.Location = new Point(4, 5);
        pictureBox1.Margin = new Padding(4, 5, 4, 5);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(731, 853);
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // tbRoiSpacing
        // 
        tbRoiSpacing.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        tbRoiSpacing.Location = new Point(744, 65);
        tbRoiSpacing.Margin = new Padding(4, 5, 4, 5);
        tbRoiSpacing.Maximum = 100;
        tbRoiSpacing.Minimum = 5;
        tbRoiSpacing.Name = "tbRoiSpacing";
        tbRoiSpacing.Size = new Size(738, 69);
        tbRoiSpacing.TabIndex = 1;
        tbRoiSpacing.Value = 50;
        tbRoiSpacing.Scroll += tbRoiSpacing_Scroll;
        // 
        // lblRoiSpacing
        // 
        lblRoiSpacing.AutoSize = true;
        lblRoiSpacing.Location = new Point(744, 35);
        lblRoiSpacing.Margin = new Padding(4, 0, 4, 0);
        lblRoiSpacing.Name = "lblRoiSpacing";
        lblRoiSpacing.Size = new Size(110, 25);
        lblRoiSpacing.TabIndex = 2;
        lblRoiSpacing.Text = "ROI Spacing";
        // 
        // lblRoiSize
        // 
        lblRoiSize.AutoSize = true;
        lblRoiSize.Location = new Point(744, 132);
        lblRoiSize.Margin = new Padding(4, 0, 4, 0);
        lblRoiSize.Name = "lblRoiSize";
        lblRoiSize.Size = new Size(78, 25);
        lblRoiSize.TabIndex = 4;
        lblRoiSize.Text = "ROI Size";
        // 
        // tbRoiSize
        // 
        tbRoiSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        tbRoiSize.Location = new Point(744, 162);
        tbRoiSize.Margin = new Padding(4, 5, 4, 5);
        tbRoiSize.Maximum = 50;
        tbRoiSize.Minimum = 2;
        tbRoiSize.Name = "tbRoiSize";
        tbRoiSize.Size = new Size(738, 69);
        tbRoiSize.TabIndex = 3;
        tbRoiSize.Value = 20;
        tbRoiSize.Scroll += tbRoiSize_Scroll;
        // 
        // formsPlot1
        // 
        formsPlot1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        formsPlot1.Location = new Point(749, 319);
        formsPlot1.Margin = new Padding(6, 5, 6, 5);
        formsPlot1.Name = "formsPlot1";
        formsPlot1.Size = new Size(737, 583);
        formsPlot1.TabIndex = 5;
        // 
        // hScrollBar1
        // 
        hScrollBar1.LargeChange = 1;
        hScrollBar1.Location = new Point(4, 863);
        hScrollBar1.Name = "hScrollBar1";
        hScrollBar1.Size = new Size(731, 39);
        hScrollBar1.TabIndex = 6;
        hScrollBar1.Scroll += hScrollBar1_Scroll;
        // 
        // btnAnalyzeAllFrames
        // 
        btnAnalyzeAllFrames.Location = new Point(749, 239);
        btnAnalyzeAllFrames.Name = "btnAnalyzeAllFrames";
        btnAnalyzeAllFrames.Size = new Size(112, 70);
        btnAnalyzeAllFrames.TabIndex = 7;
        btnAnalyzeAllFrames.Text = "Analyze All Frames";
        btnAnalyzeAllFrames.UseVisualStyleBackColor = true;
        btnAnalyzeAllFrames.Click += btnAnalyzeAllFrames_Click;
        // 
        // cbDistributeHorizontally
        // 
        cbDistributeHorizontally.AutoSize = true;
        cbDistributeHorizontally.Location = new Point(882, 261);
        cbDistributeHorizontally.Name = "cbDistributeHorizontally";
        cbDistributeHorizontally.Size = new Size(215, 29);
        cbDistributeHorizontally.TabIndex = 8;
        cbDistributeHorizontally.Text = "Distribute Horizontally";
        cbDistributeHorizontally.UseVisualStyleBackColor = true;
        cbDistributeHorizontally.CheckedChanged += cbDistributeHorizontally_CheckedChanged;
        // 
        // btnCopyData
        // 
        btnCopyData.Location = new Point(1103, 241);
        btnCopyData.Name = "btnCopyData";
        btnCopyData.Size = new Size(112, 70);
        btnCopyData.TabIndex = 9;
        btnCopyData.Text = "Copy Data";
        btnCopyData.UseVisualStyleBackColor = true;
        btnCopyData.Click += btnCopyData_Click;
        // 
        // btnSaveData
        // 
        btnSaveData.Location = new Point(1221, 241);
        btnSaveData.Name = "btnSaveData";
        btnSaveData.Size = new Size(112, 70);
        btnSaveData.TabIndex = 10;
        btnSaveData.Text = "Save Data";
        btnSaveData.UseVisualStyleBackColor = true;
        btnSaveData.Click += btnSaveData_Click;
        // 
        // DendriteTracerControl
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(btnSaveData);
        Controls.Add(btnCopyData);
        Controls.Add(cbDistributeHorizontally);
        Controls.Add(btnAnalyzeAllFrames);
        Controls.Add(hScrollBar1);
        Controls.Add(formsPlot1);
        Controls.Add(lblRoiSize);
        Controls.Add(tbRoiSize);
        Controls.Add(lblRoiSpacing);
        Controls.Add(tbRoiSpacing);
        Controls.Add(pictureBox1);
        Margin = new Padding(4, 5, 4, 5);
        Name = "DendriteTracerControl";
        Size = new Size(1486, 907);
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ((System.ComponentModel.ISupportInitialize)tbRoiSpacing).EndInit();
        ((System.ComponentModel.ISupportInitialize)tbRoiSize).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PictureBox pictureBox1;
    private TrackBar tbRoiSpacing;
    private Label lblRoiSpacing;
    private Label lblRoiSize;
    private TrackBar tbRoiSize;
    private ScottPlot.FormsPlot formsPlot1;
    private HScrollBar hScrollBar1;
    private Button btnAnalyzeAllFrames;
    private CheckBox cbDistributeHorizontally;
    private Button btnCopyData;
    private Button btnSaveData;
}
