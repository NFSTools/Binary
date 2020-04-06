using System;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using Binary.Endscript;
using Binary.Properties;
using GlobalLib.Core;
using GlobalLib.Utils;


namespace Binary.Main
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void InitializeLogFile()
        {
            Log.EnableLog = false;
            Log.EnableTimeWrite = false;
            Log.FileName = "Binary.log";
            Core.CreateEndscriptFile("Binary.end");
        }

        private void ParseConfigurations()
        {
            Settings.Default.EnableAutobackup = ConfigAutoSave.Checked;
            Settings.Default.EnableCompression = ConfigCompressFiles.Checked;
            Settings.Default.EnableEndscriptLog = ConfigCommand.Checked;
            Settings.Default.EnableStaticEnd = ConfigStatic.Checked;
            Settings.Default.EnableMaximized = ConfigMaximized.Checked;
            Settings.Default.EnableWatermarks = ConfigWatermark.Checked;
            Settings.Default.Save();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Set properties from memory
            ConfigAutoSave.Checked = Settings.Default.EnableAutobackup;
            ConfigCompressFiles.Checked = Settings.Default.EnableCompression;
            ConfigCommand.Checked = Settings.Default.EnableEndscriptLog;
            ConfigStatic.Checked = Settings.Default.EnableStaticEnd;
            ConfigMaximized.Checked = Settings.Default.EnableMaximized;
            ConfigWatermark.Checked = Settings.Default.EnableWatermarks;

            var NFSCToolTip = new ToolTip();
            var NFSMWToolTip = new ToolTip();
            var NFSUG2ToolTip = new ToolTip();
            var SoonToolTip = new ToolTip();
            var WindowToolTip = new ToolTip();
            var ButtonToolTip = new ToolTip();

            NFSCToolTip.AutoPopDelay = 5000;
            NFSCToolTip.InitialDelay = 1000;
            NFSCToolTip.ReshowDelay = 500;

            NFSMWToolTip.AutoPopDelay = 5000;
            NFSMWToolTip.InitialDelay = 1000;
            NFSMWToolTip.ReshowDelay = 500;

            NFSUG2ToolTip.AutoPopDelay = 5000;
            NFSUG2ToolTip.InitialDelay = 1000;
            NFSUG2ToolTip.ReshowDelay = 500;

            SoonToolTip.AutoPopDelay = 5000;
            SoonToolTip.InitialDelay = 1000;
            SoonToolTip.ReshowDelay = 500;

            WindowToolTip.AutoPopDelay = 5000;
            WindowToolTip.InitialDelay = 1000;
            WindowToolTip.ReshowDelay = 500;

            ButtonToolTip.AutoPopDelay = 3000;
            ButtonToolTip.InitialDelay = 800;
            ButtonToolTip.ReshowDelay = 500;

            NFSCToolTip.SetToolTip(this.ChooseNFSC, "Launch Binary for Need for Speed: Carbon");
            NFSMWToolTip.SetToolTip(this.ChooseNFSMW, "Launch Binary for Need for Speed: Most Wanted");
            NFSUG2ToolTip.SetToolTip(this.ChooseNFSUG2, "Launch Binary for Need for Speed: Underground 2");
            SoonToolTip.SetToolTip(this.ChooseSoon, "Coming Soon?!");

            WindowToolTip.SetToolTip(this.LaunchHasher, "Launch NFS-Hasher");
            WindowToolTip.SetToolTip(this.LaunchRaider, "Launch NFS-Raider");
            WindowToolTip.SetToolTip(this.LaunchPicker, "Launch ColorPicker");
            WindowToolTip.SetToolTip(this.LaunchSwatcher, "Launch SwatchPicker");
            WindowToolTip.SetToolTip(this.LaunchUnlock, "Unlock Game Files for Modding");
            WindowToolTip.SetToolTip(this.LaunchReadme, "Open Readme.txt");

            ButtonToolTip.SetToolTip(this.SetModderName, "Set Username that will be used when saving files.");
            ButtonToolTip.SetToolTip(this.ButtonDiscord, "Join official modding and support discord community server.");
            ButtonToolTip.SetToolTip(this.ButtonYAML, "Link YAMLDatabase to process modscripts.");
        }

        private void ChooseNFSC_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ParseConfigurations();
            this.InitializeLogFile();
            if (Settings.Default.EnableWatermarks)
                Process.Watermark = $"Binary by MaxHwoy | Edited by {Settings.Default.BinaryUsername}";
            else
                Process.Watermark = string.Empty;
            
            bool forceload = false;
            string dir = Settings.Default.DirectoryC;
            if (!string.IsNullOrEmpty(dir)) forceload = true;
            var CarbonForm = new Support.Shared(GameINT.Carbon, dir, forceload);
            if (Settings.Default.EnableMaximized)
                CarbonForm.WindowState = FormWindowState.Maximized;
            CarbonForm.ShowDialog();
            Settings.Default.DirectoryC = CarbonForm.GetDirectory();
            CarbonForm = null;
            Utils.CleanUp.GCCollect();
            this.Show();
        }

        private void ChooseNFSMW_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ParseConfigurations();
            this.InitializeLogFile();
            if (Settings.Default.EnableWatermarks)
                Process.Watermark = $"Binary by MaxHwoy | Edited by {Settings.Default.BinaryUsername}";
            else
                Process.Watermark = string.Empty;

            bool forceload = false;
            string dir = Settings.Default.DirectoryMW;
            if (!string.IsNullOrEmpty(dir)) forceload = true;
            var MostWantedForm = new Support.Shared(GameINT.MostWanted, dir, forceload);
            if (Settings.Default.EnableMaximized)
                MostWantedForm.WindowState = FormWindowState.Maximized;
            MostWantedForm.ShowDialog();
            Settings.Default.DirectoryMW = MostWantedForm.GetDirectory();
            MostWantedForm = null;
            Utils.CleanUp.GCCollect();
            this.Show();
        }

        private void ChooseNFSUG2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ParseConfigurations();
            this.InitializeLogFile();
            if (Settings.Default.EnableWatermarks)
                Process.Watermark = $"Binary by MaxHwoy | Edited by {Settings.Default.BinaryUsername}";
            else
                Process.Watermark = string.Empty;

            bool forceload = false;
            string dir = Settings.Default.DirectoryUG2;
            if (!string.IsNullOrEmpty(dir))
                forceload = true;
            var Underground2Form = new Support.Shared(GameINT.Underground2, dir, forceload);
            if (Settings.Default.EnableMaximized)
                Underground2Form.WindowState = FormWindowState.Maximized;
            Underground2Form.ShowDialog();
            Settings.Default.DirectoryUG2 = Underground2Form.GetDirectory();
            Underground2Form = null;
            Utils.CleanUp.GCCollect();
            this.Show();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ParseConfigurations();
        }

        private void LaunchHasher_Click(object sender, EventArgs e)
        {
            var HasherWindow = new Tools.Hasher();
            HasherWindow.Show();
        }

        private void LaunchRaider_Click(object sender, EventArgs e)
        {
            var RaiderWindow = new Tools.Raider();
            RaiderWindow.Show();
        }

        private void LaunchPicker_Click(object sender, EventArgs e)
        {
            var ColorPickerWindow = new Tools.ColorPicker();
            ColorPickerWindow.Show();
        }

        private void LaunchSwatcher_Click(object sender, EventArgs e)
        {
            var SwatchPickerWindow = new Tools.SwatchPicker();
            SwatchPickerWindow.Show();
        }

        private void LaunchReadme_Click(object sender, EventArgs e)
        {
            if (File.Exists("Readme.txt"))
                System.Diagnostics.Process.Start("explorer", "Readme.txt");
            else
                MessageBox.Show("Could not find Readme.txt file.", "Failure");
        }

        private void LaunchUnlock_Click(object sender, EventArgs e)
        {
            var OpenFolderDialog = new FolderBrowserDialog();
            OpenFolderDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            OpenFolderDialog.Description = "Select Need for Speed directory that you want to unlock files in.";
            if (OpenFolderDialog.ShowDialog() == DialogResult.OK)
            {
                string GlobalB_dir = OpenFolderDialog.SelectedPath;

                // Unlock Memory Files
                MemoryUnlock.FastUnlock(GlobalB_dir + @"\GLOBAL\CarHeadersMemoryFile.bin");
                MemoryUnlock.FastUnlock(GlobalB_dir + @"\GLOBAL\FrontEndMemoryFile.bin");
                MemoryUnlock.FastUnlock(GlobalB_dir + @"\GLOBAL\InGameMemoryFile.bin");
                MemoryUnlock.FastUnlock(GlobalB_dir + @"\GLOBAL\PermanentMemoryFile.bin");
                MemoryUnlock.LongUnlock(GlobalB_dir + @"\GLOBAL\GlobalMemoryFile.bin");

                MessageBox.Show("Memory files were successfully unlocked for modding.", "Success");
            }
        }

        private void ButtonDiscord_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/jzksXXn");
        }

        private void ButtonYAML_Click(object sender, EventArgs e)
        {
            if (OpenYAMLDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.YAMLDirectory = OpenYAMLDialog.FileName;
                Settings.Default.Save();
            }
        }

        private void OpenYAMLDialog_FileOk(object sender, CancelEventArgs e)
        {
            var name = Path.GetFileName(OpenYAMLDialog.FileName);
            if (name != "YAMLDatabase.exe")
            {
                MessageBox.Show("File selected is not YAMLDatabase.exe.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void SetModderName_Click(object sender, EventArgs e)
        {
            var input = new Interact.Input("Enter your username that will be used on runtime:");
            if (input.ShowDialog() == DialogResult.OK)
            {
                if (input.CollectionName.Length > 0x20)
                {
                    MessageBox.Show("Your name should not exceed 32 characters.", "Warning");
                    this.SetModderName_Click(sender, e);
                }
                else
                {
                    Settings.Default.BinaryUsername = input.CollectionName;
                    Settings.Default.Save();
                }
            }
        }
    }
}