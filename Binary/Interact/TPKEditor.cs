using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Binary.Endscript;
using GlobalLib.Utils;
using GlobalLib.Reflection.Enum;
using GlobalLib.Support.Shared.Class;



namespace Binary.Interact
{
    public partial class TPKEditor : Form
    {
        private TPKBlock TPK;
        private Texture _texture;
        private string OName;
        public List<string> CommandsProcessed { get; set; } = new List<string>();
        private const string tpkblock = "TPKBlock";
        private const string cname = "CollectionName";
        private const string tileable = "TileableUV";

        public TPKEditor(TPKBlock TPK, uint key)
        {
            this.TPK = TPK;
            this._texture = this.TPK.FindTexture(key, eKeyType.BINKEY);
            this.InitializeComponent();
            this.BackImage.Controls.Add(this.PreviewImage);
            this.PreviewImage.Location = new Point(0, 0);
            this.PreviewImage.BackColor = Color.FromArgb(0, 0, 0, 0);
        }

        private void DisposeImage()
        {
            var disposer = this.PreviewImage.Image;
            if (disposer != null) disposer.Dispose();
        }

        private void ChangeTileable()
        {
            if (this._texture.TileableUV == 0 && this.TileableUVEnabled.Checked)
            {
                this._texture.TileableUV = 3;
                this.CommandsProcessed.Add($"{eCommands.update} {tpkblock} {this.TPK.CollectionName} " +
                    $"0x{this._texture.BinKey:X8} {tileable} 3");
            }
            else if (this._texture.TileableUV > 0 && !this.TileableUVEnabled.Checked)
            {
                this._texture.TileableUV = 0;
                this.CommandsProcessed.Add($"{eCommands.update} {tpkblock} {this.TPK.CollectionName} " +
                    $"0x{this._texture.BinKey:X8} {tileable} 0");
            }
        }

        private void TPKEditor_Load(object sender, EventArgs e)
        {
            this.PreviewImage.Image = this._texture.GetImage();
            this.OName = this._texture.CollectionName;
            this.BoxCollectionName.Text = this._texture.CollectionName;
            this.BoxCompression.Text = this._texture.GetValue("Compression");
            this.BoxWidth.Text = this._texture.Width.ToString();
            this.BoxHeight.Text = this._texture.Height.ToString();
            this.BoxMipmaps.Text = this._texture.Mipmaps.ToString();
            this.TileableUVEnabled.Checked = (this._texture.TileableUV > 0) ? true : false;
            this.PreviewImage.Width = this._texture.Width;
            this.PreviewImage.Height = this._texture.Height;
            if (this.PreviewImage.Width > 512 || this.PreviewImage.Height > 512)
                this.PreviewImage.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void TPKEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            var disposer = this.PreviewImage.Image;
            if (disposer != null) disposer.Dispose();
        }

        private void DuplicateTexture_Click(object sender, EventArgs e)
        {
            var InputWindow = new Input();
            if (InputWindow.ShowDialog() == DialogResult.OK)
            {
                string newname = InputWindow.CollectionName;
                if (!this.TPK.TryCloneTexture(newname, this._texture.BinKey, eKeyType.BINKEY, out var error))
                {
                    MessageBox.Show($"Error occured: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DuplicateTexture_Click(sender, e);
                }
                else
                {
                    this.CommandsProcessed.Add($"{eCommands.copy} {tpkblock} {this.TPK.CollectionName} " +
                        $"0x{this._texture.BinKey:X8} {newname}");
                }
            }
        }

        private void AddTexture_Click(object sender, EventArgs e)
        {
            this.AddTextureDialog.ShowDialog();
        }

        private void AddTextureDialog_FileOk(object sender, CancelEventArgs e)
        {
            string CName = Path.GetFileNameWithoutExtension(AddTextureDialog.FileName);
            if (!this.TPK.TryAddTexture(CName, this.AddTextureDialog.FileName, out var error))
            {
                MessageBox.Show($"Error occured: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void ReplaceTexture_Click(object sender, EventArgs e)
        {
            this.ReplaceTextureDialog.ShowDialog();
        }

        private void ReplaceTextureDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (this.TPK.TryReplaceTexture(this._texture.BinKey, eKeyType.BINKEY,
                this.ReplaceTextureDialog.FileName, out var error))
            {
                this.DisposeImage();
                this.PreviewImage.Image = this._texture.GetImage();
                this.BoxCompression.Text = this._texture.GetValue("Compression");
                this.BoxWidth.Text = this._texture.Width.ToString();
                this.BoxHeight.Text = this._texture.Height.ToString();
                this.BoxMipmaps.Text = this._texture.Mipmaps.ToString();
                this.PreviewImage.Width = this._texture.Width;
                this.PreviewImage.Height = this._texture.Height;
                if (this.PreviewImage.Width > 512 || this.PreviewImage.Height > 512)
                    this.PreviewImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                MessageBox.Show($"Error occured: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void ExportOneAs_Click(object sender, EventArgs e)
        {
            string FilterExt = "Direct Draw Surface files|*.dds|";
            FilterExt += "Portable Network Graphics files|*.png|";
            FilterExt += "Joint Photographic Group files|*.jpg|";
            FilterExt += "Bitmap Pixel Format files|*.bmp|";
            FilterExt += "Tagged Image File Format files|*.tiff";
            this.ExportTextureDialog.Filter = FilterExt;
            if (this.ExportTextureDialog.ShowDialog() == DialogResult.OK)
            {
                string path = this.ExportTextureDialog.FileName;
                string ext = Path.GetExtension(path);
                if (this.TPK.TryExportTexture(this._texture.BinKey, eKeyType.BINKEY, path, ext, out var error))
                    MessageBox.Show("Texture has been successfully exported.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show($"Error occured: {error}", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void DeleteTexture_Click(object sender, EventArgs e)
        {
            if (this.TPK.TryRemoveTexture(this._texture.BinKey, eKeyType.BINKEY, out var error))
            {
                this.CommandsProcessed.Add($"{eCommands.delete} {tpkblock} {this.TPK.CollectionName} " +
                    $"0x{this._texture.BinKey:X8}");
                this.Close();
            }
            else
                MessageBox.Show($"Error occured: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.BoxCollectionName.Text))
            {
                MessageBox.Show("Collection Name cannot be empty or whitespace.", "Warning");
                return;
            }
            var CName = this.BoxCollectionName.Text;
            if (CName != this.OName)
            {
                var exist = this.TPK.FindTexture(Bin.Hash(CName), eKeyType.BINKEY);
                if (exist != null)
                {
                    MessageBox.Show($"Texture with {cname} {CName} already exists.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.CommandsProcessed.Add($"{eCommands.update} {tpkblock} {this.TPK.CollectionName} " +
                    $"0x{this._texture.BinKey:X8} {cname} {CName}");
                this._texture.CollectionName = CName;
            }
            this.ChangeTileable();
            this.DialogResult = DialogResult.OK;
        }
    }
}
