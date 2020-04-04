﻿using System;
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
	public partial class Shared : Form
	{
		private BasicBase db;
		private string _dir = string.Empty;
		private GameINT _game = GameINT.None;

		private void InstantiateControls()
		{
			this.DataSet_Split2.Panel2.Controls.Add(this.ColoredTextForm);
			this.DataSet_Split2.Panel1.Controls.Add(this.BinaryDataView);
			this.DataSet_Split1.Panel2.Controls.Add(this.DataSet_Split2);
			this.DataSet_Split1.Panel1.Controls.Add(this.BinaryTree);
			Process.MessageShow = true;
		}

		public Shared()
		{
			this.InitializeComponent();
			this.InstantiateControls();
			this.DataSet_MenuStrip.Renderer = new MyRenderer();
		}

		public Shared(GameINT game, string dir, bool forceload)
		{
			this.InitializeComponent();
			this.InstantiateControls();
			this.DataSet_MenuStrip.Renderer = new MyRenderer();

			this._game = game;
			this._dir = dir;
			if (forceload) this.LoadDatabase(this._dir, false);
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
			this.DataSet_ReloadFile.Enabled = true;
			this.DataSet_SaveFile.Enabled = true;
			this.DataSet_ImportFile.Enabled = true;
			this.DataSet_ProcessCommand.Enabled = true;
			this.DataSet_GenerateCommand.Enabled = true;
			this.DataSet_RestoreBackups.Enabled = true;
			this.DataSet_CreateBackups.Enabled = true;
			this.DataSet_UnlockFiles.Enabled = true;
			this.DataSet_RunGame.Enabled = true;
			this.DataSet_ExportAllTextures.Enabled = true;
			this.DataSet_DBInfo.Enabled = true;
			this.EndscriptToolStripMenuItemI.Enabled = true;
		}

		private void DisableButtons()
		{
			this.DataSet_ReloadFile.Enabled = false;
			this.DataSet_SaveFile.Enabled = false;
			this.DataSet_ImportFile.Enabled = false;
			this.DataSet_ProcessCommand.Enabled = false;
			this.DataSet_GenerateCommand.Enabled = false;
			this.DataSet_RestoreBackups.Enabled = false;
			this.DataSet_CreateBackups.Enabled = false;
			this.DataSet_UnlockFiles.Enabled = false;
			this.DataSet_RunGame.Enabled = false;
			this.DataSet_ExportAllTextures.Enabled = false;
			this.DataSet_DBInfo.Enabled = false;
			this.EndscriptToolStripMenuItemI.Enabled = false;
		}

		private void CreateBackupFiles(bool force)
		{
			try
			{
				string a1 = this._dir + @"\GLOBAL\GlobalA.bun";
				string a2 = this._dir + @"\GLOBAL\GlobalA.bun.bacc";
				string b1 = this._dir + @"\GLOBAL\GlobalB.lzc";
				string b2 = this._dir + @"\GLOBAL\GlobalB.lzc.bacc";
				string c1 = this._dir + @"\LANGUAGES\English_Global.bin";
				string c2 = this._dir + @"\LANGUAGES\English_Global.bin.bacc";
				string d1 = this._dir + @"\LANGUAGES\Labels_Global.bin";
				string d2 = this._dir + @"\LANGUAGES\Labels_Global.bin.bacc";
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
				MessageBox.Show($"Error occured: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void TerminateLoad()
		{
			this.db = null;
			this.DataSet_Status.Text = $"Failed to load data | {DateTime.Now.ToString()}";
			this.BinaryTree.Nodes.Clear();
			this.BinaryDataView.Columns.Clear();
			this.DisableButtons();
		}

		private int GetLastShownRowIndex()
		{
			if (this.BinaryDataView.Rows != null && this.BinaryDataView.Rows.Count > 0)
				return this.BinaryDataView.FirstDisplayedScrollingRowIndex;
			else return 0;
		}

		private void ScrollDownToRowIndex(int index)
		{
			if (this.BinaryDataView.Rows != null && this.BinaryDataView.Rows.Count > index && index >= 0)
				this.BinaryDataView.FirstDisplayedScrollingRowIndex = index;
		}

		private void SelectNodeByFullPath(string fullpath, TreeNodeCollection collection)
		{
			foreach (TreeNode node in collection)
			{
				if (node.FullPath == fullpath)
				{
					this.BinaryTree.SelectedNode = node;
					return;
				}
				else if (node.Nodes != null && node.Nodes.Count > 0)
					this.SelectNodeByFullPath(fullpath, node.Nodes);
			}
		}

		private void LoadDatabase(string foldername, bool showerror)
		{
			var GlobalA = File.Exists(foldername + @"\Global\GlobalA.bun");
			var GlobalB = File.Exists(foldername + @"\Global\GlobalB.lzc");
			var LangGen = File.Exists(foldername + @"\Languages\English_Global.bin");
			var LangLab = File.Exists(foldername + @"\Languages\Labels_Global.bin");
			var Stream = File.Exists(foldername + @"\Tracks\StreamL5RA.bun");
			var NFSC = File.Exists(foldername + @"\nfsc.exe");
			var Load = GlobalA && GlobalB && LangGen && LangLab && Stream && NFSC;
			if (!Load)
			{
				if (showerror)
					MessageBox.Show("Folder is not game's directory." + Environment.NewLine + "Please select the correct folder.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			this._dir = foldername;
			this.db = null;

			switch (this._game)
			{
				case GameINT.Carbon:
					this.db = new GlobalLib.Database.Carbon();
					break;
				case GameINT.MostWanted:
					this.db = new GlobalLib.Database.MostWanted();
					break;
				case GameINT.Underground2:
					this.db = new GlobalLib.Database.Underground2();
					break;
				default:
					this.TerminateLoad();
					return;
			}

			var watch = new System.Diagnostics.Stopwatch();
			watch.Start();
			bool valid = Process.LoadData(this.db, this._dir);
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

		private void LoadBinaryTree(bool load_last_select, string newpath = null)
		{
			string path = null;
			int index = 0;
			if (load_last_select)
			{
				if (newpath == null) path = this.BinaryTree.SelectedNode.FullPath;
				else path = newpath;
				index = this.GetLastShownRowIndex();
			}
			this.BinaryTree.Nodes.Clear();
			this.BinaryDataView.Columns.Clear();
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbC.CarTypeInfos.ThisName, this.dbC.CarTypeInfos.GetAllNodes()));
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbC.Materials.ThisName, this.dbC.Materials.GetAllNodes()));
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbC.PresetRides.ThisName, this.dbC.PresetRides.GetAllNodes()));
			this.BinaryTree.Nodes.Add(this.AppendTreeNode(this.dbC.PresetSkins.ThisName, this.dbC.PresetSkins.GetAllNodes()));
			foreach (TreeNode node in this.BinaryTree.Nodes) node.ImageIndex = 1;
			if (load_last_select)
			{
				this.SelectNodeByFullPath(path, this.BinaryTree.Nodes);
				this.ScrollDownToRowIndex(index);
			}
		}

		private void UpdateBinaryDataView()
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
			this.BrowseGameDirDialog.Description = "Select the NFS: Carbon directory that you want to work on.";

			if (BrowseGameDirDialog.ShowDialog() == DialogResult.OK)
			{
				this.LoadDatabase(BrowseGameDirDialog.SelectedPath, true);
			}
		}

		private void DataSet_SaveFile_Click(object sender, EventArgs e)
		{
			var watch = new System.Diagnostics.Stopwatch();
			watch.Start();
			Process.SaveData(dbC, Properties.Settings.Default.EnableCompression);
			watch.Stop();
			DataSet_Status.Text = $"Finished saving data in {watch.ElapsedMilliseconds}ms | {DateTime.Now.ToString()}";
		}

		private void BinaryTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			BinaryDataView.Columns.Clear();

			if (BinaryTree.SelectedNode == null || BinaryTree.SelectedNode.Parent == null) return;
			var obj = dbC.GetPrimitive(Utils.Path.SplitPath(BinaryTree.SelectedNode.FullPath));
			if (obj == null) return;
			var list = obj.GetAccessibles(GlobalLib.Reflection.Enum.eGetInfoType.PROPERTY_NAMES);

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
			this.LoadDatabase(this._dir, true);
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
			this.Carbon_FormClosing(this, null);
			this.Close();
		}

		private void Carbon_FormClosing(object sender, FormClosingEventArgs e)
		{
			var list = Application.OpenForms.Cast<Form>().ToList();
			for (int a1 = list.Count - 1; a1 >= 0; --a1)
			{
				if (list[a1].Name != "Main" && list[a1].Name != this.Name)
					list[a1].Close();
			}
		}

		private void Carbon_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.dbC = null;
			Utils.CleanUp.GCCollect();
		}

		private void DataSet_CreateBackups_Click(object sender, EventArgs e)
		{
			this.CreateBackupFiles(true);
		}

		private void DataSet_RestoreBackups_Click(object sender, EventArgs e)
		{
			try
			{
				string a1 = this._dir + @"\GLOBAL\GlobalA.bun";
				string a2 = this._dir + @"\GLOBAL\GlobalA.bun.bacc";
				string b1 = this._dir + @"\GLOBAL\GlobalB.lzc";
				string b2 = this._dir + @"\GLOBAL\GlobalB.lzc.bacc";
				string c1 = this._dir + @"\LANGUAGES\English_Global.bin";
				string c2 = this._dir + @"\LANGUAGES\English_Global.bin.bacc";
				string d1 = this._dir + @"\LANGUAGES\Labels_Global.bin";
				string d2 = this._dir + @"\LANGUAGES\Labels_Global.bin.bacc";
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
			GlobalLib.Utils.MemoryUnlock.FastUnlock(this._dir + @"\GLOBAL\CarHeadersMemoryFile.bin");
			GlobalLib.Utils.MemoryUnlock.FastUnlock(this._dir + @"\GLOBAL\FrontEndMemoryFile.bin");
			GlobalLib.Utils.MemoryUnlock.FastUnlock(this._dir + @"\GLOBAL\InGameMemoryFile.bin");
			GlobalLib.Utils.MemoryUnlock.FastUnlock(this._dir + @"\GLOBAL\PermanentMemoryFile.bin");
			GlobalLib.Utils.MemoryUnlock.LongUnlock(this._dir + @"\GLOBAL\GlobalMemoryFile.bin");

			MessageBox.Show("Memory files were successfully unlocked for modding.", "Success");
		}

		private void DataSet_RunGame_Click(object sender, EventArgs e)
		{
			var launch = new System.Diagnostics.ProcessStartInfo("NFSC.exe")
			{
				WorkingDirectory = this._dir,
			};
			System.Diagnostics.Process.Start(launch);
		}

		private void DataSet_DBInfo_Click(object sender, EventArgs e)
		{
			MessageBox.Show(this.dbC.GetDatabaseInfo(), "Database Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
				if (this.dbC.TryAddCollection(CName, root, out string error))
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

			if (this.dbC.TryRemoveCollection(CName, root, out string error))
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
				if (this.dbC.TryCloneCollection(newname, copyname, root, out string error))
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
				if (this.dbC.TryExportCollection(CName, root, path, out string error))
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

		private void BinaryDataView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			// If current cell is readonly -> simply return
			if (BinaryDataView.CurrentCell.ReadOnly)
				return;
			// Else if value is unchanged -> return as well
			else if (BinaryDataView.CurrentCell.Value.ToString() == e.FormattedValue.ToString())
				return;

			var field = BinaryDataView.Rows[e.RowIndex].Cells[0].Value.ToString();
			var value = e.FormattedValue.ToString();
			var tokens = Utils.Path.SplitPath(BinaryTree.SelectedNode.FullPath);
			var cla = this.dbC.GetPrimitive(tokens);
			if (cla == null) return;

			string error = null;
			if (!cla.SetValue(field, value, ref error))
			{
				MessageBox.Show($"Error occured: {error}", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				e.Cancel = true;
				return;
			}

			if (value.Contains(" ")) value = $"\"{value}\"";
			var args = new string[tokens.Length + 2];
			for (int a1 = 0; a1 < tokens.Length; ++a1)
				args[a1] = tokens[a1];
			args[args.Length - 2] = field;
			args[args.Length - 1] = value;
			Generate.WriteCommand(Commands.update, this.ColoredTextForm, args);
		}

		private void BinaryDataView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (BinaryDataView.Rows[e.RowIndex].Cells[0].Value.ToString() == "CollectionName")
			{
				var CName = BinaryDataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
				var node = BinaryTree.SelectedNode.FullPath;
				var path = node.Substring(0, node.LastIndexOf(BinaryTree.PathSeparator));
				this.LoadBinaryTree(true, $"{path}{BinaryTree.PathSeparator}{CName}");
			}
			else
			{
				this.UpdateBinaryDataView();
			}
		}

		private void DataSet_ClearEditor_Click(object sender, EventArgs e)
		{
			this.ColoredTextForm.Text = string.Empty;
		}

		private void DataSet_GenerateCommand_Click(object sender, EventArgs e)
		{
			if (BinaryDataView.Columns != null && BinaryDataView.Columns.Count == 2)
			{
				var tokens = Utils.Path.SplitPath(BinaryTree.SelectedNode.FullPath);
				var field = BinaryDataView.Rows[BinaryDataView.CurrentCell.RowIndex].Cells[0].Value.ToString();
				var value = BinaryDataView.Rows[BinaryDataView.CurrentCell.RowIndex].Cells[1].Value.ToString();
				var args = new string[tokens.Length + 2];
				for (int a1 = 0; a1 < tokens.Length; ++a1)
					args[a1] = tokens[a1];
				if (value.Contains(" ")) value = $"\"{value}\"";
				args[args.Length - 2] = field;
				args[args.Length - 1] = value;
				Generate.WriteCommand(Commands.update, this.ColoredTextForm, args);
			}
		}

		private void OpenReadmeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (File.Exists("Readme.txt"))
				System.Diagnostics.Process.Start("explorer", "Readme.txt");
			else
				MessageBox.Show("Could not find Readme.txt file.", "Failure");
		}

		private void DataSet_AboutBox_Click(object sender, EventArgs e)
		{
			MessageBox.Show($"Binary by MaxHwoy v0.8.5 Beta.{Environment.NewLine}Do not distribute.", "About",
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void EndscriptToolStripMenuItemI_Click(object sender, EventArgs e)
		{
			if (OpenEndscriptDialog.ShowDialog() == DialogResult.OK)
			{
				if (Core.ProcessEndscript(OpenEndscriptDialog.FileName, dbC, out var label, out var text))
				{
					this.DataSet_Status.Text = label;
					this.ColoredTextForm.Text += text;
					this.LoadBinaryTree(true);
				}
			}
		}

		private void DataSet_ProcessCommand_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(ColoredTextForm.Text)) return;
			var line = ColoredTextForm.GetLine(ColoredTextForm.Selection.FromLine).Text;
			var error = Core.ExecuteEndscriptLine(line, this.dbC);
			if (error != null)
			{
				MessageBox.Show($"Error occured: {error}", "Error");
				return;
			}
			Core.WriteEndscriptLine(line);
			if (Core.RefreshFullTree(line))
				this.LoadBinaryTree(true);
			else
				this.UpdateBinaryDataView();
		}

		private void MaterialToolStripMenuItemI_Click(object sender, EventArgs e)
		{
			if (this.OpenBinFileDialog.ShowDialog() == DialogResult.OK)
			{
				foreach (var file in this.OpenBinFileDialog.FileNames)
				{
					if (!this.db.TryImportCollection("Materials", file, out var error))
						MessageBox.Show($"Unable to import file {file}; reason: {error}.", "Error",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				this.LoadBinaryTree(true);
			}
		}

		private void CarTypeInfoToolStripMenuItemI_Click(object sender, EventArgs e)
		{
			if (this.OpenBinFileDialog.ShowDialog() == DialogResult.OK)
			{
				foreach (var file in this.OpenBinFileDialog.FileNames)
				{
					if (!this.db.TryImportCollection("CarTypeInfos", file, out var error))
						MessageBox.Show($"Unable to import file {file}; reason: {error}.", "Error",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				this.LoadBinaryTree(true);
			}
		}

		private void PresetRideToolStripMenuItemI_Click(object sender, EventArgs e)
		{
			if (this.OpenBinFileDialog.ShowDialog() == DialogResult.OK)
			{
				foreach (var file in this.OpenBinFileDialog.FileNames)
				{
					if (!this.db.TryImportCollection("PresetRides", file, out var error))
						MessageBox.Show($"Unable to import file {file}; reason: {error}.", "Error",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				this.LoadBinaryTree(true);
			}
		}

		private void PresetSkinToolStripMenuItemI_Click(object sender, EventArgs e)
		{
			if (this.OpenBinFileDialog.ShowDialog() == DialogResult.OK)
			{
				foreach (var file in this.OpenBinFileDialog.FileNames)
				{
					if (!this.db.TryImportCollection("PresetSkins", file, out var error))
						MessageBox.Show($"Unable to import file {file}; reason: {error}.", "Error",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				this.LoadBinaryTree(true);
			}
		}

		private void CollisionToolStripMenuItemI_Click(object sender, EventArgs e)
		{
			if (this.OpenBinFileDialog.ShowDialog() == DialogResult.OK)
			{
				var file = Path.GetFileNameWithoutExtension(this.OpenBinFileDialog.FileName);
				if (!this.db.AddCollision(file, this.OpenBinFileDialog.FileName, out var error))
					MessageBox.Show($"Error occured: {error}", "Error", MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				else
					MessageBox.Show($"Collision named {file} has been successfully imported.", "Success",
						MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
		}
	}
}