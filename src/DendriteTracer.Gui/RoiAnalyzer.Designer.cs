namespace DendriteTracer.Gui
{
    partial class RoiAnalyzer
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
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(formsPlot1, 0, 0);
            tableLayoutPanel1.Controls.Add(formsPlot2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(860, 587);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // formsPlot1
            // 
            formsPlot1.Dock = DockStyle.Fill;
            formsPlot1.Location = new Point(6, 5);
            formsPlot1.Margin = new Padding(6, 5, 6, 5);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(848, 283);
            formsPlot1.TabIndex = 0;
            // 
            // formsPlot2
            // 
            formsPlot2.Dock = DockStyle.Fill;
            formsPlot2.Location = new Point(6, 298);
            formsPlot2.Margin = new Padding(6, 5, 6, 5);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(848, 284);
            formsPlot2.TabIndex = 1;
            // 
            // RoiAnalyzer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "RoiAnalyzer";
            Size = new Size(860, 587);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ScottPlot.FormsPlot formsPlot1;
        private ScottPlot.FormsPlot formsPlot2;
    }
}
