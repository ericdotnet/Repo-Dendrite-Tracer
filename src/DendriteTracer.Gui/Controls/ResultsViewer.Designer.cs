namespace DendriteTracer.Gui
{
    partial class ResultsViewer
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
            tableLayoutPanel1 = new TableLayoutPanel();
            formsPlot1 = new ScottPlot.FormsPlot();
            formsPlot2 = new ScottPlot.FormsPlot();
            panel1 = new Panel();
            cbOverTime = new CheckBox();
            cbAllFrames = new CheckBox();
            button3 = new Button();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(formsPlot1, 0, 0);
            tableLayoutPanel1.Controls.Add(formsPlot2, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 83F));
            tableLayoutPanel1.Size = new Size(1033, 923);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // formsPlot1
            // 
            formsPlot1.Dock = DockStyle.Fill;
            formsPlot1.Location = new Point(6, 5);
            formsPlot1.Margin = new Padding(6, 5, 6, 5);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(1021, 410);
            formsPlot1.TabIndex = 0;
            // 
            // formsPlot2
            // 
            formsPlot2.Dock = DockStyle.Fill;
            formsPlot2.Location = new Point(6, 425);
            formsPlot2.Margin = new Padding(6, 5, 6, 5);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(1021, 410);
            formsPlot2.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(cbOverTime);
            panel1.Controls.Add(cbAllFrames);
            panel1.Controls.Add(button3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(4, 845);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1025, 73);
            panel1.TabIndex = 2;
            // 
            // cbOverTime
            // 
            cbOverTime.AutoSize = true;
            cbOverTime.Location = new Point(150, 23);
            cbOverTime.Name = "cbOverTime";
            cbOverTime.Size = new Size(119, 29);
            cbOverTime.TabIndex = 9;
            cbOverTime.Text = "Over Time";
            cbOverTime.UseVisualStyleBackColor = true;
            // 
            // cbAllFrames
            // 
            cbAllFrames.AutoSize = true;
            cbAllFrames.Location = new Point(24, 23);
            cbAllFrames.Name = "cbAllFrames";
            cbAllFrames.Size = new Size(120, 29);
            cbAllFrames.TabIndex = 8;
            cbAllFrames.Text = "All Frames";
            cbAllFrames.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Location = new Point(902, 5);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(119, 63);
            button3.TabIndex = 2;
            button3.Text = "Save";
            button3.UseVisualStyleBackColor = true;
            // 
            // ResultsViewer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ResultsViewer";
            Size = new Size(1033, 923);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ScottPlot.FormsPlot formsPlot1;
        private ScottPlot.FormsPlot formsPlot2;
        private Panel panel1;
        private Button button3;
        private CheckBox cbOverTime;
        private CheckBox cbAllFrames;
    }
}
