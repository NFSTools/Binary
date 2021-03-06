﻿/********************************************************************************
 * MIT License
 * 
 * Copyright (c) 2020 MaxHwoy & NFS Tools
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE. 
********************************************************************************/



using System;
using System.IO;
using System.Linq;
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
            this.InitializeComponent();
        }

		#region Supportive

		private void InitializeLogFile()
        {
            Log.EnableLog = false;
            Log.EnableTimeWrite = false;
            Log.FileName = "Binary.log";
            Core.CreateEndscriptFile("Binary.end");
        }

        private void ParseConfigurations()
        {
            Settings.Default.EnableAutobackup = this.ConfigAutoSave.Checked;
            Settings.Default.EnableCompression = this.ConfigCompressFiles.Checked;
            Settings.Default.EnableEndscriptLog = this.ConfigCommand.Checked;
            Settings.Default.EnableStaticEnd = this.ConfigStatic.Checked;
            Settings.Default.EnableMaximized = this.ConfigMaximized.Checked;
            Settings.Default.EnableWatermarks = this.ConfigWatermark.Checked;
            Settings.Default.EnableSuppressABCI = this.ConfigSuppressADCI.Checked;
            Settings.Default.Save();
        }

        private void UpdateMainConfigs()
        {
            this.ConfigAutoSave.Checked = Settings.Default.EnableAutobackup;
            this.ConfigCompressFiles.Checked = Settings.Default.EnableCompression;
            this.ConfigCommand.Checked = Settings.Default.EnableEndscriptLog;
            this.ConfigStatic.Checked = Settings.Default.EnableStaticEnd; 
            this.ConfigMaximized.Checked = Settings.Default.EnableMaximized; 
            this.ConfigWatermark.Checked = Settings.Default.EnableWatermarks;
            this.ConfigSuppressADCI.Checked = Settings.Default.EnableSuppressABCI;
        }

        public void CloseAllToolForms()
        {
            var list = Application.OpenForms.Cast<Form>().ToList();
            for (int a1 = list.Count - 1; a1 >= 0; --a1)
            {
                if (list[a1].Name != this.Name)
                    list[a1].Close();
            }
        }

		#endregion

		#region Main

		private void Main_Load(object sender, EventArgs e)
        {
            // Set properties from memory
            this.UpdateMainConfigs();

            var NFSCToolTip = new ToolTip();
            var NFSMWToolTip = new ToolTip();
            var NFSUG2ToolTip = new ToolTip();
            var SoonToolTip = new ToolTip();
            var WindowToolTip = new ToolTip();
            var ButtonToolTip = new ToolTip();
            var ConfigToolTip = new ToolTip();

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

            ConfigToolTip.AutoPopDelay = 3000;
            ConfigToolTip.InitialDelay = 800;
            ConfigToolTip.ReshowDelay = 500;

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

            ButtonToolTip.SetToolTip(this.SetModderName, "Set Modder Name that will be used when saving files.");
            ButtonToolTip.SetToolTip(this.ButtonDiscord, "Join official modding and support discord community server.");
            ButtonToolTip.SetToolTip(this.ButtonYAML, "Link YAMLDatabase to process modscripts.");

            ConfigToolTip.SetToolTip(this.ConfigAutoSave, "Enable making auto backups when there are none detected.");
            ConfigToolTip.SetToolTip(this.ConfigCompressFiles, "Enable saving GlobalB.lzc as JDLZ-compressed.");
            ConfigToolTip.SetToolTip(this.ConfigCommand, "Enable saving executed end commands to Binary.end file.");
            ConfigToolTip.SetToolTip(this.ConfigStatic, "Enable execution of static commands.");
            ConfigToolTip.SetToolTip(this.ConfigMaximized, "Start main editor in maximized mode.");
            ConfigToolTip.SetToolTip(this.ConfigWatermark, "Make Modder Name watermarks be written in file when saving.");
            ConfigToolTip.SetToolTip(this.ConfigSuppressADCI, "Suppress Add-Delete-Copy-Import end command errors.");
        }

        private void ChooseNFSC_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ParseConfigurations();
            this.InitializeLogFile();
            this.CloseAllToolForms();
            if (Settings.Default.EnableWatermarks)
                Process.Watermark = $"Binary: used by {Settings.Default.BinaryUsername}";
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
            this.UpdateMainConfigs();
            this.Show();
        }

        private void ChooseNFSMW_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ParseConfigurations();
            this.InitializeLogFile();
            this.CloseAllToolForms();
            if (Settings.Default.EnableWatermarks)
                Process.Watermark = $"Binary: used by {Settings.Default.BinaryUsername}";
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
            this.UpdateMainConfigs();
            this.Show();
        }

        private void ChooseNFSUG2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ParseConfigurations();
            this.InitializeLogFile();
            this.CloseAllToolForms();
            if (Settings.Default.EnableWatermarks)
                Process.Watermark = $"Binary: used by {Settings.Default.BinaryUsername}";
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
            this.UpdateMainConfigs();
            this.Show();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ParseConfigurations();
        }

		#endregion

		#region Launch

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
                string Global_dir = OpenFolderDialog.SelectedPath;

                // Unlock Memory Files
                MemoryUnlock.FastUnlock(Global_dir + @"\GLOBAL\CarHeadersMemoryFile.bin");
                MemoryUnlock.FastUnlock(Global_dir + @"\GLOBAL\FrontEndMemoryFile.bin");
                MemoryUnlock.FastUnlock(Global_dir + @"\GLOBAL\InGameMemoryFile.bin");
                MemoryUnlock.FastUnlock(Global_dir + @"\GLOBAL\PermanentMemoryFile.bin");
                MemoryUnlock.LongUnlock(Global_dir + @"\GLOBAL\GlobalMemoryFile.bin");

                MessageBox.Show("Memory files were successfully unlocked for modding.", "Success");
            }
        }

		#endregion

		#region Buttons

		private void ButtonDiscord_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/jzksXXn");
        }

        private void ButtonYAML_Click(object sender, EventArgs e)
        {
            if (this.OpenYAMLDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.YAMLDirectory = this.OpenYAMLDialog.FileName;
                Settings.Default.Save();
            }
        }

        private void OpenYAMLDialog_FileOk(object sender, CancelEventArgs e)
        {
            var name = Path.GetFileName(this.OpenYAMLDialog.FileName);
            if (name != "YAMLDatabase.exe")
            {
                MessageBox.Show("File selected is not YAMLDatabase.exe.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void SetModderName_Click(object sender, EventArgs e)
        {
            var input = new Interact.Input("Enter Modder Name that will be used on runtime:");
            if (input.ShowDialog() == DialogResult.OK)
            {
                if (input.CollectionName.Length > 15)
                {
                    MessageBox.Show("Modder Name should not exceed 15 characters.", "Warning");
                    this.SetModderName_Click(sender, e);
                }
                else
                {
                    Settings.Default.BinaryUsername = input.CollectionName;
                    Settings.Default.Save();
                }
            }
        }

        private void GlobalStatusStrip_DoubleClick(object sender, EventArgs e)
        {
            var AboutForm = new Interact.About();
            AboutForm.ShowDialog();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var AboutForm = new Interact.About();
            AboutForm.ShowDialog();
        }

        #endregion
    }
}