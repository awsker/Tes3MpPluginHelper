﻿namespace Tes3MpPluginHelperGui
{
    public partial class Form1 : Form
    {
        private const string ConfigPath = "LastConfigPath";
        private const string OutputPath = "LastOutputPath";
        private const string IncludeDefaultCRC = "IncludeDefaultCRC";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(Properties.Settings.Default[ConfigPath].ToString()))
            {
                if(File.Exists(Tes3MpPluginHelper.ConfigHandler.OpenMwConfigPath))
                    _configTextBox.Text = Tes3MpPluginHelper.ConfigHandler.OpenMwConfigPath;
            }
            else
            {
                _configTextBox.Text = Properties.Settings.Default[ConfigPath].ToString();
            }

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default[OutputPath].ToString()))
            {
                _outputTextBox.Text = Properties.Settings.Default[OutputPath].ToString();
            }
            _defaultCrcCheckbox.Checked = (bool)Properties.Settings.Default[IncludeDefaultCRC];
            updateButtonStatus();
        }

        private void saveSettings()
        {
            Properties.Settings.Default[ConfigPath] = _configTextBox.Text;
            Properties.Settings.Default[OutputPath] = _outputTextBox.Text;
            Properties.Settings.Default[IncludeDefaultCRC] = _defaultCrcCheckbox.Checked;
            Properties.Settings.Default.Save();
        }

        private void _closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _browseConfigButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;
            if (!string.IsNullOrWhiteSpace(_configTextBox.Text))
                dialog.InitialDirectory = Path.GetDirectoryName(_configTextBox.Text);
            dialog.Filter = "cfg files(*.cfg)| *.cfg";

            var res = dialog.ShowDialog();
            if (res == DialogResult.OK)
                _configTextBox.Text = dialog.FileName;
        }

        private void _browseOutputButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "json files(*.json)| *.json";
            dialog.FileName = "requiredDataFiles.json";
            if (!string.IsNullOrWhiteSpace(_outputTextBox.Text))
                dialog.InitialDirectory = Path.GetDirectoryName(_outputTextBox.Text);
            var res = dialog.ShowDialog();
            if (res == DialogResult.OK)
                _outputTextBox.Text = dialog.FileName;
        }

        private void _generateButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(_configTextBox.Text))
            {
                showError($"Configuration file not found");
                return;
            }
            try
            {
                saveSettings();
                var configs = Tes3MpPluginHelper.ConfigHandler.GetSelectedDatafiles(_configTextBox.Text);
                Tes3MpPluginHelper.PluginJsonWriter.WritePluginJson(_outputTextBox.Text, configs);
                showMessage("Json generated successfully!");
            }
            catch (Exception ex)
            {
                showError(ex.Message);
            }
        }

        private void _previewButton_Click(object sender, EventArgs e)
        {
            try
            {
                var configs = Tes3MpPluginHelper.ConfigHandler.GetSelectedDatafiles(_configTextBox.Text);
                var dialog = new PreviewDialog(configs);
                dialog.Show(this);
            }
            catch (Exception ex)
            {
                showError(ex.Message);
            }
        }

        private void _configTextBox_TextChanged(object sender, EventArgs e)
        {
            updateButtonStatus();
        }

        private void showMessage(string message)
        {
            MessageBox.Show(this, message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void showError(string message)
        {
            MessageBox.Show(this, message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void updateButtonStatus()
        {
            bool fileExists = File.Exists(_configTextBox.Text);
            bool outputFileSet = Path.Exists(Path.GetDirectoryName(_outputTextBox.Text));
            _previewButton.Enabled = fileExists;
            _generateButton.Enabled = fileExists && outputFileSet;
        }
    }
}
