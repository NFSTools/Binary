﻿using System;
using System.ComponentModel;
using System.Windows.Forms;



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
            GlobalLib.Utils.Log.EnableLog = false;
            GlobalLib.Utils.Log.EnableTimeWrite = false;
            GlobalLib.Utils.Log.FileName = "Binary.log";
            Endscript.Core.CreateEndscriptFile("Binary.end");
        }

        private void ParseConfigurations()
        {
            Properties.Settings.Default.EnableAutobackup = ConfigAutoSave.Checked;
            Properties.Settings.Default.EnableCompression = ConfigCompressFiles.Checked;
            Properties.Settings.Default.EnableEndscriptLog = ConfigCommand.Checked;
            Properties.Settings.Default.EnableStaticEnd = ConfigStatic.Checked;
            Properties.Settings.Default.EnableMaximized = ConfigMaximized.Checked;
            Properties.Settings.Default.EnableWatermarks = ConfigWatermark.Checked;
            Properties.Settings.Default.Save();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Set properties from memory
            ConfigAutoSave.Checked = Properties.Settings.Default.EnableAutobackup;
            ConfigCompressFiles.Checked = Properties.Settings.Default.EnableCompression;
            ConfigCommand.Checked = Properties.Settings.Default.EnableEndscriptLog;
            ConfigStatic.Checked = Properties.Settings.Default.EnableStaticEnd;
            ConfigMaximized.Checked = Properties.Settings.Default.EnableMaximized;
            ConfigWatermark.Checked = Properties.Settings.Default.EnableWatermarks;

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
            GlobalLib.Core.Process.Set = (int)GlobalLib.Core.GameINT.Carbon;
            if (Properties.Settings.Default.EnableWatermarks)
                GlobalLib.Core.Process.Watermark = $"Binary by MaxHwoy | Edited by {Properties.Settings.Default.BinaryUsername}";
            else
                GlobalLib.Core.Process.Watermark = string.Empty;
            this.ParseConfigurations();
            this.InitializeLogFile();

            bool ForceLoad = false;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.DirectoryC))
            {
                ForceLoad = true;
                GlobalLib.Core.Process.GlobalDir = Properties.Settings.Default.DirectoryC;
            }
            var CarbonForm = new Support.Carbon(ForceLoad);
            if (Properties.Settings.Default.EnableMaximized)
                CarbonForm.WindowState = FormWindowState.Maximized;
            CarbonForm.ShowDialog();
            CarbonForm = null;
            Properties.Settings.Default.DirectoryC = GlobalLib.Core.Process.GlobalDir;
            Utils.CleanUp.GCCollect();
            this.Show();
        }

        private void ChooseNFSMW_Click(object sender, EventArgs e)
        {
            this.Hide();
            GlobalLib.Core.Process.Set = (int)GlobalLib.Core.GameINT.MostWanted;
            this.ParseConfigurations();
            this.InitializeLogFile();

            bool ForceLoad = false;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.DirectoryMW))
            {
                ForceLoad = true;
                GlobalLib.Core.Process.GlobalDir = Properties.Settings.Default.DirectoryMW;
            }
            var MostWantedForm = new Support.MostWanted(ForceLoad);
            if (Properties.Settings.Default.EnableMaximized)
                MostWantedForm.WindowState = FormWindowState.Maximized;
            MostWantedForm.ShowDialog();
            MostWantedForm = null;
            Properties.Settings.Default.DirectoryMW = GlobalLib.Core.Process.GlobalDir;
            Utils.CleanUp.GCCollect();
            this.Show();
        }

        private void ChooseNFSUG2_Click(object sender, EventArgs e)
        {
            this.Hide();
            string str = Properties.Settings.Default.YAMLDirectory;
            GlobalLib.Core.Process.Set = (int)GlobalLib.Core.GameINT.Underground2;
            this.ParseConfigurations();
            this.InitializeLogFile();

            bool ForceLoad = false;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.DirectoryUG2))
            {
                ForceLoad = true;
                GlobalLib.Core.Process.GlobalDir = Properties.Settings.Default.DirectoryUG2;
            }
            var Underground2Form = new Support.Underground2(ForceLoad);
            if (Properties.Settings.Default.EnableMaximized)
                Underground2Form.WindowState = FormWindowState.Maximized;
            Underground2Form.ShowDialog();
            Underground2Form = null;
            Properties.Settings.Default.DirectoryUG2 = GlobalLib.Core.Process.GlobalDir;
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
            if (System.IO.File.Exists("Readme.txt"))
                System.Diagnostics.Process.Start("explorer", "Readme.txt");
            else
                MessageBox.Show("Could not find Readme.txt file.", "Failure");
        }

        private void LaunchUnlock_Click(object sender, EventArgs e)
        {
            var OpenFolderDialog = new FolderBrowserDialog();
            OpenFolderDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            OpenFolderDialog.Description = "Select the NFS: Carbon or NFS: Most Wanted directory that you want to unlock files in.";
            if (OpenFolderDialog.ShowDialog() == DialogResult.OK)
            {
                string GlobalB_dir = OpenFolderDialog.SelectedPath;

                bool NFSC = System.IO.File.Exists(GlobalB_dir + @"\Tracks\StreamL5RA.bun");
                bool NFSMW = System.IO.File.Exists(GlobalB_dir + @"\Tracks\StreamL2RA.bun");
                bool NFSUG2 = System.IO.File.Exists(GlobalB_dir + @"\Tracks\StreamL4RA.bun");

                if (NFSC)
                {
                    // Unlock Memory Files
                    GlobalLib.Utils.MemoryUnlock.FastUnlock(GlobalB_dir + @"\GLOBAL\CarHeadersMemoryFile.bin");
                    GlobalLib.Utils.MemoryUnlock.FastUnlock(GlobalB_dir + @"\GLOBAL\FrontEndMemoryFile.bin");
                    GlobalLib.Utils.MemoryUnlock.FastUnlock(GlobalB_dir + @"\GLOBAL\InGameMemoryFile.bin");
                    GlobalLib.Utils.MemoryUnlock.FastUnlock(GlobalB_dir + @"\GLOBAL\PermanentMemoryFile.bin");
                    GlobalLib.Utils.MemoryUnlock.LongUnlock(GlobalB_dir + @"\GLOBAL\GlobalMemoryFile.bin");

                    MessageBox.Show("Memory files were successfully unlocked for modding.", "Success");
                }
                else if (NFSMW)
                {
                    // Unlock Memory Files
                    GlobalLib.Utils.MemoryUnlock.FastUnlock(GlobalB_dir + @"\GLOBAL\FrontEndMemoryFile.bin");
                    GlobalLib.Utils.MemoryUnlock.FastUnlock(GlobalB_dir + @"\GLOBAL\InGameMemoryFile.bin");
                    GlobalLib.Utils.MemoryUnlock.FastUnlock(GlobalB_dir + @"\GLOBAL\PermanentMemoryFile.bin");
                    GlobalLib.Utils.MemoryUnlock.LongUnlock(GlobalB_dir + @"\GLOBAL\GlobalMemoryFile.bin");

                    MessageBox.Show("Memory files were successfully unlocked for modding.", "Success");
                }
                else if (NFSUG2)
                {
                    GlobalLib.Utils.MemoryUnlock.FastUnlock(GlobalB_dir + @"\GLOBAL\CarHeadersMemoryFile.bin");
                    GlobalLib.Utils.MemoryUnlock.FastUnlock(GlobalB_dir + @"\GLOBAL\FrontEndMemoryFile.bin");
                    GlobalLib.Utils.MemoryUnlock.FastUnlock(GlobalB_dir + @"\GLOBAL\InGameMemoryFile.bin");
                    GlobalLib.Utils.MemoryUnlock.LongUnlock(GlobalB_dir + @"\GLOBAL\GlobalMemoryFile.bin");
                }
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
                Properties.Settings.Default.YAMLDirectory = OpenYAMLDialog.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void OpenYAMLDialog_FileOk(object sender, CancelEventArgs e)
        {
            var name = System.IO.Path.GetFileName(OpenYAMLDialog.FileName);
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
                    Properties.Settings.Default.BinaryUsername = input.CollectionName;
                    Properties.Settings.Default.Save();
                }
            }
        }
    }
}