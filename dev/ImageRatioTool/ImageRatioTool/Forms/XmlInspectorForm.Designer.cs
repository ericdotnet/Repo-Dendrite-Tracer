namespace ImageRatioTool.Forms
{
    partial class XmlInspectorForm
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
            label1 = new Label();
            richTextBox1 = new RichTextBox();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(382, 25);
            label1.TabIndex = 0;
            label1.Text = "Drag/drop a PrairieView XML file to get started";
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(3, 27);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(294, 355);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(richTextBox1);
            groupBox1.Location = new Point(12, 53);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(300, 385);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sequence Times (sec)";
            // 
            // XmlInspectorForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(568, 450);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "XmlInspectorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "XML Inspector";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RichTextBox richTextBox1;
        private GroupBox groupBox1;
    }
}