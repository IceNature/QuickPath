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
    public partial class FormMain : Form
    {
        private EnvironmentPath ep;
        public FormMain()
        {
            InitializeComponent();
            ep = new EnvironmentPath();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addToListBox(ep.Paths.ToArray());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndices.Count != 0)
                buttonDelete.Enabled = true;
            else
                buttonDelete.Enabled = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {
                List<object> currentSelected = new List<object>();
                foreach (var m in listBox1.SelectedItems)
                {
                    currentSelected.Add(m);
                }
                foreach (var m in currentSelected)
                {
                    listBox1.Items.Remove(m);
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAdd AddItem = new FormAdd();
            AddItem.ShowDialog();
            if (AddItem.AddItems.Count != 0)
                addToListBox(AddItem.AddItems.ToArray());
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ep.Paths.Clear();
            foreach (var m in listBox1.Items)
            {
                ep.Paths.Add(m.ToString());
            }
            ep.ApplyChange();
            MessageBox.Show("完成！", "保存环境变量", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void widgets_DragEnter(object sender, DragEventArgs e)
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

        private void widgets_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                addToListBox((string[])e.Data.GetData(DataFormats.FileDrop));
            }
        }

        private void addToListBox(string[] directorys)
        {
            listBox1.Items.AddRange(CommonMethods.DeleteInexistentDir(directorys).ToArray());
        }
    }
}
