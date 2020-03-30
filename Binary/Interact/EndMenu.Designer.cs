namespace Binary.Interact
{
	partial class EndMenu
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
			this.TextPanel = new System.Windows.Forms.Panel();
			this.ImagePanel = new System.Windows.Forms.Panel();
			this.TextPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// TextPanel
			// 
			this.TextPanel.Controls.Add(this.DescriptionBox.RTX);
			this.TextPanel.Location = new System.Drawing.Point(12, 12);
			this.TextPanel.Name = "TextPanel";
			this.TextPanel.Size = new System.Drawing.Size(508, 426);
			this.TextPanel.TabIndex = 0;
			// 
			// ImagePanel
			// 
			this.ImagePanel.Location = new System.Drawing.Point(530, 12);
			this.ImagePanel.Name = "ImagePanel";
			this.ImagePanel.Size = new System.Drawing.Size(258, 387);
			this.ImagePanel.TabIndex = 1;
			//
			// DescriptionBox.RTX
			//
			this.DescriptionBox.RTX.Location = new System.Drawing.Point(3, 3);
			this.DescriptionBox.RTX.Name = "DescriptionBox";
			this.DescriptionBox.RTX.ReadOnly = true;
			this.DescriptionBox.RTX.Size = new System.Drawing.Size(502, 420);
			this.DescriptionBox.RTX.TabIndex = 0;
			this.DescriptionBox.RTX.Text = "";
			// 
			// EndMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.ImagePanel);
			this.Controls.Add(this.TextPanel);
			this.Name = "EndMenu";
			this.Text = "EndMenu";
			this.ResumeLayout(false);

		}

		#endregion
	}
}