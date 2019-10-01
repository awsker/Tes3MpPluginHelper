using System;
using System.IO;
using System.Windows.Forms;

namespace Tes3MpPluginHelperGui
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

            var res = dialog.ShowDialog();
            if (res == DialogResult.OK)
                _outputTextBox.Text = dialog.FileName;
        }

        private void _generateButton_Click(object sender, EventArgs e)
        {
            try
            {
                saveSettings();
                var configs = Tes3MpPluginHelper.ConfigHandler.GetSelectedDatafiles(_configTextBox.Text);
                Tes3MpPluginHelper.PluginJsonWriter.WritePluginJson(_outputTextBox.Text, configs);
                MessageBox.Show("Json generated successfully!");
            }
            catch (Exception ex) 
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
