using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlobalLib.Core;
using GlobalLib.Reflection.Abstract;



namespace Binary.Support
{
	public partial class Underground2 : Form
	{
		private bool forceload = false;
		private GlobalLib.Database.Underground2 dbUG2;

		private void InstantiateControls()
		{
			this.DataSet_Split2.Panel2.Controls.Add(this.EndscriptEditor);
			this.DataSet_Split2.Panel1.Controls.Add(this.BinaryDataView);
			this.DataSet_Split1.Panel2.Controls.Add(this.DataSet_Split2);
			this.DataSet_Split1.Panel1.Controls.Add(this.BinaryTree);
			Process.MessageShow = true;
		}

		public Underground2()
		{
			InitializeComponent();
			InstantiateControls();
		}

		public Underground2(bool forceload)
		{
			InitializeComponent();
			InstantiateControls();
			DataSet_MenuStrip.Renderer = new MyRenderer();
			if (forceload)
			{
				this.forceload = forceload;
				//this.DataSet_ReloadFile_Click(null, EventArgs.Empty);
			}
		}

		private class MyRenderer : ToolStripProfessionalRenderer
		{
			public MyRenderer() : base(new MyColors()) { }
		}

		private class MyColors : ProfessionalColorTable
		{
			public override System.Drawing.Color MenuItemSelected
			{
				get { return System.Drawing.Color.FromArgb(40, 23, 60); }
			}
			public override System.Drawing.Color MenuItemSelectedGradientBegin
			{
				get { return System.Drawing.Color.FromArgb(40, 23, 60); }
			}
			public override System.Drawing.Color MenuItemSelectedGradientEnd
			{
				get { return System.Drawing.Color.FromArgb(40, 23, 60); }
			}
		}

		private void EnableButtons()
		{
			DataSet_ReloadFile.Enabled = true;
			DataSet_SaveFile.Enabled = true;
			DataSet_ImportFile.Enabled = true;
			DataSet_ProcessCommand.Enabled = true;
			DataSet_GenerateCommand.Enabled = true;
			DataSet_RestoreBackups.Enabled = true;
			DataSet_CreateBackups.Enabled = true;
			DataSet_UnlockFiles.Enabled = true;
			DataSet_RunGame.Enabled = true;
			DataSet_ExportAllTextures.Enabled = true;
			DataSet_DBInfo.Enabled = true;
			DataSet_BoundsList.Enabled = true;
			EndscriptToolStripMenuItemI.Enabled = true;
		}

		private void DisableButtons()
		{
			DataSet_ReloadFile.Enabled = false;
			DataSet_SaveFile.Enabled = false;
			DataSet_ImportFile.Enabled = false;
			DataSet_ProcessCommand.Enabled = false;
			DataSet_GenerateCommand.Enabled = false;
			DataSet_RestoreBackups.Enabled = false;
			DataSet_CreateBackups.Enabled = false;
			DataSet_UnlockFiles.Enabled = false;
			DataSet_RunGame.Enabled = false;
			DataSet_ExportAllTextures.Enabled = false;
			DataSet_DBInfo.Enabled = false;
			DataSet_BoundsList.Enabled = false;
			EndscriptToolStripMenuItemI.Enabled = false;
		}

		private void CreateBackupFiles(bool force)
		{
			try
			{
				string a1 = Process.GlobalDir + @"\GLOBAL\GlobalA.bun";
				string a2 = Process.GlobalDir + @"\GLOBAL\GlobalA.bun.bacc";
				string b1 = Process.GlobalDir + @"\GLOBAL\GlobalB.lzc";
				string b2 = Process.GlobalDir + @"\GLOBAL\GlobalB.lzc.bacc";
				string c1 = Process.GlobalDir + @"\LANGUAGES\English.bin";
				string c2 = Process.GlobalDir + @"\LANGUAGES\English.bin.bacc";
				string d1 = Process.GlobalDir + @"\LANGUAGES\Labels.bin";
				string d2 = Process.GlobalDir + @"\LANGUAGES\Labels.bin.bacc";
				if (!force)
				{
					if (!File.Exists(a2)) File.Copy(a1, a2);
					if (!File.Exists(b2)) File.Copy(b1, b2);
					if (!File.Exists(c2)) File.Copy(c1, c2);
					if (!File.Exists(d2)) File.Copy(d1, d2);
				}
				else
				{
					if (File.Exists(a2)) File.Delete(a2);
					if (File.Exists(b2)) File.Delete(b2);
					if (File.Exists(c2)) File.Delete(c2);
					if (File.Exists(d2)) File.Delete(d2);
					File.Copy(a1, a2); File.Copy(b1, b2);
					File.Copy(c1, c2); File.Copy(d1, d2);
				}
			}
			catch (Exception e)
			{
				while (e.InnerException != null) e = e.InnerException;
				MessageBox.Show($"Error occured: {e.Message}", "Failure");
			}
		}

