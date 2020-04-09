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



namespace Binary.Interact
{
	partial class BoundsList
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
			this.BoundListView = new System.Windows.Forms.ListView();
			this.BoundIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.VltKeyColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.CollisionNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.ButtonOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// BoundListView
			// 
			this.BoundListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BoundListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.BoundListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BoundListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BoundIndex,
            this.VltKeyColumn,
            this.CollisionNameColumn});
			this.BoundListView.ForeColor = System.Drawing.SystemColors.Window;
			this.BoundListView.FullRowSelect = true;
			this.BoundListView.GridLines = true;
			this.BoundListView.HideSelection = false;
			this.BoundListView.Location = new System.Drawing.Point(12, 44);
			this.BoundListView.MultiSelect = false;
			this.BoundListView.Name = "BoundListView";
			this.BoundListView.OwnerDraw = true;
			this.BoundListView.ShowItemToolTips = true;
			this.BoundListView.Size = new System.Drawing.Size(472, 261);
			this.BoundListView.TabIndex = 0;
			this.BoundListView.UseCompatibleStateImageBehavior = false;
			this.BoundListView.View = System.Windows.Forms.View.Details;
			this.BoundListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.BoundListView_DrawColumnHeader);
			this.BoundListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.BoundListView_DrawItem);
			this.BoundListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BoundListView_MouseDoubleClick);
			// 
			// BoundIndex
			// 
			this.BoundIndex.Text = "Index";
			this.BoundIndex.Width = 40;
			// 
			// VltKeyColumn
			// 
			this.VltKeyColumn.Text = "Vault Memory Hash";
			this.VltKeyColumn.Width = 150;
			// 
			// CollisionNameColumn
			// 
			this.CollisionNameColumn.Text = "Collision Name";
			this.CollisionNameColumn.Width = 260;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.SystemColors.Info;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(409, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Collision Bounds List that can be used in CollisionInternalName fields of CarType" +
    "Infos.";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.SystemColors.Info;
			this.label2.Location = new System.Drawing.Point(12, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(322, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Double click on any line to copy its Collision Name to the clipboard.";
			// 
			// ButtonOK
			// 
			this.ButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ButtonOK.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.ButtonOK.FlatAppearance.BorderSize = 0;
			this.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonOK.ForeColor = System.Drawing.SystemColors.Info;
			this.ButtonOK.Location = new System.Drawing.Point(378, 315);
			this.ButtonOK.Name = "ButtonOK";
			this.ButtonOK.Size = new System.Drawing.Size(102, 21);
			this.ButtonOK.TabIndex = 3;
			this.ButtonOK.Text = "OK";
			this.ButtonOK.UseVisualStyleBackColor = false;
			this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
			// 
			// BoundsList
			// 
			this.AcceptButton = this.ButtonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(36)))), ((int)(((byte)(53)))));
			this.ClientSize = new System.Drawing.Size(496, 345);
			this.Controls.Add(this.ButtonOK);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BoundListView);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "BoundsList";
			this.ShowIcon = false;
			this.Text = "BoundsList";
			this.Load += new System.EventHandler(this.BoundsList_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView BoundListView;
		private System.Windows.Forms.ColumnHeader BoundIndex;
		private System.Windows.Forms.ColumnHeader VltKeyColumn;
		private System.Windows.Forms.ColumnHeader CollisionNameColumn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button ButtonOK;
	}
}