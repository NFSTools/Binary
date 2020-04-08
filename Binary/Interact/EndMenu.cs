using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using GlobalLib.Utils.EA;
using GlobalLib.Utils.HTML;



namespace Binary.Interact
{
	public partial class EndMenu : Form
	{
		private HTMLTextBox DescriptionBox;
		private Panel TextPanel;
		private Panel ImagePanel;
		private Button InstallConfirm;
		private PictureBox Image1;
		private PictureBox Image2;
		private PictureBox Image3;

		public EndMenu(string[] lines, string filename)
		{
			this.DescriptionBox = new HTMLTextBox(lines);
			for (int a1 = 0; a1 < this.DescriptionBox.Menu.ImagePaths.Count; ++a1)
				this.DescriptionBox.Menu.ImagePaths[a1] = Path.Combine(filename, this.DescriptionBox.Menu.ImagePaths[a1]);
			this.CustomInitializer();
		}

		// Use custom initializer b/c of HTMLTextBox that is defined on user's settings.
		private void CustomInitializer()
		{
			int X = this.DescriptionBox.Menu.Width;
			int Y = this.DescriptionBox.Menu.Height;
			for (int a1 = this.DescriptionBox.Menu.ImagePaths.Count; a1 < 3; ++a1)
				this.DescriptionBox.Menu.ImagePaths.Add(null);

			this.TextPanel = new Panel();
			this.ImagePanel = new Panel();
			this.InstallConfirm = new Button();
			this.Image1 = new PictureBox();
			this.Image2 = new PictureBox();
			this.Image3 = new PictureBox();
			this.TextPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// TextPanel
			// 
			this.TextPanel.Controls.Add(this.DescriptionBox.RTX);
			this.TextPanel.Location = new Point((int)(X * 0.025), (int)(Y * 0.0375));
			this.TextPanel.Name = "TextPanel";
			this.TextPanel.Size = new Size((int)(X * 0.65), (int)(Y * 0.925));
			this.TextPanel.TabIndex = 0;
			// 
			// ImagePanel
			// 
			this.ImagePanel.Controls.Add(this.Image1);
			this.ImagePanel.Controls.Add(this.Image2);
			this.ImagePanel.Controls.Add(this.Image3);
			this.ImagePanel.Location = new Point((int)(X * 0.7), (int)(Y * 0.0375));
			this.ImagePanel.Name = "ImagePanel";
			this.ImagePanel.Size = new Size((int)(X * 0.275), (int)(Y * 0.8));
			this.ImagePanel.TabIndex = 1;
			//
			// DescriptionBox.RTX
			//
			this.DescriptionBox.RTX.BackColor = this.DescriptionBox.Menu.WFColor;
			this.DescriptionBox.RTX.Location = new Point(0, 0);
			this.DescriptionBox.RTX.Name = "DescriptionBox";
			this.DescriptionBox.RTX.ReadOnly = true;
			this.DescriptionBox.RTX.Size = new Size(this.TextPanel.Width, this.TextPanel.Height);
			this.DescriptionBox.RTX.TabIndex = 0;
			//
			// Image1
			//
			this.Image1.BackColor = this.DescriptionBox.Menu.WBColor;
			this.Image1.Location = new Point(0, 0);
			this.Image1.Name = "Image1";
			this.Image1.SizeMode = PictureBoxSizeMode.Zoom;
			this.Image1.Size = new Size(this.ImagePanel.Width, (int)(this.ImagePanel.Height / 3));
			if (Resolve.IsImageFormat(this.DescriptionBox.Menu.ImagePaths[0]))
				this.Image1.Image = Image.FromFile(this.DescriptionBox.Menu.ImagePaths[0]);
			//
			// Image2
			//
			this.Image2.BackColor = this.DescriptionBox.Menu.WBColor;
			this.Image2.Location = new Point(0, (int)(this.ImagePanel.Height / 3));
			this.Image2.Name = "Image2";
			this.Image2.SizeMode = PictureBoxSizeMode.Zoom;
			this.Image2.Size = new Size(this.ImagePanel.Width, (int)(this.ImagePanel.Height / 3));
			if (Resolve.IsImageFormat(this.DescriptionBox.Menu.ImagePaths[1]))
				this.Image2.Image = Image.FromFile(this.DescriptionBox.Menu.ImagePaths[1]);
			//
			// Image3
			//
			this.Image3.BackColor = this.DescriptionBox.Menu.WBColor;
			this.Image3.Location = new Point(0, (int)(this.ImagePanel.Height / 3) * 2);
			this.Image3.Name = "Image3";
			this.Image3.SizeMode = PictureBoxSizeMode.Zoom;
			this.Image3.Size = new Size(this.ImagePanel.Width, (int)(this.ImagePanel.Height / 3));
			if (Resolve.IsImageFormat(this.DescriptionBox.Menu.ImagePaths[2]))
				this.Image3.Image = Image.FromFile(this.DescriptionBox.Menu.ImagePaths[2]);
			// 
			// ButtonOK
			// 
			this.InstallConfirm.BackColor = Color.FromArgb(0x40, 0x40, 0x40);
			this.InstallConfirm.ForeColor = SystemColors.Info;
			this.InstallConfirm.Location = new Point((int)(X * 0.7), (int)(Y * 0.875));
			this.InstallConfirm.Name = "InstallConfirm";
			this.InstallConfirm.Size = new Size((int)(X * 0.275), (int)(Y * 0.0875));
			this.InstallConfirm.TabIndex = 2;
			this.InstallConfirm.Text = "Install";
			this.InstallConfirm.UseVisualStyleBackColor = false;
			this.InstallConfirm.FlatStyle = FlatStyle.Flat;
			this.InstallConfirm.Click += new EventHandler(this.InstallConfirm_Click);
			// 
			// EndMenu
			// 
			this.AutoScaleDimensions = new SizeF(6, 13F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(X, Y);
			this.BackColor = this.DescriptionBox.Menu.WBColor;
			this.Controls.Add(this.ImagePanel);
			this.Controls.Add(this.TextPanel);
			this.Controls.Add(this.InstallConfirm);
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.ShowIcon = false;
			this.Name = "EndMenu";
			this.Text = this.DescriptionBox.Menu.Title;
			this.ResumeLayout(false);
			this.PerformLayout();
		}
	
		private void InstallConfirm_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
