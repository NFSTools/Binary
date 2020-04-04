using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Binary.Endscript;
using GlobalLib.Utils;
using GlobalLib.Reflection;
using GlobalLib.Support.Shared.Parts.STRParts;



namespace Binary.Interact
{
	public partial class STREditor : Form
	{
		private bool labelchanged = false;
		private const string path = "STRBlocks GLOBAL";
		private const string key = "Key";
		private const string label = "Label";
		private const string text = "Text";

		public bool FindTexts { get; set; } = false;
		public string TextToFind { get; set; } = string.Empty;

		public List<string> CommandsProcessed { get; set; } = new List<string>();

		private StringRecord _record;

		public STREditor(StringRecord str)
		{
			this._record = str;
			this.InitializeComponent();
		}

		private void ApplyRecordChanges(uint newkey)
		{
			var prevs = $"0x{this._record.Key:X8}";
			var after = $"0x{newkey:X8}";
			this._record.Key = newkey;
			this._record.Label = this.labelchanged ? this.StringLabelBox.Text : this._record.Label;
			this._record.Text = this.StringTextBox.Text;
			this.CommandsProcessed.Add($"{Commands.update} {path} {prevs} {key} {after}");
			this.CommandsProcessed.Add($"{Commands.update} {path} {after} {label} \"{this._record.Label}\"");
			this.CommandsProcessed.Add($"{Commands.update} {path} {after} {text} \"{this._record.Text}\"");
		}

		private void STREditor_Load(object sender, EventArgs e)
		{
			this.StringLabelBox.Text = string.IsNullOrEmpty(this._record.Label) ? "???" : this._record.Label;
			this.StringKeyBox.Text = $"0x{this._record.Key}";
			this.StringTextBox.Text = this._record.Text;
			this.labelchanged = false;
			if (this._record.Key != Bin.Hash(this._record.Label))
				this.UseCustomKeyCheckBox.Checked = true;
		}

		private void StringLabelBox_TextChanged(object sender, EventArgs e)
		{
			if (!this.UseCustomKeyCheckBox.Checked)
			{
				var key = Bin.Hash(this.StringLabelBox.Text);
				if (this.UseInvertedKeyCheckBox.Checked)
					this.StringKeyBox.Text = $"0x{Bin.Reverse(key):X8}";
				else
					this.StringKeyBox.Text = $"0x{key:X8}";
				this.labelchanged = true;
			}
		}

		private void UseCustomKeyCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			this.StringKeyBox.ReadOnly = !this.UseCustomKeyCheckBox.Checked;
			if (this.StringKeyBox.ReadOnly)
				this.StringKeyBox.Text = $"0x{Bin.Hash(this.StringLabelBox.Text):X8}";
		}

		private void UseInvertedKeyCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			var key = ConvertX.ToUInt32(this.StringKeyBox.Text);
			key = Bin.Reverse(key);
			this.StringKeyBox.Text = $"0x{key:X8}";
		}

		private void ApplyChanges_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.StringKeyBox.Text) || string.IsNullOrEmpty(this.StringLabelBox.Text))
			{
				MessageBox.Show("Key value and label value cannot be left empty.", "Warning",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			uint key = ConvertX.ToUInt32(this.StringKeyBox.Text);
			if (this.UseInvertedKeyCheckBox.Checked) key = Bin.Reverse(key);
			if (key != this._record.Key) // if this is a different key from the one passed
			{
				var exist = this._record.ThisSTRBlock.GetRecord(key);
				if (exist != null)
				{
					MessageBox.Show($"StringRecord with key {this.StringKeyBox.Text} already exists", "Warning",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}
			this.ApplyRecordChanges(key);
			this.DialogResult = DialogResult.OK;
		}

		private void DeleteString_Click(object sender, EventArgs e)
		{
			var key = $"0x{this._record.Key:X8}";
			this.CommandsProcessed.Add($"{Commands.delete} {path} {key}");
			this._record.ThisSTRBlock.TryRemoveRecord(this._record.Key);
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void AddString_Click(object sender, EventArgs e)
		{
			string global = "GLOBAL_";
			int index = 0;
			while (!this._record.ThisSTRBlock.TryAddRecord(BaseArguments.AUTO,
				$"{global}{index}", string.Empty)) { ++index; }
			var newkey = Bin.Hash($"{global}{index}");
			var newrecord = this._record.ThisSTRBlock.GetRecord(newkey);
			this._record = newrecord;
			this.STREditor_Load(this, EventArgs.Empty);
		}

		private void FindString_Click(object sender, EventArgs e)
		{
			var InputWindow = new Input("Enter the text to be found (case sensitive only):");
			if (InputWindow.ShowDialog() == DialogResult.OK)
			{
				this.FindTexts = true;
				this.TextToFind = InputWindow.CollectionName;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void StringKeyBox_Validating(object sender, CancelEventArgs e)
		{
			if (ConvertX.ToUInt32(this.StringKeyBox.Text) == 0)
			{
				MessageBox.Show("Unable to convert key to a hexadecimal hash or it equals 0.", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				e.Cancel = true;
			}
		}
	}
}