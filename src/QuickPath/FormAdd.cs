using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickPath
{
    public partial class FormAdd : Form
    {
        public List<string> AddItems { get; private set; }

        public FormAdd()
        {
            InitializeComponent();
            AddItems = new List<string>();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
                buttonOK.Enabled = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            AddItems.AddRange(textBox1.Text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text += folderBrowser.SelectedPath;
                textBox1.Text += ";";
            }
        }
        private void addToTextBox(string[] directorys)
        {
            List<string> FilePaths = new List<string>(directorys);
            StringBuilder DragPathText = new StringBuilder();
            FilePaths.ForEach(m => DragPathText.Append(m).Append(";"));
            textBox1.Text += DragPathText.ToString();
        }
        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                addToTextBox((string[])e.Data.GetData(DataFormats.FileDrop));
            }
        }
    }
}
