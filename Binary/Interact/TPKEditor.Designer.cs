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
    partial class TPKEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TPKEditor));
			this.BackImage = new System.Windows.Forms.PictureBox();
			this.PreviewImage = new System.Windows.Forms.PictureBox();
			this.LabelCollectionName = new System.Windows.Forms.Label();
			this.BoxCollectionName = new System.Windows.Forms.TextBox();
			this.LabelCompression = new System.Windows.Forms.Label();
			this.BoxCompression = new System.Windows.Forms.TextBox();
			this.BoxWidth = new System.Windows.Forms.TextBox();
			this.LabelWidth = new System.Windows.Forms.Label();
			this.BoxHeight = new System.Windows.Forms.TextBox();
			this.LabelHeight = new System.Windows.Forms.Label();
			this.BoxMipmaps = new System.Windows.Forms.TextBox();
			this.LabelMipmaps = new System.Windows.Forms.Label();
			this.ReplaceTexture = new System.Windows.Forms.Button();
			this.ExportOneAs = new System.Windows.Forms.Button();
			this.DeleteTexture = new System.Windows.Forms.Button();
			this.DuplicateTexture = new System.Windows.Forms.Button();
			this.ButtonOK = new System.Windows.Forms.Button();
			this.ButtonCancel = new System.Windows.Forms.Button();
			this.ReplaceTextureDialog = new System.Windows.Forms.OpenFileDialog();
			this.ExportTextureDialog = new System.Windows.Forms.SaveFileDialog();
			this.ExportAllDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.AddTexture = new System.Windows.Forms.Button();
			this.AddTextureDialog = new System.Windows.Forms.OpenFileDialog();
			this.TileableUVEnabled = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.BackImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PreviewImage)).BeginInit();
			this.SuspendLayout();
			// 
			// BackImage
			// 
			this.BackImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BackImage.Image = global::Binary.Properties.Resources.background1;
			this.BackImage.Location = new System.Drawing.Point(260, 12);
			this.BackImage.Name = "BackImage";
			this.BackImage.Size = new System.Drawing.Size(512, 512);
			this.BackImage.TabIndex = 0;
			this.BackImage.TabStop = false;
			// 
			// PreviewImage
			// 
			this.PreviewImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.PreviewImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PreviewImage.Location = new System.Drawing.Point(260, 12);
			this.PreviewImage.Name = "PreviewImage";
			this.PreviewImage.Size = new System.Drawing.Size(512, 512);
			this.PreviewImage.TabIndex = 1;
			this.PreviewImage.TabStop = false;
			// 
			// LabelCollectionName
			// 
			this.LabelCollectionName.AutoSize = true;
			this.LabelCollectionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelCollectionName.ForeColor = System.Drawing.SystemColors.Info;
			this.LabelCollectionName.Location = new System.Drawing.Point(12, 12);
			this.LabelCollectionName.Name = "LabelCollectionName";
			this.LabelCollectionName.Size = new System.Drawing.Size(120, 20);
			this.LabelCollectionName.TabIndex = 2;
			this.LabelCollectionName.Text = "CollectionName";
			// 
			// BoxCollectionName
			// 
			this.BoxCollectionName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.BoxCollectionName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BoxCollectionName.ForeColor = System.Drawing.SystemColors.Info;
			this.BoxCollectionName.Location = new System.Drawing.Point(16, 35);
			this.BoxCollectionName.Name = "BoxCollectionName";
			this.BoxCollectionName.Size = new System.Drawing.Size(227, 20);
			this.BoxCollectionName.TabIndex = 3;
			// 
			// LabelCompression
			// 
			this.LabelCompression.AutoSize = true;
			this.LabelCompression.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelCompression.ForeColor = System.Drawing.SystemColors.Info;
			this.LabelCompression.Location = new System.Drawing.Point(30, 72);
			this.LabelCompression.Name = "LabelCompression";
			this.LabelCompression.Size = new System.Drawing.Size(102, 20);
			this.LabelCompression.TabIndex = 4;
			this.LabelCompression.Text = "Compression";
			// 
			// BoxCompression
			// 
			this.BoxCompression.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.BoxCompression.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BoxCompression.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BoxCompression.ForeColor = System.Drawing.SystemColors.Info;
			this.BoxCompression.Location = new System.Drawing.Point(138, 72);
			this.BoxCompression.Name = "BoxCompression";
			this.BoxCompression.ReadOnly = true;
			this.BoxCompression.Size = new System.Drawing.Size(83, 22);
			this.BoxCompression.TabIndex = 5;
			// 
			// BoxWidth
			// 
			this.BoxWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.BoxWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BoxWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BoxWidth.ForeColor = System.Drawing.SystemColors.Info;
			this.BoxWidth.Location = new System.Drawing.Point(138, 100);
			this.BoxWidth.Name = "BoxWidth";
			this.BoxWidth.ReadOnly = true;
			this.BoxWidth.Size = new System.Drawing.Size(83, 22);
			this.BoxWidth.TabIndex = 7;
			// 
			// LabelWidth
			// 
			this.LabelWidth.AutoSize = true;
			this.LabelWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelWidth.ForeColor = System.Drawing.SystemColors.Info;
			this.LabelWidth.Location = new System.Drawing.Point(82, 100);
			this.LabelWidth.Name = "LabelWidth";
			this.LabelWidth.Size = new System.Drawing.Size(50, 20);
			this.LabelWidth.TabIndex = 6;
			this.LabelWidth.Text = "Width";
			// 
			// BoxHeight
			// 
			this.BoxHeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.BoxHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BoxHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BoxHeight.ForeColor = System.Drawing.SystemColors.Info;
			this.BoxHeight.Location = new System.Drawing.Point(138, 128);
			this.BoxHeight.Name = "BoxHeight";
			this.BoxHeight.ReadOnly = true;
			this.BoxHeight.Size = new System.Drawing.Size(83, 22);
			this.BoxHeight.TabIndex = 9;
			// 
			// LabelHeight
			// 
			this.LabelHeight.AutoSize = true;
			this.LabelHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelHeight.ForeColor = System.Drawing.SystemColors.Info;
			this.LabelHeight.Location = new System.Drawing.Point(76, 128);
			this.LabelHeight.Name = "LabelHeight";
			this.LabelHeight.Size = new System.Drawing.Size(56, 20);
			this.LabelHeight.TabIndex = 8;
			this.LabelHeight.Text = "Height";
			// 
			// BoxMipmaps
			// 
			this.BoxMipmaps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.BoxMipmaps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BoxMipmaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BoxMipmaps.ForeColor = System.Drawing.SystemColors.Info;
			this.BoxMipmaps.Location = new System.Drawing.Point(138, 156);
			this.BoxMipmaps.Name = "BoxMipmaps";
			this.BoxMipmaps.ReadOnly = true;
			this.BoxMipmaps.Size = new System.Drawing.Size(83, 22);
			this.BoxMipmaps.TabIndex = 11;
			// 
			// LabelMipmaps
			// 
			this.LabelMipmaps.AutoSize = true;
			this.LabelMipmaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelMipmaps.ForeColor = System.Drawing.SystemColors.Info;
			this.LabelMipmaps.Location = new System.Drawing.Point(59, 156);
			this.LabelMipmaps.Name = "LabelMipmaps";
			this.LabelMipmaps.Size = new System.Drawing.Size(73, 20);
			this.LabelMipmaps.TabIndex = 10;
			this.LabelMipmaps.Text = "Mipmaps";
			// 
			// ReplaceTexture
			// 
			this.ReplaceTexture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.ReplaceTexture.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.ReplaceTexture.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ReplaceTexture.ForeColor = System.Drawing.SystemColors.Info;
			this.ReplaceTexture.Location = new System.Drawing.Point(16, 285);
			this.ReplaceTexture.Name = "ReplaceTexture";
			this.ReplaceTexture.Size = new System.Drawing.Size(226, 25);
			this.ReplaceTexture.TabIndex = 12;
			this.ReplaceTexture.Text = "Replace Texture";
			this.ReplaceTexture.UseVisualStyleBackColor = false;
			this.ReplaceTexture.Click += new System.EventHandler(this.ReplaceTexture_Click);
			// 
			// ExportOneAs
			// 
			this.ExportOneAs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.ExportOneAs.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.ExportOneAs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ExportOneAs.ForeColor = System.Drawing.SystemColors.Info;
			this.ExportOneAs.Location = new System.Drawing.Point(16, 325);
			this.ExportOneAs.Name = "ExportOneAs";
			this.ExportOneAs.Size = new System.Drawing.Size(226, 25);
			this.ExportOneAs.TabIndex = 13;
			this.ExportOneAs.Text = "Export Texture As";
			this.ExportOneAs.UseVisualStyleBackColor = false;
			this.ExportOneAs.Click += new System.EventHandler(this.ExportOneAs_Click);
			// 
			// DeleteTexture
			// 
			this.DeleteTexture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.DeleteTexture.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.DeleteTexture.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.DeleteTexture.ForeColor = System.Drawing.SystemColors.Info;
			this.DeleteTexture.Location = new System.Drawing.Point(17, 367);
			this.DeleteTexture.Name = "DeleteTexture";
			this.DeleteTexture.Size = new System.Drawing.Size(226, 25);
			this.DeleteTexture.TabIndex = 15;
			this.DeleteTexture.Text = "Delete Texture";
			this.DeleteTexture.UseVisualStyleBackColor = false;
			this.DeleteTexture.Click += new System.EventHandler(this.DeleteTexture_Click);
			// 
			// DuplicateTexture
			// 
			this.DuplicateTexture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.DuplicateTexture.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.DuplicateTexture.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.DuplicateTexture.ForeColor = System.Drawing.SystemColors.Info;
			this.DuplicateTexture.Location = new System.Drawing.Point(16, 245);
			this.DuplicateTexture.Name = "DuplicateTexture";
			this.DuplicateTexture.Size = new System.Drawing.Size(226, 25);
			this.DuplicateTexture.TabIndex = 16;
			this.DuplicateTexture.Text = "Duplicate Texture";
			this.DuplicateTexture.UseVisualStyleBackColor = false;
			this.DuplicateTexture.Click += new System.EventHandler(this.DuplicateTexture_Click);
			// 
			// ButtonOK
			// 
			this.ButtonOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.ButtonOK.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ButtonOK.ForeColor = System.Drawing.SystemColors.Info;
			this.ButtonOK.Location = new System.Drawing.Point(12, 499);
			this.ButtonOK.Name = "ButtonOK";
			this.ButtonOK.Size = new System.Drawing.Size(110, 25);
			this.ButtonOK.TabIndex = 17;
			this.ButtonOK.Text = "OK";
			this.ButtonOK.UseVisualStyleBackColor = false;
			this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
			// 
			// ButtonCancel
			// 
			this.ButtonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.ButtonCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ButtonCancel.ForeColor = System.Drawing.SystemColors.Info;
			this.ButtonCancel.Location = new System.Drawing.Point(133, 499);
			this.ButtonCancel.Name = "ButtonCancel";
			this.ButtonCancel.Size = new System.Drawing.Size(110, 25);
			this.ButtonCancel.TabIndex = 18;
			this.ButtonCancel.Text = "Cancel";
			this.ButtonCancel.UseVisualStyleBackColor = false;
			this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// ReplaceTextureDialog
			// 
			this.ReplaceTextureDialog.Filter = "Direct Draw Surface Files|*.dds";
			this.ReplaceTextureDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.ReplaceTextureDialog_FileOk);
			// 
			// ExportTextureDialog
			// 
			this.ExportTextureDialog.DefaultExt = "dds";
			// 
			// ExportAllDialog
			// 
			this.ExportAllDialog.Description = "Select the folder in which you want all textures to be extracted.";
			this.ExportAllDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
			// 
			// AddTexture
			// 
			this.AddTexture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.AddTexture.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.AddTexture.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.AddTexture.ForeColor = System.Drawing.SystemColors.Info;
			this.AddTexture.Location = new System.Drawing.Point(16, 205);
			this.AddTexture.Name = "AddTexture";
			this.AddTexture.Size = new System.Drawing.Size(226, 25);
			this.AddTexture.TabIndex = 19;
			this.AddTexture.Text = "Add Texture";
			this.AddTexture.UseVisualStyleBackColor = false;
			this.AddTexture.Click += new System.EventHandler(this.AddTexture_Click);
			// 
			// AddTextureDialog
			// 
			this.AddTextureDialog.Filter = "Direct Draw Surface Files|*.dds";
			this.AddTextureDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.AddTextureDialog_FileOk);
			// 
			// TileableUVEnabled
			// 
			this.TileableUVEnabled.AutoSize = true;
			this.TileableUVEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TileableUVEnabled.ForeColor = System.Drawing.SystemColors.Info;
			this.TileableUVEnabled.Location = new System.Drawing.Point(18, 406);
			this.TileableUVEnabled.Name = "TileableUVEnabled";
			this.TileableUVEnabled.Size = new System.Drawing.Size(147, 20);
			this.TileableUVEnabled.TabIndex = 20;
			this.TileableUVEnabled.Text = "Is tileable/seamless";
			this.TileableUVEnabled.UseVisualStyleBackColor = true;
			// 
			// TPKEditor
			// 
			this.AcceptButton = this.ButtonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(36)))), ((int)(((byte)(53)))));
			this.CancelButton = this.ButtonCancel;
			this.ClientSize = new System.Drawing.Size(784, 531);
			this.Controls.Add(this.TileableUVEnabled);
			this.Controls.Add(this.AddTexture);
			this.Controls.Add(this.ButtonCancel);
			this.Controls.Add(this.ButtonOK);
			this.Controls.Add(this.DuplicateTexture);
			this.Controls.Add(this.DeleteTexture);
			this.Controls.Add(this.ExportOneAs);
			this.Controls.Add(this.ReplaceTexture);
			this.Controls.Add(this.BoxMipmaps);
			this.Controls.Add(this.LabelMipmaps);
			this.Controls.Add(this.BoxHeight);
			this.Controls.Add(this.LabelHeight);
			this.Controls.Add(this.BoxWidth);
			this.Controls.Add(this.LabelWidth);
			this.Controls.Add(this.BoxCompression);
			this.Controls.Add(this.LabelCompression);
			this.Controls.Add(this.BoxCollectionName);
			this.Controls.Add(this.LabelCollectionName);
			this.Controls.Add(this.PreviewImage);
			this.Controls.Add(this.BackImage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "TPKEditor";
			this.Text = "Texture Editor by MaxHwoy";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TPKEditor_FormClosed);
			this.Load += new System.EventHandler(this.TPKEditor_Load);
			((System.ComponentModel.ISupportInitialize)(this.BackImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PreviewImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BackImage;
        private System.Windows.Forms.PictureBox PreviewImage;
        private System.Windows.Forms.Label LabelCollectionName;
        private System.Windows.Forms.TextBox BoxCollectionName;
        private System.Windows.Forms.Label LabelCompression;
        private System.Windows.Forms.TextBox BoxCompression;
        private System.Windows.Forms.TextBox BoxWidth;
        private System.Windows.Forms.Label LabelWidth;
        private System.Windows.Forms.TextBox BoxHeight;
        private System.Windows.Forms.Label LabelHeight;
        private System.Windows.Forms.TextBox BoxMipmaps;
        private System.Windows.Forms.Label LabelMipmaps;
        private System.Windows.Forms.Button ReplaceTexture;
        private System.Windows.Forms.Button ExportOneAs;
        private System.Windows.Forms.Button DeleteTexture;
        private System.Windows.Forms.Button DuplicateTexture;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.OpenFileDialog ReplaceTextureDialog;
        private System.Windows.Forms.SaveFileDialog ExportTextureDialog;
        private System.Windows.Forms.FolderBrowserDialog ExportAllDialog;
        private System.Windows.Forms.Button AddTexture;
        private System.Windows.Forms.OpenFileDialog AddTextureDialog;
        private System.Windows.Forms.CheckBox TileableUVEnabled;
    }
}