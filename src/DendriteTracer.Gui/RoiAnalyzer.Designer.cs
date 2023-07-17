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
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            nudRatioMax = new NumericUpDown();
            nudRawMax = new NumericUpDown();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudRatioMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRawMax).BeginInit();
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
            tableLayoutPanel1.Margin = new Padding(2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(723, 554);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // formsPlot1
            // 
            formsPlot1.Dock = DockStyle.Fill;
            formsPlot1.Location = new Point(4, 3);
            formsPlot1.Margin = new Padding(4, 3, 4, 3);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(715, 246);
            formsPlot1.TabIndex = 0;
            // 
            // formsPlot2
            // 
            formsPlot2.Dock = DockStyle.Fill;
            formsPlot2.Location = new Point(4, 255);
            formsPlot2.Margin = new Padding(4, 3, 4, 3);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(715, 246);
            formsPlot2.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(nudRatioMax);
            panel1.Controls.Add(nudRawMax);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 507);
            panel1.Name = "panel1";
            panel1.Size = new Size(717, 44);
            panel1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(164, 16);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 6;
            label2.Text = "Ratio max:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 16);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 5;
            label1.Text = "PMT max:";
            // 
            // nudRatioMax
            // 
            nudRatioMax.Location = new Point(233, 14);
            nudRatioMax.Maximum = new decimal(new int[] { 900, 0, 0, 0 });
            nudRatioMax.Name = "nudRatioMax";
            nudRatioMax.Size = new Size(63, 23);
            nudRatioMax.TabIndex = 7;
            nudRatioMax.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // nudRawMax
            // 
            nudRawMax.Location = new Point(78, 14);
            nudRawMax.Maximum = new decimal(new int[] { 9000, 0, 0, 0 });
            nudRawMax.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudRawMax.Name = "nudRawMax";
            nudRawMax.Size = new Size(63, 23);
            nudRawMax.TabIndex = 4;
            nudRawMax.Value = new decimal(new int[] { 8192, 0, 0, 0 });
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.Location = new Point(535, 3);
            button4.Name = "button4";
            button4.Size = new Size(90, 38);
            button4.TabIndex = 3;
            button4.Text = "Copy Ratios Over Time";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Location = new Point(631, 3);
            button3.Name = "button3";
            button3.Size = new Size(83, 38);
            button3.TabIndex = 2;
            button3.Text = "Save As...";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(450, 3);
            button2.Name = "button2";
            button2.Size = new Size(79, 38);
            button2.TabIndex = 1;
            button2.Text = "Copy G, R, and Ratio";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(369, 3);
            button1.Name = "button1";
            button1.Size = new Size(75, 38);
            button1.TabIndex = 0;
            button1.Text = "Copy Ratio";
            button1.UseVisualStyleBackColor = true;
            // 
            // RoiAnalyzer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(2);
            Name = "RoiAnalyzer";
            Size = new Size(723, 554);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudRatioMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRawMax).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ScottPlot.FormsPlot formsPlot1;
        private ScottPlot.FormsPlot formsPlot2;
        private Panel panel1;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button4;
        private Label label1;
        private NumericUpDown nudRawMax;
        private NumericUpDown nudRatioMax;
        private Label label2;
    }
}
