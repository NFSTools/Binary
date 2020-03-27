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
using Binary.Endscript;
using GlobalLib.Core;
using GlobalLib.Reflection.Abstract;



namespace Binary.Support
{
	public partial class Underground2 : Form
	{
		private GlobalLib.Database.Underground2 dbUG2;

		private void InstantiateControls()
		{
			this.DataSet_Split2.Panel2.Controls.Add(this.ColoredTextForm);
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
				this.LoadDBUnderground2(Process.GlobalDir, false);
		}

		private class MyRenderer : ToolStripProfessionalRenderer
		{
			public MyRenderer() : base(new MyColors()) { }
		}

		private class MyColors : ProfessionalColorTable
		{
			public override Color MenuItemSelected
			{
				get { return Color.FromArgb(40, 23, 60); }
			}
			public override Color MenuItemSelectedGradientBegin
			{
				get { return Color.FromArgb(40, 23, 60); }
			}
			public override Color MenuItemSelectedGradientEnd
			{
				get { return Color.FromArgb(40, 23, 60); }
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

		private int GetLastShownRowIndex()
		{
			if (BinaryDataView.Rows != null && BinaryDataView.Rows.Count > 0)
				return BinaryDataView.FirstDisplayedScrollingRowIndex;
			else return 0;
		}

		private void ScrollDownToRowIndex(int index)
		{
			if (BinaryDataView.Rows != null && BinaryDataView.Rows.Count > index)
				BinaryDataView.FirstDisplayedScrollingRowIndex = index;
		}

		private void SelectNodeByFullPath(string fullpath, TreeNodeCollection collection)
		{
			foreach (TreeNode node in collection)
			{
				if (node.FullPath == fullpath)
				{
					BinaryTree.SelectedNode = node;
					return;
				}
				else if (node.Nodes != null && node.Nodes.Count > 0)
					this.SelectNodeByFullPath(fullpath, node.Nodes);
			}
		}

		private void LoadDBUnderground2(string foldername, bool showerror)
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
				if (showerror)
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
			LoadBinaryTree(false);
			DataSet_Status.Text = $"Finished loading data in {watch.ElapsedMilliseconds}ms | {DateTime.Now.ToString()}";
			EnableButtons();
			if (Properties.Settings.Default.EnableAutobackup)
				this.CreateBackupFiles(false);
			if (this.BinaryTree.Nodes != null && this.BinaryTree.Nodes.Count > 0)
				this.BinaryTree.SelectedNode = this.BinaryTree.Nodes[0];
		}

		private TreeNode AppendTreeNode(string name, List<VirtualNode> subnodes)
		{
			var treenode = new TreeNode(name);
			foreach (var subnode in subnodes)
				treenode.Nodes.Add(this.AppendTreeNode(subnode.NodeName, subnode.SubNodes));
			return treenode;
		}

