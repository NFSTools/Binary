using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binary.Forms.Main
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();
		}

		private void Main_Load(object sender, EventArgs e)
		{
            // Set properties from memory
            ConfigAutoSave.Checked = Properties.Settings.Default.EnableAutobackup;
            ConfigCompressFiles.Checked = Properties.Settings.Default.EnableCompression;
            ConfigCommand.Checked = Properties.Settings.Default.EnableModscriptLog;
            ConfigEndscript.Checked = Properties.Settings.Default.EnableNewModscripts;

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

            NFSCToolTip.SetToolTip(this.ChooseNFSC, "Launch NFS-Binary for Need for Speed: Carbon");
            NFSMWToolTip.SetToolTip(this.ChooseNFSMW, "Launch NFS-Binary for Need for Speed: Most Wanted");
            NFSUG2ToolTip.SetToolTip(this.ChooseNFSUG2, "Launch NFS-Binary for Need for Speed: Underground 2");
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
            Properties.Settings.Default.EnableModscriptLog = ConfigCommand.Checked;
            Properties.Settings.Default.EnableNewModscripts = ConfigEndscript.Checked;

            bool ForceLoad = false;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.DirectoryC))
            {
                ForceLoad = true;
                GlobalLib.Core.Process.GlobalDir = Properties.Settings.Default.DirectoryC;
            }
            var CarbonForm = new DataSet.DataSet(ForceLoad);
            CarbonForm.ShowDialog();
            CarbonForm = null;
            Properties.Settings.Default.DirectoryC = GlobalLib.Core.Process.GlobalDir;
            this.Show();
        }
    }
}
