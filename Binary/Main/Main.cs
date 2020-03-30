using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void Main_Load(object sender, EventArgs e)
		{
            // Set properties from memory
            ConfigAutoSave.Checked = Properties.Settings.Default.EnableAutobackup;
            ConfigCompressFiles.Checked = Properties.Settings.Default.EnableCompression;
            ConfigCommand.Checked = Properties.Settings.Default.EnableEndscriptLog;
            ConfigEndscript.Checked = Properties.Settings.Default.EnableStaticEnd;

            var NFSCToolTip = new ToolTip();
            var NFSMWToolTip = new ToolTip();
            var NFSUG2ToolTip = new ToolTip();
            var SoonToolTip = new ToolTip();
            var WindowToolTip = new ToolTip();

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
        }

        private void ChooseNFSC_Click(object sender, EventArgs e)
        {
            this.Hide();
            GlobalLib.Core.Process.Set = (int)GlobalLib.Core.GameINT.Carbon;
            Properties.Settings.Default.EnableAutobackup = ConfigAutoSave.Checked;
            Properties.Settings.Default.EnableCompression = ConfigCompressFiles.Checked;
            Properties.Settings.Default.EnableEndscriptLog = ConfigCommand.Checked;
            Properties.Settings.Default.EnableStaticEnd = ConfigEndscript.Checked;
            this.InitializeLogFile();

            bool ForceLoad = false;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.DirectoryC))
            {
                ForceLoad = true;
                GlobalLib.Core.Process.GlobalDir = Properties.Settings.Default.DirectoryC;
            }
            var CarbonForm = new Support.Carbon(ForceLoad);
            CarbonForm.ShowDialog();
            CarbonForm = null;
            Properties.Settings.Default.DirectoryC = GlobalLib.Core.Process.GlobalDir;
            this.Show();
        }

        private void ChooseNFSMW_Click(object sender, EventArgs e)
        {
            this.Hide();
            GlobalLib.Core.Process.Set = (int)GlobalLib.Core.GameINT.MostWanted;
            Properties.Settings.Default.EnableAutobackup = ConfigAutoSave.Checked;
            Properties.Settings.Default.EnableCompression = ConfigCompressFiles.Checked;
            Properties.Settings.Default.EnableEndscriptLog = ConfigCommand.Checked;
            Properties.Settings.Default.EnableStaticEnd = ConfigEndscript.Checked;
            this.InitializeLogFile();

            bool ForceLoad = false;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.DirectoryMW))
            {
                ForceLoad = true;
                GlobalLib.Core.Process.GlobalDir = Properties.Settings.Default.DirectoryMW;
            }
            var MostWantedForm = new Support.MostWanted(ForceLoad);
            MostWantedForm.ShowDialog();
            MostWantedForm = null;
            Properties.Settings.Default.DirectoryMW = GlobalLib.Core.Process.GlobalDir;
            this.Show();
        }

        private void ChooseNFSUG2_Click(object sender, EventArgs e)
        {
            this.Hide();
            GlobalLib.Core.Process.Set = (int)GlobalLib.Core.GameINT.Underground2;
            Properties.Settings.Default.EnableAutobackup = ConfigAutoSave.Checked;
            Properties.Settings.Default.EnableCompression = ConfigCompressFiles.Checked;
            Properties.Settings.Default.EnableEndscriptLog = ConfigCommand.Checked;
            Properties.Settings.Default.EnableStaticEnd = ConfigEndscript.Checked;
            this.InitializeLogFile();

            bool ForceLoad = false;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.DirectoryUG2))
            {
                ForceLoad = true;
                GlobalLib.Core.Process.GlobalDir = Properties.Settings.Default.DirectoryUG2;
            }
            var Underground2Form = new Support.Underground2(ForceLoad);
            Underground2Form.ShowDialog();
            Underground2Form = null;
            Properties.Settings.Default.DirectoryUG2 = GlobalLib.Core.Process.GlobalDir;
            this.Show();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
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
    }
}
