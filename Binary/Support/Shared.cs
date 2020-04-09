/********************************************************************************
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
using System.Data;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;
using Binary.Endscript;
using GlobalLib.Core;
using GlobalLib.Utils;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Database.Collection;
using GlobalLib.Support.Shared.Class;



namespace Binary.Support
{
	public partial class Shared : Form
	{
		private BasicBase db;
		private string _dir = string.Empty;
		private GameINT _game = GameINT.None;
		private const string FNGroups = "FNGroups";
		private const string TPKBlocks = "TPKBlocks";
		private const string STRBlocks = "STRBlocks";
		private bool _same_root_change = false;

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
			if (forceload) this.LoadDatabase(this._dir);
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

		public string GetDirectory() => this._dir;

		#region Supportive

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
			switch (this._game)
			{
				case GameINT.Carbon:
					this.CollisionToolStripMenuItemI.Enabled = true;
					this.DataSet_BoundsList.Enabled = true;
					this.PresetSkinToolStripMenuItemI.Enabled = true;
					break;
				case GameINT.MostWanted:
					this.CollisionToolStripMenuItemI.Enabled = true;
					this.DataSet_BoundsList.Enabled = true;
					break;
				default:
					break;
			}
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
			this.CollisionToolStripMenuItemI.Enabled = false;
			this.DataSet_BoundsList.Enabled = false;
			this.PresetSkinToolStripMenuItemI.Enabled = false;
		}

		private void CreateBackupFiles(bool force)
		{
			try
			{
				switch (this._game)
				{
					case GameINT.Carbon:
						foreach (var pair in Utils.Filenames.Carbon)
						{
							var original = this._dir + pair.Item1;
							var recovery = this._dir + pair.Item2;
							if (!force)
							{
								if (!File.Exists(recovery)) File.Copy(original, recovery);
							}
							else
							{
								if (File.Exists(recovery)) File.Delete(recovery);
								File.Copy(original, recovery);
							}
						}
						break;

					case GameINT.MostWanted:
						foreach (var pair in Utils.Filenames.MostWanted)
						{
							var original = this._dir + pair.Item1;
							var recovery = this._dir + pair.Item2;
							if (!force)
							{
								if (!File.Exists(recovery)) File.Copy(original, recovery);
							}
							else
							{
								if (File.Exists(recovery)) File.Delete(recovery);
								File.Copy(original, recovery);
							}
						}
						break;

					case GameINT.Underground2:
						foreach (var pair in Utils.Filenames.Underground2)
						{
							var original = this._dir + pair.Item1;
							var recovery = this._dir + pair.Item2;
							if (!force)
							{
								if (!File.Exists(recovery)) File.Copy(original, recovery);
							}
							else
							{
								if (File.Exists(recovery)) File.Delete(recovery);
								File.Copy(original, recovery);
							}
						}
						break;

					default:
						return;
				}
			}
			catch (Exception ex)
			{
				while (ex.InnerException != null) ex = ex.InnerException;
				MessageBox.Show($"Error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

		#endregion

		#region Selections

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

		private eRootType CheckRootSelectionType()
		{
			if (this.BinaryTree.SelectedNode == null || this.BinaryTree.SelectedNode.Parent == null)
				return eRootType.Empty;
			if (this.BinaryTree.SelectedNode.Parent.Text == FNGroups) return eRootType.FNGroups;
			else if (this.BinaryTree.SelectedNode.Parent.Text == TPKBlocks) return eRootType.TPKBlocks;
			else if (this.BinaryTree.SelectedNode.Parent.Text == STRBlocks) return eRootType.STRBlocks;
			else return eRootType.Regular;
		}

		private TreeNode AppendTreeNode(string name, List<VirtualNode> subnodes)
		{
			var treenode = new TreeNode(name);
			foreach (var subnode in subnodes)
				treenode.Nodes.Add(this.AppendTreeNode(subnode.NodeName, subnode.SubNodes));
			return treenode;
		}

		#endregion

		#region Loading

		private void LoadDatabase(string foldername)
		{
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

			var properties = this.db.GetType().GetProperties().ToList();
			properties.Sort((p, q) => p.Name.CompareTo(q.Name));

			foreach (var property in properties)
			{
				if (!ReflectX.IsGenericDefinition(property.PropertyType, typeof(Root<>)))
					continue;
				var name = property.PropertyType.GetProperty("ThisName")
					.GetValue(property.GetValue(this.db)).ToString();
				var nodes = property.PropertyType
					.GetMethod("GetAllNodes", new Type[0] { })
					.Invoke(property.GetValue(this.db), new object[0] { })
					as List<VirtualNode>;
				this.BinaryTree.Nodes.Add(this.AppendTreeNode(name, nodes));
			}

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

		private void BinaryDataViewRegColumnInit()
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
			this.BinaryDataView.MultiSelect = false;

			this.BinaryDataView.Columns.Add(column_descr);
			this.BinaryDataView.Columns.Add(column_value);
			this.BinaryDataView.RowHeadersWidth = 30;
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
			this.db = null;
			Utils.CleanUp.GCCollect();
		}

		#endregion

		#region DataSet

		private void DataSet_OpenFile_Click(object sender, EventArgs e)
		{
			this.BrowseGameDirDialog.Description = $"Select the NFS: {this._game} directory that you want to work on.";

			if (this.BrowseGameDirDialog.ShowDialog() == DialogResult.OK)
			{
				this.LoadDatabase(this.BrowseGameDirDialog.SelectedPath);
			}
		}

		private void DataSet_SaveFile_Click(object sender, EventArgs e)
		{
			var watch = new System.Diagnostics.Stopwatch();
			watch.Start();
			Process.SaveData(this.db, this._dir, Properties.Settings.Default.EnableCompression);
			watch.Stop();
			DataSet_Status.Text = $"Finished saving data in {watch.ElapsedMilliseconds}ms | {DateTime.Now.ToString()}";
		}

		private void DataSet_ReloadFile_Click(object sender, EventArgs e)
		{
			this.LoadDatabase(this._dir);
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

		private void DataSet_CreateBackups_Click(object sender, EventArgs e)
		{
			this.CreateBackupFiles(true);
		}

		private void DataSet_RestoreBackups_Click(object sender, EventArgs e)
		{
			try
			{
				bool exists = false;
				switch (this._game)
				{
					case GameINT.Carbon:
						foreach (var pair in Utils.Filenames.Carbon)
						{
							var original = this._dir + pair.Item1;
							var recovery = this._dir + pair.Item2;
							if (File.Exists(recovery))
							{
								exists = true;
								File.Delete(original);
								File.Copy(recovery, original);
							}
						}
						break;

					case GameINT.MostWanted:
						foreach (var pair in Utils.Filenames.MostWanted)
						{
							var original = this._dir + pair.Item1;
							var recovery = this._dir + pair.Item2;
							if (File.Exists(recovery))
							{
								exists = true;
								File.Delete(original);
								File.Copy(recovery, original);
							}
						}
						break;

					case GameINT.Underground2:
						foreach (var pair in Utils.Filenames.Underground2)
						{
							var original = this._dir + pair.Item1;
							var recovery = this._dir + pair.Item2;
							if (File.Exists(recovery))
							{
								exists = true;
								File.Delete(original);
								File.Copy(recovery, original);
							}
						}
						break;

					default:
						return;
				}

				if (exists)
				{
					this.DataSet_ReloadFile_Click(null, EventArgs.Empty); // reload database
					MessageBox.Show("All backups was successfully restored.", "Success");
				}
				else
					MessageBox.Show("Unable to restore backups: none of backups were found.", "Failure",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
			MemoryUnlock.FastUnlock(this._dir + @"\GLOBAL\CarHeadersMemoryFile.bin");
			MemoryUnlock.FastUnlock(this._dir + @"\GLOBAL\FrontEndMemoryFile.bin");
			MemoryUnlock.FastUnlock(this._dir + @"\GLOBAL\InGameMemoryFile.bin");
			MemoryUnlock.FastUnlock(this._dir + @"\GLOBAL\PermanentMemoryFile.bin");
			MemoryUnlock.LongUnlock(this._dir + @"\GLOBAL\GlobalMemoryFile.bin");

			MessageBox.Show("Memory files were successfully unlocked for modding.", "Success");
		}

		private void DataSet_RunGame_Click(object sender, EventArgs e)
		{
			string exe = string.Empty;
			switch (this._game)
			{
				case GameINT.Carbon:
					exe = "nfsc.exe";
					break;
				case GameINT.MostWanted:
					exe = "speed.exe";
					break;
				case GameINT.Underground2:
					exe = "speed2.exe";
					break;
				default:
					return;
			}
			var launch = new System.Diagnostics.ProcessStartInfo(exe)
			{
				WorkingDirectory = this._dir,
			};
			System.Diagnostics.Process.Start(launch);
		}

		private void DataSet_DBInfo_Click(object sender, EventArgs e)
		{
			MessageBox.Show(this.db.GetDatabaseInfo(), "Database Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void DataSet_BoundsList_Click(object sender, EventArgs e)
		{
			var BoundsForm = new Interact.BoundsList();
			BoundsForm.ShowDialog();
		}

		private void DataSet_Readme_Click(object sender, EventArgs e)
		{
			if (File.Exists("Readme.txt"))
				System.Diagnostics.Process.Start("explorer", "Readme.txt");
			else
				MessageBox.Show("Could not find Readme.txt file.", "Failure");
		}

		private void DataSet_AboutBox_Click(object sender, EventArgs e)
		{
			var AboutForm = new Interact.About();
			AboutForm.ShowDialog();
		}

		#endregion

		#region BinaryTree

		private void BinaryTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
		{
			this._same_root_change = false;
			if (this.BinaryTree.Nodes == null || this.BinaryTree.Nodes.Count == 0)
				return;
			if (this.BinaryTree.SelectedNode == null)
				return;
			if (this.BinaryDataView.Columns == null || this.BinaryDataView.Columns.Count == 0)
				return;
			var root_before = this.BinaryTree.SelectedNode.Parent?.Text;
			var root_after = e.Node.Parent?.Text;
			if (root_before == root_after)
				this._same_root_change = true;
		}

		private void BinaryTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			int index = 0;
			if (this._same_root_change)
				index = this.GetLastShownRowIndex();

			this.BinaryDataView.Columns.Clear();

			var roottype = this.CheckRootSelectionType();
			switch (roottype)
			{
				case eRootType.Empty:
					return;
				case eRootType.FNGroups:
					this.ShowAllFNGProperties();
					return;
				case eRootType.TPKBlocks:
					this.ShowAllTPKProperties();
					return;
				case eRootType.STRBlocks:
					this.ShowAllSTRProperties();
					return;
				default:
					break;
			}

			var obj = this.db.GetPrimitive(Utils.Path.SplitPath(this.BinaryTree.SelectedNode.FullPath));
			if (obj == null) return;
			var list = obj.GetAccessibles(eGetInfoType.PROPERTY_NAMES);

			this.BinaryDataViewRegColumnInit();

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

			if (this._same_root_change)
				this.ScrollDownToRowIndex(index);
		}

		private void BinaryDataView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex < 0) return;
			var roottype = this.CheckRootSelectionType();
			switch (roottype)
			{
				case eRootType.FNGroups:
					this.LaunchFNGEditor(e.RowIndex);
					return;
				case eRootType.TPKBlocks:
					this.LaunchTPKEditor(e.RowIndex);
					return;
				case eRootType.STRBlocks:
					this.LaunchSTREditor(e.RowIndex);
					return;
				default:
					break;
			}
		}

		private void BinaryTreeAddNode_Click(object sender, EventArgs e)
		{
			// Nodes can be added only to roots
			if (this.BinaryTree.SelectedNode == null) return;

			if (this.BinaryTree.SelectedNode.Parent != null)
			{
				MessageBox.Show("Nodes can be added only to root collections.", "Warning",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var QuickMenu = new Interact.Input();
			if (QuickMenu.ShowDialog() == DialogResult.OK)
			{
				string CName = QuickMenu.CollectionName;
				string root = this.BinaryTree.SelectedNode.Text;
				if (this.db.TryAddCollection(CName, root, out string error))
				{
					Generate.WriteCommand(eCommands.add, this.ColoredTextForm, root, CName);
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
			if (this.BinaryTree.SelectedNode == null) return;
			if (this.BinaryTree.SelectedNode.Parent == null)
			{
				MessageBox.Show("Root collection cannot be deleted.", "Warning",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (this.BinaryTree.SelectedNode.Parent.Parent != null)
			{
				MessageBox.Show("Only collections can be deleted.", "Warning",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string CName = this.BinaryTree.SelectedNode.Text;
			string root = this.BinaryTree.SelectedNode.Parent.Text;

			if (this.db.TryRemoveCollection(CName, root, out string error))
			{
				Generate.WriteCommand(eCommands.delete, this.ColoredTextForm, root, CName);
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
			if (this.BinaryTree.SelectedNode.Parent == null)
			{
				MessageBox.Show("Root collection cannot be copied.", "Warning",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (this.BinaryTree.SelectedNode.Parent.Parent != null)
			{
				MessageBox.Show("Only collections can be copied.", "Warning",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var QuickMenu = new Interact.Input();
			if (QuickMenu.ShowDialog() == DialogResult.OK)
			{
				string newname = QuickMenu.CollectionName;
				string copyname = this.BinaryTree.SelectedNode.Text;
				string root = this.BinaryTree.SelectedNode.Parent.Text;
				if (this.db.TryCloneCollection(newname, copyname, root, out string error))
				{
					Generate.WriteCommand(eCommands.copy, this.ColoredTextForm, root, copyname, newname);
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
			if (this.BinaryTree.SelectedNode == null) return;
			if (this.BinaryTree.SelectedNode.Parent == null) return;
			if (this.BinaryTree.SelectedNode.Parent.Parent != null)
			{
				MessageBox.Show("Only collections can be exported.", "Warning",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (this.ExportCollectionDialog.ShowDialog() == DialogResult.OK)
			{
				string path = this.ExportCollectionDialog.FileName;
				string CName = this.BinaryTree.SelectedNode.Text;
				string root = this.BinaryTree.SelectedNode.Parent.Text;
				if (this.db.TryExportCollection(CName, root, path, out string error))
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

		private void BinaryTreeScriptNode_Click(object sender, EventArgs e)
		{
			if (this.BinaryTree.SelectedNode == null) return;
			if (this.BinaryTree.SelectedNode.Parent == null) return;
			if (this.BinaryTree.SelectedNode.Parent.Parent != null)
			{
				MessageBox.Show("Only collections can be scripted.", "Warning",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var roottype = this.CheckRootSelectionType();
			switch (roottype)
			{
				case eRootType.Empty:
					return;
				case eRootType.FNGroups:
					MessageBox.Show($"{FNGroups} collections are not scriptable.", "Warning",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				case eRootType.TPKBlocks:
					MessageBox.Show($"{TPKBlocks} collections are not scriptable.", "Warning",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				case eRootType.STRBlocks:
					MessageBox.Show($"{STRBlocks} collections are not scriptable.", "Warning",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				default:
					break;
			}

			string CName = this.BinaryTree.SelectedNode.Text;
			string root = this.BinaryTree.SelectedNode.Parent.Text;
			var collection = this.db.GetCollection(CName, root);
			if (collection == null)
			{
				MessageBox.Show($"Unable to script collection {CName} in root {root}.", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var list = new List<string[]>();

			foreach (string field in collection.GetAccessibles(eGetInfoType.PROPERTY_NAMES))
			{
				if (field == "CollectionName") continue;
				var value = collection.GetValue(field);
				if (value.Contains(" ")) value = $"\"{value}\"";
				list.Add(new string[] { root, CName, field, value });
			}

			if (this.BinaryTree.SelectedNode.Nodes == null) goto LABEL_WRITE;

			foreach (TreeNode node in this.BinaryTree.SelectedNode.Nodes)
			{
				if (node.Nodes == null) continue;
				foreach (TreeNode subnode in node.Nodes)
				{
					var subroute = node.Text;
					var name = subnode.Text;
					var part = collection.GetSubPart(name, subroute);
					if (part == null) continue;
					foreach (string field in part.GetAccessibles(eGetInfoType.PROPERTY_NAMES))
					{
						var value = part.GetValue(field);
						if (value.Contains(" ")) value = $"\"{value}\"";
						list.Add(new string[] { root, CName, subroute, name, field, value });
					}
				}
			}

		LABEL_WRITE:
			foreach (var str in list)
			{
				Generate.WriteCommand(eCommands.update, this.ColoredTextForm, str);
			}
		}

		#endregion

		#region BinaryDataView

		private void BinaryDataView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			// If current cell is readonly -> simply return
			if (this.BinaryDataView.CurrentCell.ReadOnly)
				return;
			// Else if value is unchanged -> return as well
			else if (this.BinaryDataView.CurrentCell.Value.ToString() == e.FormattedValue.ToString())
				return;

			var field = this.BinaryDataView.Rows[e.RowIndex].Cells[0].Value.ToString();
			var value = e.FormattedValue.ToString();
			var tokens = Utils.Path.SplitPath(this.BinaryTree.SelectedNode.FullPath);
			var cla = this.db.GetPrimitive(tokens);
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
			Generate.WriteCommand(eCommands.update, this.ColoredTextForm, args);
		}

		private void BinaryDataView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (this.BinaryDataView.Rows[e.RowIndex].Cells[0].Value.ToString() == "CollectionName")
			{
				var CName = this.BinaryDataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
				var node = this.BinaryTree.SelectedNode.FullPath;
				var path = node.Substring(0, node.LastIndexOf(this.BinaryTree.PathSeparator));
				this.LoadBinaryTree(true, $"{path}{this.BinaryTree.PathSeparator}{CName}");
			}
			else
			{
				this.UpdateBinaryDataView();
			}
		}

		#endregion

		#region Endscript

		private void DataSet_ClearEditor_Click(object sender, EventArgs e)
		{
			this.ColoredTextForm.Text = string.Empty;
		}

		private void DataSet_GenerateCommand_Click(object sender, EventArgs e)
		{
			// Quick way to find out whether BinaryDataView shows neither FNGroup, STRBlock or TPKBlock data
			if (this.BinaryDataView.Columns != null && this.BinaryDataView.Columns.Count == 2)
			{
				var tokens = Utils.Path.SplitPath(this.BinaryTree.SelectedNode.FullPath);
				var field = this.BinaryDataView.Rows[this.BinaryDataView.CurrentCell.RowIndex].Cells[0].Value.ToString();
				var value = this.BinaryDataView.Rows[this.BinaryDataView.CurrentCell.RowIndex].Cells[1].Value.ToString();
				var args = new string[tokens.Length + 2];
				for (int a1 = 0; a1 < tokens.Length; ++a1)
					args[a1] = tokens[a1];
				if (value.Contains(" ")) value = $"\"{value}\"";
				args[args.Length - 2] = field;
				args[args.Length - 1] = value;
				Generate.WriteCommand(eCommands.update, this.ColoredTextForm, args);
			}
		}

		private void EndscriptToolStripMenuItemI_Click(object sender, EventArgs e)
		{
			if (this.OpenEndscriptDialog.ShowDialog() == DialogResult.OK)
			{
				if (Core.ProcessEndscript(this._dir, this.OpenEndscriptDialog.FileName, db,
					out var label, out var text))
				{
					this.DataSet_Status.Text = label;
					this.ColoredTextForm.Text += text;
					this.LoadBinaryTree(true);
				}
			}
		}

		private void DataSet_ProcessCommand_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(this.ColoredTextForm.Text)) return;
			var line = this.ColoredTextForm.GetLine(this.ColoredTextForm.Selection.FromLine).Text;
			var error = Core.ExecuteEndscriptLine(line, this.db);
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
				if (!this.db.TryAddCollision(file, this.OpenBinFileDialog.FileName, out var error))
					MessageBox.Show($"Error occured: {error}", "Error", MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				else
					MessageBox.Show($"Collision named {file} has been successfully imported.", "Success",
						MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
		}

		#endregion

		#region FNG

		private void BinaryDataViewFNGColumnInit()
		{
			var column_descr = new DataGridViewTextBoxColumn();
			var column_alpha = new DataGridViewTextBoxColumn();
			var column_red = new DataGridViewTextBoxColumn();
			var column_green = new DataGridViewTextBoxColumn();
			var column_blue = new DataGridViewTextBoxColumn();

			column_descr.Name = "Attribute";
			column_descr.HeaderText = "Attribute";
			column_descr.ReadOnly = true;
			column_descr.Resizable = DataGridViewTriState.False;

			column_alpha.Name = "Alpha";
			column_alpha.HeaderText = "Alpha";
			column_alpha.ReadOnly = true;
			column_alpha.Resizable = DataGridViewTriState.False;

			column_red.Name = "Red";
			column_red.HeaderText = "Red";
			column_red.ReadOnly = true;
			column_red.Resizable = DataGridViewTriState.False;

			column_green.Name = "Green";
			column_green.HeaderText = "Green";
			column_green.ReadOnly = true;
			column_green.Resizable = DataGridViewTriState.False;

			column_blue.Name = "Blue";
			column_blue.HeaderText = "Blue";
			column_blue.ReadOnly = true;
			column_blue.Resizable = DataGridViewTriState.False;

			column_descr.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			column_alpha.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			column_red.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			column_green.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			column_blue.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			column_descr.SortMode = DataGridViewColumnSortMode.NotSortable;
			column_alpha.SortMode = DataGridViewColumnSortMode.NotSortable;
			column_red.SortMode = DataGridViewColumnSortMode.NotSortable;
			column_green.SortMode = DataGridViewColumnSortMode.NotSortable;
			column_blue.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.BinaryDataView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.BinaryDataView.MultiSelect = false;

			this.BinaryDataView.Columns.Add(column_descr);
			this.BinaryDataView.Columns.Add(column_alpha);
			this.BinaryDataView.Columns.Add(column_red);
			this.BinaryDataView.Columns.Add(column_green);
			this.BinaryDataView.Columns.Add(column_blue);
			this.BinaryDataView.RowHeadersWidth = 30;
		}

		private void ShowAllFNGProperties()
		{
			string CName = this.BinaryTree.SelectedNode.Text;
			var fng = (FNGroup)this.db.GetCollection(CName, FNGroups);
			if (fng == null) return;

			this.BinaryDataViewFNGColumnInit();

			for (int a1 = 0; a1 < fng.InfoLength; ++a1)
			{
				var color = fng.GetColor(a1);
				var namecell = new DataGridViewTextBoxCell();
				var alphacell = new DataGridViewTextBoxCell();
				var redcell = new DataGridViewTextBoxCell();
				var greencell = new DataGridViewTextBoxCell();
				var bluecell = new DataGridViewTextBoxCell();
				namecell.Value = $"Color[{a1}]";
				alphacell.Value = color.Alpha.ToString();
				redcell.Value = color.Red.ToString();
				greencell.Value = color.Green.ToString();
				bluecell.Value = color.Blue.ToString();
				var row = new DataGridViewRow();
				row.DefaultCellStyle.BackColor = Color.FromArgb(color.Red, color.Green, color.Blue);
				if (row.DefaultCellStyle.BackColor.GetBrightness() > 0.5)
					row.DefaultCellStyle.ForeColor = Color.Black;
				else
					row.DefaultCellStyle.ForeColor = Color.White;
				row.Cells.AddRange(namecell, alphacell, redcell, greencell, bluecell);
				this.BinaryDataView.Rows.Add(row);
			}
		}

		private void LaunchFNGEditor(int RowIndex)
		{
			var fng = (FNGroup)this.db.GetCollection(this.BinaryTree.SelectedNode.Text, FNGroups);
			if (fng == null) return;

			var inter = this.BinaryDataView.Rows[RowIndex].Cells[0].Value.ToString();
			FormatX.GetInt32(inter, "Color[{X}]", out int index);
			var color = fng.GetColor(index);

			var FNGForm = new Interact.FEngEditor(color, index);
			FNGForm.ShowDialog();
			if (!string.IsNullOrWhiteSpace(FNGForm.CommandProcessed))
				Generate.WriteCommand(FNGForm.CommandProcessed, this.ColoredTextForm);
			this.UpdateBinaryDataView();
		}

		#endregion

		#region TPK

		private void BinaryDataViewTPKColumnInit()
		{
			var column_index = new DataGridViewTextBoxColumn();
			var column_cname = new DataGridViewTextBoxColumn();
			var column_compr = new DataGridViewTextBoxColumn();
			var column_width = new DataGridViewTextBoxColumn();
			var column_heigt = new DataGridViewTextBoxColumn();
			var column_nmmip = new DataGridViewTextBoxColumn();

			column_index.Name = "Key";
			column_index.HeaderText = "Key";
			column_index.ReadOnly = true;
			column_index.Resizable = DataGridViewTriState.False;

			column_cname.Name = "CollectionName";
			column_cname.HeaderText = "CollectionName";
			column_cname.ReadOnly = true;
			column_cname.Resizable = DataGridViewTriState.False;

			column_compr.Name = "Compression";
			column_compr.HeaderText = "Compression";
			column_compr.ReadOnly = true;
			column_compr.Resizable = DataGridViewTriState.False;

			column_width.Name = "Width";
			column_width.HeaderText = "Width";
			column_width.ReadOnly = true;
			column_width.Resizable = DataGridViewTriState.False;

			column_heigt.Name = "Height";
			column_heigt.HeaderText = "Height";
			column_heigt.ReadOnly = true;
			column_heigt.Resizable = DataGridViewTriState.False;

			column_nmmip.Name = "Mipmaps";
			column_nmmip.HeaderText = "MipMaps";
			column_nmmip.ReadOnly = true;
			column_nmmip.Resizable = DataGridViewTriState.False;

			column_index.Width = 80;
			column_cname.Width = 300;

			column_compr.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			column_width.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			column_heigt.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			column_nmmip.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			column_index.SortMode = DataGridViewColumnSortMode.NotSortable;
			column_cname.SortMode = DataGridViewColumnSortMode.NotSortable;
			column_compr.SortMode = DataGridViewColumnSortMode.NotSortable;
			column_width.SortMode = DataGridViewColumnSortMode.NotSortable;
			column_heigt.SortMode = DataGridViewColumnSortMode.NotSortable;
			column_nmmip.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.BinaryDataView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.BinaryDataView.MultiSelect = false;

			this.BinaryDataView.Columns.Add(column_index);
			this.BinaryDataView.Columns.Add(column_cname);
			this.BinaryDataView.Columns.Add(column_compr);
			this.BinaryDataView.Columns.Add(column_width);
			this.BinaryDataView.Columns.Add(column_heigt);
			this.BinaryDataView.Columns.Add(column_nmmip);
			this.BinaryDataView.RowHeadersWidth = 30;
		}

		private void ShowAllTPKProperties()
		{
			string CName = this.BinaryTree.SelectedNode.Text;
			var tpk = (TPKBlock)this.db.GetCollection(CName, TPKBlocks);
			if (tpk == null) return;

			// Use Reflection to get textures
			tpk.SortTexturesByType(true);
			var textures = tpk.GetType().GetProperty("Textures").GetValue(tpk) as IList;

			this.BinaryDataViewTPKColumnInit();
			
			foreach (Texture tex in textures)
			{
				var keycell = new DataGridViewTextBoxCell();
				var namecell = new DataGridViewTextBoxCell();
				var widthcell = new DataGridViewTextBoxCell();
				var heightcell = new DataGridViewTextBoxCell();
				var mipmapscell = new DataGridViewTextBoxCell();
				var compresscell = new DataGridViewTextBoxCell();
				keycell.Value = $"0x{tex.BinKey:X8}";
				namecell.Value = tex.CollectionName;
				widthcell.Value = tex.Width;
				heightcell.Value = tex.Height;
				mipmapscell.Value = tex.Mipmaps;
				compresscell.Value = tex.GetType().GetProperty("Compression").GetValue(tex).ToString();
				var row = new DataGridViewRow();
				row.Cells.AddRange(keycell, namecell, compresscell, widthcell, heightcell, mipmapscell);
				this.BinaryDataView.Rows.Add(row);
			}
		}

		private void LaunchTPKEditor(int RowIndex)
		{
			var tpk = (TPKBlock)this.db.GetCollection(this.BinaryTree.SelectedNode.Text, TPKBlocks);
			if (tpk == null) return;

			var inter = this.BinaryDataView.Rows[RowIndex].Cells[0].Value.ToString();
			var key = ConvertX.ToUInt32(inter);

			var TPKForm = new Interact.TPKEditor(tpk, key);
			TPKForm.ShowDialog();
			foreach (var command in TPKForm.CommandsProcessed)
				Generate.WriteCommand(command, this.ColoredTextForm);
			this.UpdateBinaryDataView();
		}

		#endregion

		#region STR

		private void BinaryDataViewSTRColumnInit()
		{
			var column_index = new DataGridViewTextBoxColumn();
			var column_bhash = new DataGridViewTextBoxColumn();
			var column_label = new DataGridViewTextBoxColumn();
			var column_descr = new DataGridViewTextBoxColumn();

			column_index.Name = "Index";
			column_index.HeaderText = "Index";
			column_index.ReadOnly = true;
			column_index.Resizable = DataGridViewTriState.False;

			column_bhash.Name = "Key";
			column_bhash.HeaderText = "Key";
			column_bhash.ReadOnly = true;
			column_bhash.Resizable = DataGridViewTriState.False;

			column_label.Name = "Label";
			column_label.HeaderText = "Label";
			column_label.ReadOnly = true;
			column_label.Resizable = DataGridViewTriState.False;

			column_descr.Name = "Text";
			column_descr.HeaderText = "Text";
			column_descr.ReadOnly = true;
			column_descr.Resizable = DataGridViewTriState.False;

			column_index.Width = 50;
			column_bhash.Width = 80;
			column_label.Width = 250;
			column_descr.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			column_index.SortMode = DataGridViewColumnSortMode.NotSortable;
			column_bhash.SortMode = DataGridViewColumnSortMode.NotSortable;
			column_label.SortMode = DataGridViewColumnSortMode.NotSortable;
			column_descr.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.BinaryDataView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.BinaryDataView.MultiSelect = false;

			this.BinaryDataView.Columns.Add(column_index);
			this.BinaryDataView.Columns.Add(column_bhash);
			this.BinaryDataView.Columns.Add(column_label);
			this.BinaryDataView.Columns.Add(column_descr);
			this.BinaryDataView.RowHeadersWidth = 30;
		}

		private void ShowAllSTRProperties()
		{
			string CName = this.BinaryTree.SelectedNode.Text;
			var str = (STRBlock)this.db.GetCollection(CName, STRBlocks);
			if (str == null) return;

			this.BinaryDataViewSTRColumnInit();

			int index = 0;
			this.BinaryDataView.Rows.Add(str.InfoLength);

			// Temporary remove validating handler
			this.BinaryDataView.CellValidating -= this.BinaryDataView_CellValidating;
			this.BinaryDataView.CellValueChanged -= this.BinaryDataView_CellValueChanged;

			foreach (var record in str.GetRecords())
			{
				// Use assumed and predefined amount of columns and rows
				this.BinaryDataView.Rows[index].Cells[0].Value = index.ToString();
				this.BinaryDataView.Rows[index].Cells[1].Value = $"0x{record.Key:X8}";
				this.BinaryDataView.Rows[index].Cells[2].Value = record.Label == null ? string.Empty : record.Label;
				this.BinaryDataView.Rows[index].Cells[3].Value = record.Text == null ? string.Empty : record.Text;
				++index;
			}

			// Add validating handler back
			this.BinaryDataView.CellValidating += this.BinaryDataView_CellValidating;
			this.BinaryDataView.CellValueChanged += this.BinaryDataView_CellValueChanged;
		}

		private void LaunchSTREditor(int RowIndex)
		{
			var str = (STRBlock)this.db.GetCollection(this.BinaryTree.SelectedNode.Text, STRBlocks);
			if (str == null) return;

			var inter = this.BinaryDataView.Rows[RowIndex].Cells[1].Value.ToString();
			var key = ConvertX.ToUInt32(inter);

			var record = str.GetRecord(key);

			var STRForm = new Interact.STREditor(record);
			STRForm.ShowDialog();
			foreach (var command in STRForm.CommandsProcessed)
				Generate.WriteCommand(command, this.ColoredTextForm);
			this.UpdateBinaryDataView();
			if (STRForm.FindTexts)
			{
				foreach (DataGridViewRow row in this.BinaryDataView.Rows)
				{
					if (row.Cells[3].Value.ToString().Contains(STRForm.TextToFind))
						row.DefaultCellStyle.BackColor = Color.DarkGoldenrod;
				}
			}
		}

		#endregion

		#region TexExport

		private void ExportAsddsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (TextureExportDialog.ShowDialog() == DialogResult.OK)
			{
				if (this.db.ExportTextures(TextureExportDialog.SelectedPath, ".dds"))
					MessageBox.Show($"All textures were exported to {TextureExportDialog.SelectedPath}.",
						"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void ExportAspngToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (TextureExportDialog.ShowDialog() == DialogResult.OK)
			{
				if (this.db.ExportTextures(TextureExportDialog.SelectedPath, ".png"))
					MessageBox.Show($"All textures were exported to {TextureExportDialog.SelectedPath}.",
						"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void ExportAsjpgToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (TextureExportDialog.ShowDialog() == DialogResult.OK)
			{
				if (this.db.ExportTextures(TextureExportDialog.SelectedPath, ".jpg"))
					MessageBox.Show($"All textures were exported to {TextureExportDialog.SelectedPath}.",
						"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void ExportAstiffToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (TextureExportDialog.ShowDialog() == DialogResult.OK)
			{
				if (this.db.ExportTextures(TextureExportDialog.SelectedPath, ".tiff"))
					MessageBox.Show($"All textures were exported to {TextureExportDialog.SelectedPath}.",
						"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void ExportAsbmpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (TextureExportDialog.ShowDialog() == DialogResult.OK)
			{
				if (this.db.ExportTextures(TextureExportDialog.SelectedPath, ".bmp"))
					MessageBox.Show($"All textures were exported to {TextureExportDialog.SelectedPath}.",
						"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		#endregion
	}
}
