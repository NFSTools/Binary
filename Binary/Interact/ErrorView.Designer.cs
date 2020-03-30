namespace Binary.Interact
{
    partial class ErrorView
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
			this.ErrorListView = new System.Windows.Forms.ListView();
			this.LineNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.CommandString = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ErrorString = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label1 = new System.Windows.Forms.Label();
			this.Filename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// ErrorListView
			// 
			this.ErrorListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ErrorListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.ErrorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LineNumber,
            this.Filename,
            this.CommandString,
            this.ErrorString});
			this.ErrorListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.ErrorListView.FullRowSelect = true;
			this.ErrorListView.GridLines = true;
			this.ErrorListView.HideSelection = false;
			this.ErrorListView.Location = new System.Drawing.Point(9, 31);
			this.ErrorListView.Name = "ErrorListView";
			this.ErrorListView.OwnerDraw = true;
			this.ErrorListView.ShowItemToolTips = true;
			this.ErrorListView.Size = new System.Drawing.Size(744, 310);
			this.ErrorListView.TabIndex = 0;
			this.ErrorListView.UseCompatibleStateImageBehavior = false;
			this.ErrorListView.View = System.Windows.Forms.View.Details;
			this.ErrorListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ErrorListView_DrawColumnHeader);
			this.ErrorListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ErrorListView_DrawItem);
			// 
			// LineNumber
			// 
			this.LineNumber.Text = "Line";
			// 
			// CommandString
			// 
			this.CommandString.Text = "Command";
			this.CommandString.Width = 270;
			// 
			// ErrorString
			// 
			this.ErrorString.Text = "Error Type";
			this.ErrorString.Width = 260;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(17, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(247, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "During installation the following errors had occured:";
			// 
			// Filename
			// 
			this.Filename.Text = "Filename";
			this.Filename.Width = 150;
			// 
			// ErrorView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(36)))), ((int)(((byte)(53)))));
			this.ClientSize = new System.Drawing.Size(765, 353);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ErrorListView);
			this.Name = "ErrorView";
			this.ShowIcon = false;
			this.Text = "Error View";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ErrorListView;
        private System.Windows.Forms.ColumnHeader LineNumber;
        private System.Windows.Forms.ColumnHeader CommandString;
        private System.Windows.Forms.ColumnHeader ErrorString;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader Filename;
	}
}