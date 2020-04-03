using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binary.Forms.Interact
{
	public partial class STREditor : Form
	{
		private bool labelchanged = false;
		private string path = " STRBlocks GLOBAL ";

		public bool DeleteThis{ get; set; } = false;
		public bool AddRecord { get; set; } = false;
		public bool FindTexts { get; set; } = false;
		public string TextToFind { get; set; } = string.Empty;

		public uint Key { get; set; }
		public string Label { get; set; }
		public string Texts { get; set; }
		public List<string> CommandsProcessed { get; set; } = new List<string>();

		private GlobalLib.Support.Shared.Parts.STRParts.StringRecord Record { get; set; }

		public STREditor(GlobalLib.Support.Shared.Parts.STRParts.StringRecord str)
		{
			this.Record = str;
			this.Key = this.Record.Key;
			this.Label = this.Record.Label;
			this.Texts = this.Record.Text;
			InitializeComponent();
		}

		private void ApplyRecordChanges()
		{
			var prev = this.Record.Key.ToString("X8");
			this.Record.Key = this.Key;
			this.Record.Label = this.Label;
			this.Record.Text = this.Texts;
			this.CommandsProcessed.Add($"{Endscript.Commands.Switch}{path}{prev} Hash {this.Key.ToString("X8")}");
			this.CommandsProcessed.Add($"{Endscript.Commands.Switch}{path}{this.Key.ToString("X8")} Label \"{this.Label}\"");
			this.CommandsProcessed.Add($"{Endscript.Commands.Switch}{path}{this.Key.ToString("X8")} Text \"{this.Texts}\"");
		}

		private void STREditor_Load(object sender, EventArgs e)
		{
			this.StringLabelBox.Text = string.IsNullOrEmpty(this.Label) ? "???" : this.Label;
			this.StringKeyBox.Text = this.Key.ToString("X8");
			this.StringTextBox.Text = this.Texts;
			this.labelchanged = false;
			if (this.Key != GlobalLib.Utils.Bin.Hash(this.Label))
				UseCustomKeyCheckBox.Checked = true;
		}

		private void StringLabelBox_TextChanged(object sender, EventArgs e)
		{
			if (!this.UseCustomKeyCheckBox.Checked)
			{
				var key = GlobalLib.Utils.Bin.Hash(this.StringLabelBox.Text);
				if (this.UseInvertedKeyCheckBox.Checked)
					this.StringKeyBox.Text = GlobalLib.Utils.Bin.Reverse(key).ToString("X8");
				else
					this.StringKeyBox.Text = key.ToString("X8");
				this.labelchanged = true;
			}
		}

		private void UseCustomKeyCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			this.StringKeyBox.ReadOnly = !this.UseCustomKeyCheckBox.Checked;
			if (this.StringKeyBox.ReadOnly)
				this.StringKeyBox.Text = GlobalLib.Utils.Bin.Hash(this.StringLabelBox.Text).ToString("X8");
		}

		private void UseInvertedKeyCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			var key = GlobalLib.Utils.ConvertX.ToUInt32(this.StringKeyBox.Text);
			key = GlobalLib.Utils.Bin.Reverse(key);
			this.StringKeyBox.Text = key.ToString("X8");
		}

		private void ApplyChanges_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(this.StringKeyBox.Text) || string.IsNullOrEmpty(this.StringLabelBox.Text))
					throw new ArgumentNullException("Hash value and label value cannot be left empty.");
				uint tempkey = Convert.ToUInt32(this.StringKeyBox.Text, 16);
				if (UseInvertedKeyCheckBox.Checked)
					tempkey = GlobalLib.Utils.Bin.Reverse(tempkey);
				if (tempkey != this.Key) // if this is a different key from the one passed
				{
					foreach (var info in this.Record.ThisList) // check for uniqueness
					{
						if (tempkey == info.Key) // if not unique, throw
							throw new GlobalLib.Reflection.Exception.CollectionExistenceException("String record" +
								"with the same hash already exists.");
					}
				}
				this.Key = tempkey;
				this.Label = this.labelchanged ? this.StringLabelBox.Text : this.Label;
				this.Texts = this.StringTextBox.Text;
				this.ApplyRecordChanges();
				this.DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				while (ex.InnerException != null) ex = ex.InnerException;
				MessageBox.Show(ex.Message, "Warning");
			}
		}

		private void DeleteString_Click(object sender, EventArgs e)
		{
			this.CommandsProcessed.Add($"{Endscript.Commands.Delete}{path}{this.Key.ToString("X8")}");
			this.DeleteThis = true;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void AddString_Click(object sender, EventArgs e)
		{
			this.AddRecord = true;
			this.DialogResult = DialogResult.OK;
			this.Close();
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

		private void StringKeyBox_TextChanged(object sender, EventArgs e)
		{
		}
	}
}