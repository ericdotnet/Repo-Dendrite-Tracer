using DendriteTracer.Gui.Controls;

namespace DendriteTracer.Gui
{
    partial class RoiInspector
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
            pictureBox1 = new RawPictureBox();
            hScrollBar1 = new HScrollBar();
            formsPlot1 = new ScottPlot.FormsPlot();
            groupBox1 = new GroupBox();
            panel2 = new Panel();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Navy;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 250);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // hScrollBar1
            // 
            hScrollBar1.Dock = DockStyle.Fill;
            hScrollBar1.LargeChange = 1;
            hScrollBar1.Location = new Point(0, 0);
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(236, 42);
            hScrollBar1.TabIndex = 1;
            // 
            // formsPlot1
            // 
            formsPlot1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            formsPlot1.Location = new Point(262, 5);
            formsPlot1.Margin = new Padding(6, 5, 6, 5);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(997, 336);
            formsPlot1.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel2);
            groupBox1.Location = new Point(3, 259);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 82);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Roi (12 of 34)";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(hScrollBar1);
            panel2.Location = new Point(6, 30);
            panel2.Name = "panel2";
            panel2.Size = new Size(238, 44);
            panel2.TabIndex = 10;
            // 
            // RoiInspector
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Controls.Add(formsPlot1);
            Name = "RoiInspector";
            Size = new Size(1265, 344);
            groupBox1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RawPictureBox pictureBox1;
        private HScrollBar hScrollBar1;
        private ScottPlot.FormsPlot formsPlot1;
        private GroupBox groupBox1;
        private Panel panel2;
    }
}
