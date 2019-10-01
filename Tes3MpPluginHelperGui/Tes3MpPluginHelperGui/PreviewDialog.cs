using System;
using System.Drawing;
using System.Windows.Forms;
using Tes3MpPluginHelper;

namespace Tes3MpPluginHelperGui
{
    public partial class PreviewDialog : Form
    {
        public PreviewDialog(DataFile[] datafiles)
        {
            InitializeComponent();
            dataGridView1.DataSource = datafiles;
            
        }

        private void _closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex % 2 == 1)
            {
                var newColor = e.CellStyle.BackColor;
                newColor = Color.FromArgb(newColor.A, newColor.R - 10, newColor.G - 10, newColor.B - 10);
                e.CellStyle.BackColor = newColor;
            }
        }
    }
}
