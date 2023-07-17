using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageRatioTool.Forms
{
    public partial class XmlInspectorForm : Form
    {
        public XmlInspectorForm()
        {
            InitializeComponent();
            AllowDrop = true;
            DragEnter += OnDragEnter;
            DragDrop += OnDragDrop;
        }

        private void OnDragDrop(object? sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data!.GetData(DataFormats.FileDrop)!;
            LoadFile(paths.First());
        }

        private void OnDragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data!.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void LoadFile(string xmlFilePath)
        {
            double[] seconds = XmlFileOperations.GetSequenceTimes(xmlFilePath);
            richTextBox1.Text = string.Join("\n", seconds.Select(s => s.ToString()));
        }
    }
}
