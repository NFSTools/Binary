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



namespace Binary.Tools
{
    partial class ColorPicker
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorPicker));
			this.MainGroupBox = new System.Windows.Forms.GroupBox();
			this.ComboTypeSelection = new System.Windows.Forms.ComboBox();
			this.ColorBackground = new System.Windows.Forms.PictureBox();
			this.ColorPreview = new System.Windows.Forms.PictureBox();
			this.LabelLevel = new System.Windows.Forms.Label();
			this.CopyLevelValue = new System.Windows.Forms.Button();
			this.TextBoxLevel = new System.Windows.Forms.TextBox();
			this.TrackBar_Level = new System.Windows.Forms.TrackBar();
			this.OpenWindowsColorForm = new System.Windows.Forms.Button();
			this.LabelBlue = new System.Windows.Forms.Label();
			this.LabelGreen = new System.Windows.Forms.Label();
			this.LabelRed = new System.Windows.Forms.Label();
			this.CopyBlueValue = new System.Windows.Forms.Button();
			this.CopyGreenValue = new System.Windows.Forms.Button();
			this.CopyRedValue = new System.Windows.Forms.Button();
			this.TextBoxBlue = new System.Windows.Forms.TextBox();
			this.TextBoxGreen = new System.Windows.Forms.TextBox();
			this.TextBoxRed = new System.Windows.Forms.TextBox();
			this.TrackBar_Blue = new System.Windows.Forms.TrackBar();
			this.TrackBar_Green = new System.Windows.Forms.TrackBar();
			this.TrackBar_Red = new System.Windows.Forms.TrackBar();
			this.SwatchDialog = new System.Windows.Forms.ColorDialog();
			this.MainGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ColorBackground)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ColorPreview)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Level)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Blue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Green)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Red)).BeginInit();
			this.SuspendLayout();
			// 
			// MainGroupBox
			// 
			this.MainGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MainGroupBox.Controls.Add(this.ComboTypeSelection);
			this.MainGroupBox.Controls.Add(this.ColorBackground);
			this.MainGroupBox.Controls.Add(this.ColorPreview);
			this.MainGroupBox.Controls.Add(this.LabelLevel);
			this.MainGroupBox.Controls.Add(this.CopyLevelValue);
			this.MainGroupBox.Controls.Add(this.TextBoxLevel);
			this.MainGroupBox.Controls.Add(this.TrackBar_Level);
			this.MainGroupBox.Controls.Add(this.OpenWindowsColorForm);
			this.MainGroupBox.Controls.Add(this.LabelBlue);
			this.MainGroupBox.Controls.Add(this.LabelGreen);
			this.MainGroupBox.Controls.Add(this.LabelRed);
			this.MainGroupBox.Controls.Add(this.CopyBlueValue);
			this.MainGroupBox.Controls.Add(this.CopyGreenValue);
			this.MainGroupBox.Controls.Add(this.CopyRedValue);
			this.MainGroupBox.Controls.Add(this.TextBoxBlue);
			this.MainGroupBox.Controls.Add(this.TextBoxGreen);
			this.MainGroupBox.Controls.Add(this.TextBoxRed);
			this.MainGroupBox.Controls.Add(this.TrackBar_Blue);
			this.MainGroupBox.Controls.Add(this.TrackBar_Green);
			this.MainGroupBox.Controls.Add(this.TrackBar_Red);
			this.MainGroupBox.ForeColor = System.Drawing.SystemColors.Info;
			this.MainGroupBox.Location = new System.Drawing.Point(27, 24);
			this.MainGroupBox.Name = "MainGroupBox";
			this.MainGroupBox.Size = new System.Drawing.Size(573, 307);
			this.MainGroupBox.TabIndex = 0;
			this.MainGroupBox.TabStop = false;
			this.MainGroupBox.Text = "Material/Paint Color Picker";
			// 
			// ComboTypeSelection
			// 
			this.ComboTypeSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
			this.ComboTypeSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ComboTypeSelection.ForeColor = System.Drawing.SystemColors.Info;
			this.ComboTypeSelection.FormattingEnabled = true;
			this.ComboTypeSelection.Items.AddRange(new object[] {
            "Use material/paint float32 values",
            "Use FEng/Vinyl int8 ARGB values"});
			this.ComboTypeSelection.Location = new System.Drawing.Point(239, 266);
			this.ComboTypeSelection.Name = "ComboTypeSelection";
			this.ComboTypeSelection.Size = new System.Drawing.Size(262, 21);
			this.ComboTypeSelection.TabIndex = 33;
			this.ComboTypeSelection.SelectedIndexChanged += new System.EventHandler(this.ComboTypeSelection_SelectedIndexChanged);
			// 
			// ColorBackground
			// 
			this.ColorBackground.BackColor = System.Drawing.Color.Black;
			this.ColorBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ColorBackground.Image = global::Binary.Properties.Resources.background;
			this.ColorBackground.Location = new System.Drawing.Point(94, 236);
			this.ColorBackground.Name = "ColorBackground";
			this.ColorBackground.Size = new System.Drawing.Size(139, 51);
			this.ColorBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ColorBackground.TabIndex = 32;
			this.ColorBackground.TabStop = false;
			// 
			// ColorPreview
			// 
			this.ColorPreview.BackColor = System.Drawing.Color.Black;
			this.ColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ColorPreview.Location = new System.Drawing.Point(94, 236);
			this.ColorPreview.Name = "ColorPreview";
			this.ColorPreview.Size = new System.Drawing.Size(139, 51);
			this.ColorPreview.TabIndex = 23;
			this.ColorPreview.TabStop = false;
			// 
			// LabelLevel
			// 
			this.LabelLevel.AutoSize = true;
			this.LabelLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.LabelLevel.Location = new System.Drawing.Point(29, 40);
			this.LabelLevel.Name = "LabelLevel";
			this.LabelLevel.Size = new System.Drawing.Size(46, 20);
			this.LabelLevel.TabIndex = 31;
			this.LabelLevel.Text = "Level";
			// 
			// CopyLevelValue
			// 
			this.CopyLevelValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
			this.CopyLevelValue.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.CopyLevelValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CopyLevelValue.ForeColor = System.Drawing.SystemColors.Info;
			this.CopyLevelValue.Location = new System.Drawing.Point(463, 40);
			this.CopyLevelValue.Name = "CopyLevelValue";
			this.CopyLevelValue.Size = new System.Drawing.Size(86, 24);
			this.CopyLevelValue.TabIndex = 30;
			this.CopyLevelValue.Text = "Copy";
			this.CopyLevelValue.UseVisualStyleBackColor = false;
			this.CopyLevelValue.Click += new System.EventHandler(this.CopyLevelValue_Click);
			// 
			// TextBoxLevel
			// 
			this.TextBoxLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
			this.TextBoxLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextBoxLevel.ForeColor = System.Drawing.SystemColors.Info;
			this.TextBoxLevel.Location = new System.Drawing.Point(81, 42);
			this.TextBoxLevel.Name = "TextBoxLevel";
			this.TextBoxLevel.ReadOnly = true;
			this.TextBoxLevel.Size = new System.Drawing.Size(86, 22);
			this.TextBoxLevel.TabIndex = 29;
			this.TextBoxLevel.Text = "1";
			this.TextBoxLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// TrackBar_Level
			// 
			this.TrackBar_Level.Location = new System.Drawing.Point(178, 35);
			this.TrackBar_Level.Maximum = 255;
			this.TrackBar_Level.Name = "TrackBar_Level";
			this.TrackBar_Level.Size = new System.Drawing.Size(279, 45);
			this.TrackBar_Level.TabIndex = 28;
			this.TrackBar_Level.Value = 255;
			this.TrackBar_Level.Scroll += new System.EventHandler(this.TrackBar_Level_Scroll);
			// 
			// OpenWindowsColorForm
			// 
			this.OpenWindowsColorForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
			this.OpenWindowsColorForm.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.OpenWindowsColorForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.OpenWindowsColorForm.ForeColor = System.Drawing.SystemColors.Info;
			this.OpenWindowsColorForm.Location = new System.Drawing.Point(239, 236);
			this.OpenWindowsColorForm.Name = "OpenWindowsColorForm";
			this.OpenWindowsColorForm.Size = new System.Drawing.Size(262, 26);
			this.OpenWindowsColorForm.TabIndex = 27;
			this.OpenWindowsColorForm.Text = "Use Windows Color Picker";
			this.OpenWindowsColorForm.UseVisualStyleBackColor = false;
			this.OpenWindowsColorForm.Click += new System.EventHandler(this.OpenWindowsColorForm_Click);
			// 
			// LabelBlue
			// 
			this.LabelBlue.AutoSize = true;
			this.LabelBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelBlue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.LabelBlue.Location = new System.Drawing.Point(34, 185);
			this.LabelBlue.Name = "LabelBlue";
			this.LabelBlue.Size = new System.Drawing.Size(41, 20);
			this.LabelBlue.TabIndex = 26;
			this.LabelBlue.Text = "Blue";
			// 
			// LabelGreen
			// 
			this.LabelGreen.AutoSize = true;
			this.LabelGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelGreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.LabelGreen.Location = new System.Drawing.Point(21, 134);
			this.LabelGreen.Name = "LabelGreen";
			this.LabelGreen.Size = new System.Drawing.Size(54, 20);
			this.LabelGreen.TabIndex = 25;
			this.LabelGreen.Text = "Green";
			// 
			// LabelRed
			// 
			this.LabelRed.AutoSize = true;
			this.LabelRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelRed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.LabelRed.Location = new System.Drawing.Point(36, 88);
			this.LabelRed.Name = "LabelRed";
			this.LabelRed.Size = new System.Drawing.Size(39, 20);
			this.LabelRed.TabIndex = 24;
			this.LabelRed.Text = "Red";
			// 
			// CopyBlueValue
			// 
			this.CopyBlueValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
			this.CopyBlueValue.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.CopyBlueValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CopyBlueValue.ForeColor = System.Drawing.SystemColors.Info;
			this.CopyBlueValue.Location = new System.Drawing.Point(463, 183);
			this.CopyBlueValue.Name = "CopyBlueValue";
			this.CopyBlueValue.Size = new System.Drawing.Size(86, 24);
			this.CopyBlueValue.TabIndex = 22;
			this.CopyBlueValue.Text = "Copy";
			this.CopyBlueValue.UseVisualStyleBackColor = false;
			this.CopyBlueValue.Click += new System.EventHandler(this.CopyBlueValue_Click);
			// 
			// CopyGreenValue
			// 
			this.CopyGreenValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
			this.CopyGreenValue.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.CopyGreenValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CopyGreenValue.ForeColor = System.Drawing.SystemColors.Info;
			this.CopyGreenValue.Location = new System.Drawing.Point(463, 134);
			this.CopyGreenValue.Name = "CopyGreenValue";
			this.CopyGreenValue.Size = new System.Drawing.Size(86, 24);
			this.CopyGreenValue.TabIndex = 21;
			this.CopyGreenValue.Text = "Copy";
			this.CopyGreenValue.UseVisualStyleBackColor = false;
			this.CopyGreenValue.Click += new System.EventHandler(this.CopyGreenValue_Click);
			// 
			// CopyRedValue
			// 
			this.CopyRedValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
			this.CopyRedValue.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.CopyRedValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CopyRedValue.ForeColor = System.Drawing.SystemColors.Info;
			this.CopyRedValue.Location = new System.Drawing.Point(463, 88);
			this.CopyRedValue.Name = "CopyRedValue";
			this.CopyRedValue.Size = new System.Drawing.Size(86, 24);
			this.CopyRedValue.TabIndex = 20;
			this.CopyRedValue.Text = "Copy";
			this.CopyRedValue.UseVisualStyleBackColor = false;
			this.CopyRedValue.Click += new System.EventHandler(this.CopyRedValue_Click);
			// 
			// TextBoxBlue
			// 
			this.TextBoxBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
			this.TextBoxBlue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextBoxBlue.ForeColor = System.Drawing.SystemColors.Info;
			this.TextBoxBlue.Location = new System.Drawing.Point(81, 185);
			this.TextBoxBlue.Name = "TextBoxBlue";
			this.TextBoxBlue.ReadOnly = true;
			this.TextBoxBlue.Size = new System.Drawing.Size(86, 22);
			this.TextBoxBlue.TabIndex = 19;
			this.TextBoxBlue.Text = "0";
			this.TextBoxBlue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// TextBoxGreen
			// 
			this.TextBoxGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
			this.TextBoxGreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextBoxGreen.ForeColor = System.Drawing.SystemColors.Info;
			this.TextBoxGreen.Location = new System.Drawing.Point(81, 136);
			this.TextBoxGreen.Name = "TextBoxGreen";
			this.TextBoxGreen.ReadOnly = true;
			this.TextBoxGreen.Size = new System.Drawing.Size(86, 22);
			this.TextBoxGreen.TabIndex = 18;
			this.TextBoxGreen.Text = "0";
			this.TextBoxGreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// TextBoxRed
			// 
			this.TextBoxRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
			this.TextBoxRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBoxRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextBoxRed.ForeColor = System.Drawing.SystemColors.Info;
			this.TextBoxRed.Location = new System.Drawing.Point(81, 90);
			this.TextBoxRed.Name = "TextBoxRed";
			this.TextBoxRed.ReadOnly = true;
			this.TextBoxRed.Size = new System.Drawing.Size(86, 22);
			this.TextBoxRed.TabIndex = 17;
			this.TextBoxRed.Text = "0";
			this.TextBoxRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// TrackBar_Blue
			// 
			this.TrackBar_Blue.Location = new System.Drawing.Point(178, 185);
			this.TrackBar_Blue.Maximum = 255;
			this.TrackBar_Blue.Name = "TrackBar_Blue";
			this.TrackBar_Blue.Size = new System.Drawing.Size(279, 45);
			this.TrackBar_Blue.TabIndex = 16;
			this.TrackBar_Blue.Scroll += new System.EventHandler(this.TrackBar_Blue_Scroll);
			// 
			// TrackBar_Green
			// 
			this.TrackBar_Green.Location = new System.Drawing.Point(178, 134);
			this.TrackBar_Green.Maximum = 255;
			this.TrackBar_Green.Name = "TrackBar_Green";
			this.TrackBar_Green.Size = new System.Drawing.Size(279, 45);
			this.TrackBar_Green.TabIndex = 15;
			this.TrackBar_Green.Scroll += new System.EventHandler(this.TrackBar_Green_Scroll);
			// 
			// TrackBar_Red
			// 
			this.TrackBar_Red.Location = new System.Drawing.Point(178, 83);
			this.TrackBar_Red.Maximum = 255;
			this.TrackBar_Red.Name = "TrackBar_Red";
			this.TrackBar_Red.Size = new System.Drawing.Size(279, 45);
			this.TrackBar_Red.TabIndex = 14;
			this.TrackBar_Red.Scroll += new System.EventHandler(this.TrackBar_Red_Scroll);
			// 
			// ColorPicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(36)))), ((int)(((byte)(53)))));
			this.ClientSize = new System.Drawing.Size(623, 343);
			this.Controls.Add(this.MainGroupBox);
			this.ForeColor = System.Drawing.SystemColors.Control;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "ColorPicker";
			this.Text = "Color Picker by MaxHwoy";
			this.MainGroupBox.ResumeLayout(false);
			this.MainGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ColorBackground)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ColorPreview)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Level)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Blue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Green)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Red)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MainGroupBox;
        private System.Windows.Forms.Button OpenWindowsColorForm;
        private System.Windows.Forms.Label LabelBlue;
        private System.Windows.Forms.Label LabelGreen;
        private System.Windows.Forms.Label LabelRed;
        private System.Windows.Forms.PictureBox ColorPreview;
        private System.Windows.Forms.Button CopyBlueValue;
        private System.Windows.Forms.Button CopyGreenValue;
        private System.Windows.Forms.Button CopyRedValue;
        private System.Windows.Forms.TextBox TextBoxBlue;
        private System.Windows.Forms.TextBox TextBoxGreen;
        private System.Windows.Forms.TextBox TextBoxRed;
        private System.Windows.Forms.TrackBar TrackBar_Blue;
        private System.Windows.Forms.TrackBar TrackBar_Green;
        private System.Windows.Forms.TrackBar TrackBar_Red;
        private System.Windows.Forms.ColorDialog SwatchDialog;
        private System.Windows.Forms.PictureBox ColorBackground;
        private System.Windows.Forms.Label LabelLevel;
        private System.Windows.Forms.Button CopyLevelValue;
        private System.Windows.Forms.TextBox TextBoxLevel;
        private System.Windows.Forms.TrackBar TrackBar_Level;
        private System.Windows.Forms.ComboBox ComboTypeSelection;
    }
}