		private void LoadBinaryTree(bool load_last_select)
		{
			string path = null;
			int index = 0;
			if (load_last_select)
			{
				path = this.BinaryTree.SelectedNode.FullPath;
				index = this.GetLastShownRowIndex();
			}
			this.BinaryTree.Nodes.Clear();
			this.BinaryDataView.Columns.Clear();
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
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbUG2.WorldChallenges.ThisName, this.dbUG2.WorldChallenges.GetAllNodes()));
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbUG2.WorldShops.ThisName, this.dbUG2.WorldShops.GetAllNodes()));
			if (load_last_select)
			{
				this.SelectNodeByFullPath(path, this.BinaryTree.Nodes);
				this.ScrollDownToRowIndex(index);
			}
		}

		private void UpdateBinaryTreeView()
		{
			int index = this.GetLastShownRowIndex();
			this.BinaryTree_AfterSelect(this.BinaryTree, null);
			this.ScrollDownToRowIndex(index);
		}

		private void BinaryDataViewColumnInit()
		{
			var column_descr = new DataGridViewTextBoxColumn();
			var column_value = new DataGridViewTextBoxColumn();

			column_descr.Name = "Attribute";
			column_descr.HeaderText = "Attribute";
			column_descr.ReadOnly = true;
			column_descr.Resizable = DataGridViewTriState.False;

			column_value.Name = "Value";
			column_value.HeaderText = "Value";
			column_value.Resizable = DataGridViewTriState.False;

			column_descr.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			column_value.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			column_descr.SortMode = DataGridViewColumnSortMode.NotSortable;
			column_value.SortMode = DataGridViewColumnSortMode.NotSortable;
			BinaryDataView.MultiSelect = false;

			BinaryDataView.Columns.Add(column_descr);
			BinaryDataView.Columns.Add(column_value);
			BinaryDataView.RowHeadersWidth = 30;
		}

		private void DataSet_OpenFile_Click(object sender, EventArgs e)
		{
			this.BrowseGameDirDialog.Description = "Select the NFS: Underground 2 directory that you want to work on.";

			if (BrowseGameDirDialog.ShowDialog() == DialogResult.OK)
			{
				this.LoadDBUnderground2(BrowseGameDirDialog.SelectedPath, true);
			}
		}

		private void DataSet_SaveFile_Click(object sender, EventArgs e)
		{
			var watch = new System.Diagnostics.Stopwatch();
			watch.Start();
			Process.SaveData(dbUG2, Properties.Settings.Default.EnableCompression);
			watch.Stop();
			DataSet_Status.Text = $"Finished saving data in {watch.ElapsedMilliseconds}ms | {DateTime.Now.ToString()}";
		}

		private void BinaryTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			BinaryDataView.Columns.Clear();

			if (BinaryTree.SelectedNode == null || BinaryTree.SelectedNode.Parent == null) return;
			var obj = dbUG2.GetPrimitive(Utils.Path.SplitPath(BinaryTree.SelectedNode.FullPath));
			if (obj == null) return;
			var list = obj.GetAccessibles(GlobalLib.Database.Collection.eGetInfoType.PROPERTY_NAMES);

			this.BinaryDataViewColumnInit();

			var accessibles = new List<string>(list.Length);
			for (int a1 = 0; a1 < list.Length; ++a1)
				accessibles.Add(list[a1].ToString());
			accessibles.Sort();

			foreach (var access in accessibles)
			{
				string field = access.ToString();
				if (obj.OfEnumerableType(field))
				{
					var attribcell = new DataGridViewTextBoxCell();
					var valuecell = new DataGridViewComboBoxCell();
					attribcell.Value = field;
					valuecell.Items.AddRange(obj.GetPropertyEnumerableTypes(field));
					valuecell.Value = obj.GetValue(field);
					valuecell.FlatStyle = FlatStyle.Flat;
					valuecell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
					valuecell.Style.BackColor = Color.FromArgb(30, 30, 45);
					var row = new DataGridViewRow();
					row.Cells.AddRange(attribcell, valuecell);
					this.BinaryDataView.Rows.Add(row);
				}
				else
				{
					var attribcell = new DataGridViewTextBoxCell();
					var valuecell = new DataGridViewTextBoxCell();
					attribcell.Value = field;
					valuecell.Value = obj.GetValue(field);
					var row = new DataGridViewRow();
					row.Cells.AddRange(attribcell, valuecell);
					this.BinaryDataView.Rows.Add(row);
				}
			}
		}

		private void DataSet_ReloadFile_Click(object sender, EventArgs e)
		{
			this.LoadDBUnderground2(Process.GlobalDir, true);
		}

		private void DataSet_Hasher_Click(object sender, EventArgs e)
		{
			var HasherWindow = new Tools.Hasher();
			HasherWindow.Show();
		}

		private void DataSet_Raider_Click(object sender, EventArgs e)
		{
			var RaiderWindow = new Tools.Raider();
			RaiderWindow.Show();
		}

		private void DataSet_Color_Click(object sender, EventArgs e)
		{
			var ColorWindow = new Tools.ColorPicker();
			ColorWindow.Show();
		}

		private void DataSet_Swatch_Click(object sender, EventArgs e)
		{
			var SwatchWindow = new Tools.SwatchPicker();
			SwatchWindow.Show();
		}

		private void DataSet_Exit_Click(object sender, EventArgs e)
		{
			this.Underground2_FormClosing(this, null);
		}

		private void Underground2_FormClosing(object sender, FormClosingEventArgs e)
		{
			var list = Application.OpenForms.Cast<Form>().ToList();
			for (int a1 = list.Count - 1; a1 >= 0; --a1)
			{
				if (list[a1].Name != "Main" && list[a1].Name != this.Name)
					list[a1].Close();
			}
		}

		private void Underground2_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.dbUG2 = null;
			GC.Collect(0, GCCollectionMode.Forced);
			GC.Collect(1, GCCollectionMode.Forced);
			GC.Collect(2, GCCollectionMode.Forced);
		}

		private void DataSet_CreateBackups_Click(object sender, EventArgs e)
		{
			this.CreateBackupFiles(true);
		}

		private void DataSet_RestoreBackups_Click(object sender, EventArgs e)
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
				if (File.Exists(a2) && File.Exists(b2) && File.Exists(c2) && File.Exists(d2))
				{
					if (File.Exists(a1)) File.Delete(a1);
					if (File.Exists(b1)) File.Delete(b1);
					if (File.Exists(c1)) File.Delete(c1);
					if (File.Exists(d1)) File.Delete(d1);
					File.Copy(a2, a1); File.Copy(b2, b1);
					File.Copy(c2, c1); File.Copy(d2, d1);
					DataSet_ReloadFile_Click(null, EventArgs.Empty); // reload database
					MessageBox.Show("All backups was successfully restored.", "Success");
				}
				else
					MessageBox.Show("Unable to restore backups: one or more backup files are missing.", "Failuer");
			}
			catch (Exception ex)
			{
				while (ex.InnerException != null) ex = ex.InnerException;
				MessageBox.Show($"Error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void DataSet_UnlockFiles_Click(object sender, EventArgs e)
		{
			// Unlock Memory Files
			GlobalLib.Utils.MemoryUnlock.FastUnlock(Process.GlobalDir + @"\GLOBAL\CarHeadersMemoryFile.bin");
			GlobalLib.Utils.MemoryUnlock.FastUnlock(Process.GlobalDir + @"\GLOBAL\FrontEndMemoryFile.bin");
			GlobalLib.Utils.MemoryUnlock.FastUnlock(Process.GlobalDir + @"\GLOBAL\InGameMemoryFile.bin");
			GlobalLib.Utils.MemoryUnlock.LongUnlock(Process.GlobalDir + @"\GLOBAL\GlobalMemoryFile.bin");

			MessageBox.Show("Memory files were successfully unlocked for modding.", "Success");
		}

		private void DataSet_RunGame_Click(object sender, EventArgs e)
		{
			var launch = new System.Diagnostics.ProcessStartInfo("speed2.exe")
			{
				WorkingDirectory = Process.GlobalDir,
			};
			System.Diagnostics.Process.Start(launch);
		}

		private void DataSet_DBInfo_Click(object sender, EventArgs e)
		{
			MessageBox.Show(this.dbUG2.GetDatabaseInfo(), "Database Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void BinaryTreeAddNode_Click(object sender, EventArgs e)
		{
			// Nodes can be added only to roots
			if (BinaryTree.SelectedNode == null) return;

			if (BinaryTree.SelectedNode.Parent != null)
			{
				MessageBox.Show("Nodes can be added only to root collections.", "Warning",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var QuickMenu = new Interact.Input();
			if (QuickMenu.ShowDialog() == DialogResult.OK)
			{
				string CName = QuickMenu.CollectionName;
				string root = BinaryTree.SelectedNode.Text;
				if (this.dbUG2.TryAddClass(CName, root, out string error))
				{
					Generate.WriteCommand(Commands.add, this.ColoredTextForm, root, CName);
					this.LoadBinaryTree(true);
					return;
				}
				else
				{
					MessageBox.Show(error, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					this.BinaryTreeAddNode_Click(sender, e);
				}
			}
		}

		private void BinaryTreeDeleteNode_Click(object sender, EventArgs e)
		{
			if (BinaryTree.SelectedNode == null) return;
			if (BinaryTree.SelectedNode.Parent == null)
			{
				MessageBox.Show("Root collection cannot be deleted.", "Warning",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (BinaryTree.SelectedNode.Parent.Parent != null)
			{
				MessageBox.Show("Only collections can be deleted.", "Warning",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string CName = BinaryTree.SelectedNode.Text;
			string root = BinaryTree.SelectedNode.Parent.Text;

			if (this.dbUG2.TryRemoveClass(CName, root, out string error))
			{
				Generate.WriteCommand(Commands.delete, this.ColoredTextForm, root, CName);
				this.LoadBinaryTree(false);
			}
			else
			{
				MessageBox.Show($"Error occured: {error}", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void BinaryTreeCopyNode_Click(object sender, EventArgs e)
		{
			if (BinaryTree.SelectedNode == null) return;
			if (BinaryTree.SelectedNode.Parent == null)
			{
				MessageBox.Show("Root collection cannot be copied.", "Warning",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (BinaryTree.SelectedNode.Parent.Parent != null)
			{
				MessageBox.Show("Only collections can be copied.", "Warning",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var QuickMenu = new Interact.Input();
			if (QuickMenu.ShowDialog() == DialogResult.OK)
			{
				string newname = QuickMenu.CollectionName;
				string copyname = BinaryTree.SelectedNode.Text;
				string root = BinaryTree.SelectedNode.Parent.Text;
				if (this.dbUG2.TryCloneClass(newname, copyname, root, out string error))
				{
					Generate.WriteCommand(Commands.copy, this.ColoredTextForm, root, copyname, newname);
					this.LoadBinaryTree(true);
					return;
				}
				else
				{
					MessageBox.Show(error, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					this.BinaryTreeCopyNode_Click(sender, e);
				}
			}
		}

		private void BinaryTreeExportNode_Click(object sender, EventArgs e)
		{
			if (BinaryTree.SelectedNode == null) return;
			if (BinaryTree.SelectedNode.Parent == null) return;
			if (BinaryTree.SelectedNode.Parent.Parent != null)
			{
				MessageBox.Show("Only collections can be exported.", "Warning",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (ExportCollectionDialog.ShowDialog() == DialogResult.OK)
			{
				string path = ExportCollectionDialog.FileName;
				string CName = BinaryTree.SelectedNode.Text;
				string root = BinaryTree.SelectedNode.Parent.Text;
				if (this.dbUG2.TryExportClass(CName, root, path, out string error))
				{
					MessageBox.Show($"Successfully exported collection {CName} to {path}.", "Success",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show($"Error occured: {error}", "Warning",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
