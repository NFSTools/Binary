namespace Binary.Tools
{
	partial class SwatchPicker
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SwatchPicker));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.LabelBlue = new System.Windows.Forms.Label();
			this.LabelGreen = new System.Windows.Forms.Label();
			this.LabelRed = new System.Windows.Forms.Label();
			this.TrackBar_Blue = new System.Windows.Forms.TrackBar();
			this.TrackBar_Green = new System.Windows.Forms.TrackBar();
			this.TrackBar_Red = new System.Windows.Forms.TrackBar();
			this.OpenWindowsColorForm = new System.Windows.Forms.Button();
			this.ColorPreview = new System.Windows.Forms.PictureBox();
			this.SwatchDialog = new System.Windows.Forms.ColorDialog();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.CopyBrightnessValue = new System.Windows.Forms.Button();
			this.CopySaturationValue = new System.Windows.Forms.Button();
			this.CopyPaintSwatchValue = new System.Windows.Forms.Button();
			this.TextBoxBrightness = new System.Windows.Forms.TextBox();
			this.TextBoxSaturation = new System.Windows.Forms.TextBox();
			this.TextBoxPaintSwatch = new System.Windows.Forms.TextBox();
			this.LabelBrightness = new System.Windows.Forms.Label();
			this.LabelSaturation = new System.Windows.Forms.Label();
			this.LabelPaintSwatch = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Blue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Green)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Red)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ColorPreview)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.LabelBlue);
			this.groupBox1.Controls.Add(this.LabelGreen);
			this.groupBox1.Controls.Add(this.LabelRed);
			this.groupBox1.Controls.Add(this.TrackBar_Blue);
			this.groupBox1.Controls.Add(this.TrackBar_Green);
			this.groupBox1.Controls.Add(this.TrackBar_Red);
			this.groupBox1.ForeColor = System.Drawing.SystemColors.Info;
			this.groupBox1.Location = new System.Drawing.Point(25, 18);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(357, 198);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "RGB Value Picker";
			// 
			// LabelBlue
			// 
			this.LabelBlue.AutoSize = true;
			this.LabelBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelBlue.ForeColor = System.Drawing.Color.White;
			this.LabelBlue.Location = new System.Drawing.Point(19, 131);
			this.LabelBlue.Name = "LabelBlue";
			this.LabelBlue.Size = new System.Drawing.Size(41, 20);
			this.LabelBlue.TabIndex = 26;
			this.LabelBlue.Text = "Blue";
			// 
			// LabelGreen
			// 
			this.LabelGreen.AutoSize = true;
			this.LabelGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelGreen.ForeColor = System.Drawing.Color.White;
			this.LabelGreen.Location = new System.Drawing.Point(6, 80);
			this.LabelGreen.Name = "LabelGreen";
			this.LabelGreen.Size = new System.Drawing.Size(54, 20);
			this.LabelGreen.TabIndex = 25;
			this.LabelGreen.Text = "Green";
			// 
			// LabelRed
			// 
			this.LabelRed.AutoSize = true;
			this.LabelRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelRed.ForeColor = System.Drawing.Color.White;
			this.LabelRed.Location = new System.Drawing.Point(21, 34);
			this.LabelRed.Name = "LabelRed";
			this.LabelRed.Size = new System.Drawing.Size(39, 20);
			this.LabelRed.TabIndex = 24;
			this.LabelRed.Text = "Red";
			// 
			// TrackBar_Blue
			// 
			this.TrackBar_Blue.Location = new System.Drawing.Point(66, 136);
			this.TrackBar_Blue.Maximum = 255;
			this.TrackBar_Blue.Name = "TrackBar_Blue";
			this.TrackBar_Blue.Size = new System.Drawing.Size(279, 45);
			this.TrackBar_Blue.TabIndex = 16;
			this.TrackBar_Blue.Scroll += new System.EventHandler(this.TrackBar_Blue_Scroll);
			// 
			// TrackBar_Green
			// 
			this.TrackBar_Green.Location = new System.Drawing.Point(66, 85);
			this.TrackBar_Green.Maximum = 255;
			this.TrackBar_Green.Name = "TrackBar_Green";
			this.TrackBar_Green.Size = new System.Drawing.Size(279, 45);
			this.TrackBar_Green.TabIndex = 15;
			this.TrackBar_Green.Scroll += new System.EventHandler(this.TrackBar_Green_Scroll);
			// 
			// TrackBar_Red
			// 
			this.TrackBar_Red.Location = new System.Drawing.Point(66, 34);
			this.TrackBar_Red.Maximum = 255;
			this.TrackBar_Red.Name = "TrackBar_Red";
			this.TrackBar_Red.Size = new System.Drawing.Size(279, 45);
			this.TrackBar_Red.TabIndex = 14;
			this.TrackBar_Red.Scroll += new System.EventHandler(this.TrackBar_Red_Scroll);
			// 
			// OpenWindowsColorForm
			// 
			this.OpenWindowsColorForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(62)))));
			this.OpenWindowsColorForm.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.OpenWindowsColorForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.OpenWindowsColorForm.ForeColor = System.Drawing.SystemColors.Info;
			this.OpenWindowsColorForm.Location = new System.Drawing.Point(317, 254);
			this.OpenWindowsColorForm.Name = "OpenWindowsColorForm";
			this.OpenWindowsColorForm.Size = new System.Drawing.Size(262, 26);
			this.OpenWindowsColorForm.TabIndex = 27;
			this.OpenWindowsColorForm.Text = "Use Windows Color Picker";
			this.OpenWindowsColorForm.UseVisualStyleBackColor = false;
			this.OpenWindowsColorForm.Click += new System.EventHandler(this.OpenWindowsColorForm_Click);
			// 
			// ColorPreview
			// 
			this.ColorPreview.BackColor = System.Drawing.Color.Black;
			this.ColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ColorPreview.Location = new System.Drawing.Point(156, 239);
			this.ColorPreview.Name = "ColorPreview";
			this.ColorPreview.Size = new System.Drawing.Size(139, 51);
			this.ColorPreview.TabIndex = 23;
			this.ColorPreview.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.CopyBrightnessValue);
			this.groupBox2.Controls.Add(this.CopySaturationValue);
			this.groupBox2.Controls.Add(this.CopyPaintSwatchValue);
			this.groupBox2.Controls.Add(this.TextBoxBrightness);
			this.groupBox2.Controls.Add(this.TextBoxSaturation);
			this.groupBox2.Controls.Add(this.TextBoxPaintSwatch);
			this.groupBox2.Controls.Add(this.LabelBrightness);
			this.groupBox2.Controls.Add(this.LabelSaturation);
			this.groupBox2.Controls.Add(this.LabelPaintSwatch);
			this.groupBox2.ForeColor = System.Drawing.SystemColors.Info;
			this.groupBox2.Location = new System.Drawing.Point(388, 18);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(297, 198);
			this.groupBox2.TabIndex = 28;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Swatch Color";
			// 
			// CopyBrightnessValue
			// 
			this.CopyBrightnessValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
			this.CopyBrightnessValue.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.CopyBrightnessValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CopyBrightnessValue.ForeColor = System.Drawing.SystemColors.Info;
			this.CopyBrightnessValue.Location = new System.Drawing.Point(197, 138);
			this.CopyBrightnessValue.Name = "CopyBrightnessValue";
			this.CopyBrightnessValue.Size = new System.Drawing.Size(82, 22);
			this.CopyBrightnessValue.TabIndex = 35;
			this.CopyBrightnessValue.Text = "Copy";
			this.CopyBrightnessValue.UseVisualStyleBackColor = false;
			this.CopyBrightnessValue.Click += new System.EventHandler(this.CopyBrightnessValue_Click);
			// 
			// CopySaturationValue
			// 
			this.CopySaturationValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
			this.CopySaturationValue.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.CopySaturationValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CopySaturationValue.ForeColor = System.Drawing.SystemColors.Info;
			this.CopySaturationValue.Location = new System.Drawing.Point(197, 92);
			this.CopySaturationValue.Name = "CopySaturationValue";
			this.CopySaturationValue.Size = new System.Drawing.Size(82, 22);
			this.CopySaturationValue.TabIndex = 34;
			this.CopySaturationValue.Text = "Copy";
			this.CopySaturationValue.UseVisualStyleBackColor = false;
			this.CopySaturationValue.Click += new System.EventHandler(this.CopySaturationValue_Click);
			// 
			// CopyPaintSwatchValue
			// 
			this.CopyPaintSwatchValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
			this.CopyPaintSwatchValue.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.CopyPaintSwatchValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CopyPaintSwatchValue.ForeColor = System.Drawing.SystemColors.Info;
			this.CopyPaintSwatchValue.Location = new System.Drawing.Point(197, 43);
			this.CopyPaintSwatchValue.Name = "CopyPaintSwatchValue";
			this.CopyPaintSwatchValue.Size = new System.Drawing.Size(82, 22);
			this.CopyPaintSwatchValue.TabIndex = 33;
			this.CopyPaintSwatchValue.Text = "Copy";
			this.CopyPaintSwatchValue.UseVisualStyleBackColor = false;
			this.CopyPaintSwatchValue.Click += new System.EventHandler(this.CopyPaintSwatchValue_Click);
			// 
			// TextBoxBrightness
			// 
			this.TextBoxBrightness.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
			this.TextBoxBrightness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxBrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextBoxBrightness.ForeColor = System.Drawing.SystemColors.Info;
			this.TextBoxBrightness.Location = new System.Drawing.Point(110, 138);
			this.TextBoxBrightness.Name = "TextBoxBrightness";
			this.TextBoxBrightness.ReadOnly = true;
			this.TextBoxBrightness.Size = new System.Drawing.Size(81, 22);
			this.TextBoxBrightness.TabIndex = 32;
			this.TextBoxBrightness.Text = "0";
			// 
			// TextBoxSaturation
			// 
			this.TextBoxSaturation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
			this.TextBoxSaturation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxSaturation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextBoxSaturation.ForeColor = System.Drawing.SystemColors.Info;
			this.TextBoxSaturation.Location = new System.Drawing.Point(110, 92);
			this.TextBoxSaturation.Name = "TextBoxSaturation";
			this.TextBoxSaturation.ReadOnly = true;
			this.TextBoxSaturation.Size = new System.Drawing.Size(81, 22);
			this.TextBoxSaturation.TabIndex = 31;
			this.TextBoxSaturation.Text = "0";
			// 
			// TextBoxPaintSwatch
			// 
			this.TextBoxPaintSwatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
			this.TextBoxPaintSwatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxPaintSwatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextBoxPaintSwatch.ForeColor = System.Drawing.SystemColors.Info;
			this.TextBoxPaintSwatch.Location = new System.Drawing.Point(110, 43);
			this.TextBoxPaintSwatch.Name = "TextBoxPaintSwatch";
			this.TextBoxPaintSwatch.ReadOnly = true;
			this.TextBoxPaintSwatch.Size = new System.Drawing.Size(81, 22);
			this.TextBoxPaintSwatch.TabIndex = 30;
			this.TextBoxPaintSwatch.Text = "0";
			// 
			// LabelBrightness
			// 
			this.LabelBrightness.AutoSize = true;
			this.LabelBrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelBrightness.ForeColor = System.Drawing.Color.White;
			this.LabelBrightness.Location = new System.Drawing.Point(6, 138);
			this.LabelBrightness.Name = "LabelBrightness";
			this.LabelBrightness.Size = new System.Drawing.Size(85, 20);
			this.LabelBrightness.TabIndex = 29;
			this.LabelBrightness.Text = "Brightness";
			// 
			// LabelSaturation
			// 
			this.LabelSaturation.AutoSize = true;
			this.LabelSaturation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelSaturation.ForeColor = System.Drawing.Color.White;
			this.LabelSaturation.Location = new System.Drawing.Point(6, 92);
			this.LabelSaturation.Name = "LabelSaturation";
			this.LabelSaturation.Size = new System.Drawing.Size(83, 20);
			this.LabelSaturation.TabIndex = 28;
			this.LabelSaturation.Text = "Saturation";
			// 
			// LabelPaintSwatch
			// 
			this.LabelPaintSwatch.AutoSize = true;
			this.LabelPaintSwatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelPaintSwatch.ForeColor = System.Drawing.Color.White;
			this.LabelPaintSwatch.Location = new System.Drawing.Point(6, 43);
			this.LabelPaintSwatch.Name = "LabelPaintSwatch";
			this.LabelPaintSwatch.Size = new System.Drawing.Size(98, 20);
			this.LabelPaintSwatch.TabIndex = 27;
			this.LabelPaintSwatch.Text = "PaintSwatch";
			// 
			// SwatchPicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(36)))), ((int)(((byte)(53)))));
			this.ClientSize = new System.Drawing.Size(711, 313);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.OpenWindowsColorForm);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.ColorPreview);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "SwatchPicker";
			this.Text = "SwatchPicker by MaxHwoy";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Blue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Green)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Red)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ColorPreview)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button OpenWindowsColorForm;
		private System.Windows.Forms.Label LabelBlue;
		private System.Windows.Forms.Label LabelGreen;
		private System.Windows.Forms.Label LabelRed;
		private System.Windows.Forms.PictureBox ColorPreview;
		private System.Windows.Forms.TrackBar TrackBar_Blue;
		private System.Windows.Forms.TrackBar TrackBar_Green;
		private System.Windows.Forms.TrackBar TrackBar_Red;
		private System.Windows.Forms.ColorDialog SwatchDialog;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox TextBoxPaintSwatch;
		private System.Windows.Forms.Label LabelBrightness;
		private System.Windows.Forms.Label LabelSaturation;
		private System.Windows.Forms.Label LabelPaintSwatch;
		private System.Windows.Forms.Button CopyPaintSwatchValue;
		private System.Windows.Forms.TextBox TextBoxBrightness;
		private System.Windows.Forms.TextBox TextBoxSaturation;
		private System.Windows.Forms.Button CopyBrightnessValue;
		private System.Windows.Forms.Button CopySaturationValue;
	}
}