namespace Tes3MpPluginHelperGui
{
    partial class PreviewDialog
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
            dataGridView1 = new DataGridView();
            _nameColumn = new DataGridViewTextBoxColumn();
            _checksumColumn = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            _closeButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { _nameColumn, _checksumColumn });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(350, 384);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.CellPainting += dataGridView1_CellPainting;
            // 
            // _nameColumn
            // 
            _nameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _nameColumn.DataPropertyName = "Name";
            _nameColumn.HeaderText = "Name";
            _nameColumn.Name = "_nameColumn";
            _nameColumn.ReadOnly = true;
            // 
            // _checksumColumn
            // 
            _checksumColumn.DataPropertyName = "Checksum";
            _checksumColumn.HeaderText = "Checksum";
            _checksumColumn.Name = "_checksumColumn";
            _checksumColumn.ReadOnly = true;
            _checksumColumn.Width = 120;
            // 
            // panel1
            // 
            panel1.Controls.Add(_closeButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 384);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 44);
            panel1.TabIndex = 1;
            // 
            // _closeButton
            // 
            _closeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _closeButton.DialogResult = DialogResult.Cancel;
            _closeButton.Location = new Point(248, 7);
            _closeButton.Margin = new Padding(4, 3, 4, 3);
            _closeButton.Name = "_closeButton";
            _closeButton.Size = new Size(88, 27);
            _closeButton.TabIndex = 5;
            _closeButton.Text = "Close";
            _closeButton.UseVisualStyleBackColor = true;
            _closeButton.Click += _closeButton_Click;
            // 
            // PreviewDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = _closeButton;
            ClientSize = new Size(350, 428);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "PreviewDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Preview Plugins";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn _nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _checksumColumn;
    }
}