		private void TerminateLoad()
		{
			this.dbUG2 = null;
			DataSet_Status.Text = $"Failed to load data | {DateTime.Now.ToString()}";
			BinaryTree.Nodes.Clear();
			BinaryDataView.Columns.Clear();
			this.DisableButtons();
		}

		private void LoadDBUnderground2(string foldername)
		{
			var GlobalA = File.Exists(foldername + @"\Global\GlobalA.bun");
			var GlobalB = File.Exists(foldername + @"\Global\GlobalB.lzc");
			var LangGen = File.Exists(foldername + @"\Languages\English.bin");
			var LangLab = File.Exists(foldername + @"\Languages\Labels.bin");
			var WheelsD = Directory.Exists(foldername + @"\Cars\Wheels");
			var AudiosD = Directory.Exists(foldername + @"\Cars\Audio");
			var Stream = File.Exists(foldername + @"\Tracks\StreamL4RA.bun");
			var NFSUG2 = File.Exists(foldername + @"\speed2.exe");
			var Load = GlobalA && GlobalB && LangGen && LangLab && WheelsD && AudiosD && Stream && NFSUG2;
			if (!Load)
			{
				MessageBox.Show("Folder is not game's directory." + Environment.NewLine + "Please select the correct folder.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			Process.GlobalDir = foldername;
			dbUG2 = null;
			dbUG2 = new GlobalLib.Database.Underground2();
			var watch = new System.Diagnostics.Stopwatch();
			watch.Start();
			bool valid = Process.LoadData(dbUG2);
			watch.Stop();
			if (!valid) { this.TerminateLoad(); return; }
			LoadBinaryTree();
			DataSet_Status.Text = $"Finished loading data in {watch.ElapsedMilliseconds}ms | {DateTime.Now.ToString()}";
			EnableButtons();
			if (Properties.Settings.Default.EnableAutobackup)
				this.CreateBackupFiles(false);
		}

		private TreeNode AppendTreeNode(string name, List<VirtualNode> subnodes)
		{
			var treenode = new TreeNode(name);
			foreach (var subnode in subnodes)
				treenode.Nodes.Add(this.AppendTreeNode(subnode.NodeName, subnode.SubNodes));
			return treenode;
		}

		private void LoadBinaryTree()
		{
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbUG2.BankTriggers.ThisName, this.dbUG2.BankTriggers.GetAllNodes()));
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbUG2.CarTypeInfos.ThisName, this.dbUG2.CarTypeInfos.GetAllNodes()));
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbUG2.GCareerBrands.ThisName, this.dbUG2.GCareerBrands.GetAllNodes()));
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbUG2.GCareerRaces.ThisName, this.dbUG2.GCareerRaces.GetAllNodes()));
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbUG2.GCareerStages.ThisName, this.dbUG2.GCareerStages.GetAllNodes()));
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbUG2.GCarUnlocks.ThisName, this.dbUG2.GCarUnlocks.GetAllNodes()));
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbUG2.GShowcases.ThisName, this.dbUG2.GShowcases.GetAllNodes()));
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbUG2.Materials.ThisName, this.dbUG2.Materials.GetAllNodes()));
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbUG2.PartPerformances.ThisName, this.dbUG2.PartPerformances.GetAllNodes()));
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbUG2.PartUnlockables.ThisName, this.dbUG2.PartUnlockables.GetAllNodes()));
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbUG2.PerfSliderTunings.ThisName, this.dbUG2.PerfSliderTunings.GetAllNodes()));
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbUG2.PresetRides.ThisName, this.dbUG2.PresetRides.GetAllNodes()));
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbUG2.SMSMessages.ThisName, this.dbUG2.SMSMessages.GetAllNodes()));
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbUG2.Sponsors.ThisName, this.dbUG2.Sponsors.GetAllNodes()));
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbUG2.SunInfos.ThisName, this.dbUG2.SunInfos.GetAllNodes()));
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbUG2.Tracks.ThisName, this.dbUG2.Tracks.GetAllNodes()));
		}

		private void DataSet_OpenFile_Click(object sender, EventArgs e)
		{
			this.BrowseGameDirDialog.Description = "Select the NFS: Underground 2 directory that you want to work on.";

			if (BrowseGameDirDialog.ShowDialog() == DialogResult.OK)
			{
				this.LoadDBUnderground2(BrowseGameDirDialog.SelectedPath);
			}
		}
	}
}
