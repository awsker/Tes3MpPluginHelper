namespace Tes3MpPluginHelperGui
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this._configTextBox = new System.Windows.Forms.TextBox();
            this._browseConfigButton = new System.Windows.Forms.Button();
            this._generateButton = new System.Windows.Forms.Button();
            this._closeButton = new System.Windows.Forms.Button();
            this._browseOutputButton = new System.Windows.Forms.Button();
            this._outputTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._defaultCrcCheckbox = new System.Windows.Forms.CheckBox();
            this._previewButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "openmw.cfg File:";
            // 
            // _configTextBox
            // 
            this._configTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._configTextBox.Location = new System.Drawing.Point(107, 12);
            this._configTextBox.Name = "_configTextBox";
            this._configTextBox.Size = new System.Drawing.Size(304, 20);
            this._configTextBox.TabIndex = 1;
            this._configTextBox.TextChanged += new System.EventHandler(this._configTextBox_TextChanged);
            // 
            // _browseConfigButton
            // 
            this._browseConfigButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._browseConfigButton.Location = new System.Drawing.Point(416, 10);
            this._browseConfigButton.Name = "_browseConfigButton";
            this._browseConfigButton.Size = new System.Drawing.Size(75, 23);
            this._browseConfigButton.TabIndex = 2;
            this._browseConfigButton.Text = "Browse";
            this._browseConfigButton.UseVisualStyleBackColor = true;
            this._browseConfigButton.Click += new System.EventHandler(this._browseConfigButton_Click);
            // 
            // _generateButton
            // 
            this._generateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._generateButton.Location = new System.Drawing.Point(275, 100);
            this._generateButton.Name = "_generateButton";
            this._generateButton.Size = new System.Drawing.Size(136, 23);
            this._generateButton.TabIndex = 3;
            this._generateButton.Text = "Generate Json";
            this._generateButton.UseVisualStyleBackColor = true;
            this._generateButton.Click += new System.EventHandler(this._generateButton_Click);
            // 
            // _closeButton
            // 
            this._closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Location = new System.Drawing.Point(417, 100);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 4;
            this._closeButton.Text = "Close";
            this._closeButton.UseVisualStyleBackColor = true;
            this._closeButton.Click += new System.EventHandler(this._closeButton_Click);
            // 
            // _browseOutputButton
            // 
            this._browseOutputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._browseOutputButton.Location = new System.Drawing.Point(416, 41);
            this._browseOutputButton.Name = "_browseOutputButton";
            this._browseOutputButton.Size = new System.Drawing.Size(75, 23);
            this._browseOutputButton.TabIndex = 7;
            this._browseOutputButton.Text = "Browse";
            this._browseOutputButton.UseVisualStyleBackColor = true;
            this._browseOutputButton.Click += new System.EventHandler(this._browseOutputButton_Click);
            // 
            // _outputTextBox
            // 
            this._outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._outputTextBox.Location = new System.Drawing.Point(107, 43);
            this._outputTextBox.Name = "_outputTextBox";
            this._outputTextBox.Size = new System.Drawing.Size(303, 20);
            this._outputTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Json Output File:";
            // 
            // _defaultCrcCheckbox
            // 
            this._defaultCrcCheckbox.AutoSize = true;
            this._defaultCrcCheckbox.Checked = true;
            this._defaultCrcCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._defaultCrcCheckbox.Location = new System.Drawing.Point(18, 74);
            this._defaultCrcCheckbox.Name = "_defaultCrcCheckbox";
            this._defaultCrcCheckbox.Size = new System.Drawing.Size(331, 17);
            this._defaultCrcCheckbox.TabIndex = 8;
            this._defaultCrcCheckbox.Text = "Include default checksums for English/Russian Morrowind ESMs";
            this._defaultCrcCheckbox.UseVisualStyleBackColor = true;
            // 
            // _previewButton
            // 
            this._previewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._previewButton.Location = new System.Drawing.Point(12, 100);
            this._previewButton.Name = "_previewButton";
            this._previewButton.Size = new System.Drawing.Size(147, 23);
            this._previewButton.TabIndex = 9;
            this._previewButton.Text = "Show Plugins";
            this._previewButton.UseVisualStyleBackColor = true;
            this._previewButton.Click += new System.EventHandler(this._previewButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(506, 136);
            this.Controls.Add(this._previewButton);
            this.Controls.Add(this._defaultCrcCheckbox);
            this.Controls.Add(this._browseOutputButton);
            this.Controls.Add(this._outputTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this._generateButton);
            this.Controls.Add(this._browseConfigButton);
            this.Controls.Add(this._configTextBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(2560, 175);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(471, 175);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tes3Mp Plugin Helper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _configTextBox;
        private System.Windows.Forms.Button _browseConfigButton;
        private System.Windows.Forms.Button _generateButton;
        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.Button _browseOutputButton;
        private System.Windows.Forms.TextBox _outputTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox _defaultCrcCheckbox;
        private System.Windows.Forms.Button _previewButton;
    }
}

