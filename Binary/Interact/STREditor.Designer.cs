namespace Binary.Interact
{
	partial class STREditor
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(STREditor));
			this.StringTextBox = new System.Windows.Forms.TextBox();
			this.AddString = new System.Windows.Forms.Button();
			this.FindString = new System.Windows.Forms.Button();
			this.DeleteString = new System.Windows.Forms.Button();
			this.ApplyChanges = new System.Windows.Forms.Button();
			this.StringKeyBox = new System.Windows.Forms.TextBox();
			this.StringLabelBox = new System.Windows.Forms.TextBox();
			this.LabelKey = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.UseCustomKeyCheckBox = new System.Windows.Forms.CheckBox();
			this.UseInvertedKeyCheckBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// StringTextBox
			// 
			this.StringTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			this.StringTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.StringTextBox.ForeColor = System.Drawing.SystemColors.Info;
			this.StringTextBox.Location = new System.Drawing.Point(12, 101);
			this.StringTextBox.Multiline = true;
			this.StringTextBox.Name = "StringTextBox";
			this.StringTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.StringTextBox.Size = new System.Drawing.Size(620, 169);
			this.StringTextBox.TabIndex = 0;
			// 
			// AddString
			// 
			this.AddString.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			this.AddString.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.AddString.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.AddString.ForeColor = System.Drawing.SystemColors.Info;
			this.AddString.Location = new System.Drawing.Point(12, 71);
			this.AddString.Name = "AddString";
			this.AddString.Size = new System.Drawing.Size(140, 24);
			this.AddString.TabIndex = 1;
			this.AddString.Text = "Add String";
			this.AddString.UseVisualStyleBackColor = false;
			this.AddString.Click += new System.EventHandler(this.AddString_Click);
			// 
			// FindString
			// 
			this.FindString.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			this.FindString.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.FindString.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.FindString.ForeColor = System.Drawing.SystemColors.Info;
			this.FindString.Location = new System.Drawing.Point(332, 71);
			this.FindString.Name = "FindString";
			this.FindString.Size = new System.Drawing.Size(140, 24);
			this.FindString.TabIndex = 2;
			this.FindString.Text = "Find String";
			this.FindString.UseVisualStyleBackColor = false;
			this.FindString.Click += new System.EventHandler(this.FindString_Click);
			// 
			// DeleteString
			// 
			this.DeleteString.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			this.DeleteString.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.DeleteString.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.DeleteString.ForeColor = System.Drawing.SystemColors.Info;
			this.DeleteString.Location = new System.Drawing.Point(172, 71);
			this.DeleteString.Name = "DeleteString";
			this.DeleteString.Size = new System.Drawing.Size(140, 24);
			this.DeleteString.TabIndex = 3;
			this.DeleteString.Text = "Delete String";
			this.DeleteString.UseVisualStyleBackColor = false;
			this.DeleteString.Click += new System.EventHandler(this.DeleteString_Click);
			// 
			// ApplyChanges
			// 
			this.ApplyChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			this.ApplyChanges.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.ApplyChanges.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ApplyChanges.ForeColor = System.Drawing.SystemColors.Info;
			this.ApplyChanges.Location = new System.Drawing.Point(492, 71);
			this.ApplyChanges.Name = "ApplyChanges";
			this.ApplyChanges.Size = new System.Drawing.Size(140, 24);
			this.ApplyChanges.TabIndex = 4;
			this.ApplyChanges.Text = "Apply Changes";
			this.ApplyChanges.UseVisualStyleBackColor = false;
			this.ApplyChanges.Click += new System.EventHandler(this.ApplyChanges_Click);
			// 
			// StringKeyBox
			// 
			this.StringKeyBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(65)))), ((int)(((byte)(72)))));
			this.StringKeyBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.StringKeyBox.ForeColor = System.Drawing.SystemColors.Info;
			this.StringKeyBox.Location = new System.Drawing.Point(55, 12);
			this.StringKeyBox.Name = "StringKeyBox";
			this.StringKeyBox.ReadOnly = true;
			this.StringKeyBox.Size = new System.Drawing.Size(287, 20);
			this.StringKeyBox.TabIndex = 5;
			this.StringKeyBox.Validating += new System.ComponentModel.CancelEventHandler(this.StringKeyBox_Validating);
			// 
			// StringLabelBox
			// 
			this.StringLabelBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(65)))), ((int)(((byte)(72)))));
			this.StringLabelBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.StringLabelBox.ForeColor = System.Drawing.SystemColors.Info;
			this.StringLabelBox.Location = new System.Drawing.Point(55, 38);
			this.StringLabelBox.Name = "StringLabelBox";
			this.StringLabelBox.Size = new System.Drawing.Size(287, 20);
			this.StringLabelBox.TabIndex = 6;
			this.StringLabelBox.TextChanged += new System.EventHandler(this.StringLabelBox_TextChanged);
			// 
			// LabelKey
			// 
			this.LabelKey.AutoSize = true;
			this.LabelKey.ForeColor = System.Drawing.SystemColors.Info;
			this.LabelKey.Location = new System.Drawing.Point(24, 15);
			this.LabelKey.Name = "LabelKey";
			this.LabelKey.Size = new System.Drawing.Size(25, 13);
			this.LabelKey.TabIndex = 7;
			this.LabelKey.Text = "Key";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.SystemColors.Info;
			this.label1.Location = new System.Drawing.Point(16, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Label";
			// 
			// UseCustomKeyCheckBox
			// 
			this.UseCustomKeyCheckBox.AutoSize = true;
			this.UseCustomKeyCheckBox.ForeColor = System.Drawing.SystemColors.Info;
			this.UseCustomKeyCheckBox.Location = new System.Drawing.Point(348, 14);
			this.UseCustomKeyCheckBox.Name = "UseCustomKeyCheckBox";
			this.UseCustomKeyCheckBox.Size = new System.Drawing.Size(272, 17);
			this.UseCustomKeyCheckBox.TabIndex = 9;
			this.UseCustomKeyCheckBox.Text = "Use custom hash (should be a hexadecimal number)";
			this.UseCustomKeyCheckBox.UseVisualStyleBackColor = true;
			this.UseCustomKeyCheckBox.CheckedChanged += new System.EventHandler(this.UseCustomKeyCheckBox_CheckedChanged);
			// 
			// UseInvertedKeyCheckBox
			// 
			this.UseInvertedKeyCheckBox.AutoSize = true;
			this.UseInvertedKeyCheckBox.ForeColor = System.Drawing.SystemColors.Info;
			this.UseInvertedKeyCheckBox.Location = new System.Drawing.Point(348, 41);
			this.UseInvertedKeyCheckBox.Name = "UseInvertedKeyCheckBox";
			this.UseInvertedKeyCheckBox.Size = new System.Drawing.Size(287, 17);
			this.UseInvertedKeyCheckBox.TabIndex = 10;
			this.UseInvertedKeyCheckBox.Text = "Show inverted file hashes (AABBCCDD to DDCCBBAA)";
			this.UseInvertedKeyCheckBox.UseVisualStyleBackColor = true;
			this.UseInvertedKeyCheckBox.CheckedChanged += new System.EventHandler(this.UseInvertedKeyCheckBox_CheckedChanged);
			// 
			// STREditor
			// 
			this.AcceptButton = this.ApplyChanges;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.ClientSize = new System.Drawing.Size(644, 283);
			this.Controls.Add(this.UseInvertedKeyCheckBox);
			this.Controls.Add(this.UseCustomKeyCheckBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LabelKey);
			this.Controls.Add(this.StringLabelBox);
			this.Controls.Add(this.StringKeyBox);
			this.Controls.Add(this.ApplyChanges);
			this.Controls.Add(this.DeleteString);
			this.Controls.Add(this.FindString);
			this.Controls.Add(this.AddString);
			this.Controls.Add(this.StringTextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "STREditor";
			this.Text = "String Editor by MaxHwoy";
			this.Load += new System.EventHandler(this.STREditor_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox StringTextBox;
		private System.Windows.Forms.Button AddString;
		private System.Windows.Forms.Button FindString;
		private System.Windows.Forms.Button DeleteString;
		private System.Windows.Forms.Button ApplyChanges;
		private System.Windows.Forms.TextBox StringKeyBox;
		private System.Windows.Forms.TextBox StringLabelBox;
		private System.Windows.Forms.Label LabelKey;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox UseCustomKeyCheckBox;
		private System.Windows.Forms.CheckBox UseInvertedKeyCheckBox;
	}
}