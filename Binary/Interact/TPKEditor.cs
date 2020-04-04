using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Binary.Endscript;
using GlobalLib.Reflection.Enum;
using GlobalLib.Support.Shared.Class;


namespace Binary.Interact
{
    public partial class TPKEditor : Form
    {
        private TPKBlock TPK;
        private Texture _texture;
        public string CollectionName { get; set; }
        public string OriginalName { get; set; }
        public List<string> CommandsProcessed { get; set; } = new List<string>();
        private const string tpkblock = "TPKBlock";
        private const string cname = "CollectionName";
        private const string tileable = "TileableUV";

        public TPKEditor(TPKBlock TPK, Texture texture)
        {
            this.TPK = TPK;
            this._texture = texture;
            InitializeComponent();
            this.BackImage.Controls.Add(this.PreviewImage);
            PreviewImage.Location = new Point(0, 0);
            PreviewImage.BackColor = Color.FromArgb(0, 0, 0, 0);
        }

        private void DisposeImage()
        {
            var disposer = PreviewImage.Image;
            if (disposer != null) disposer.Dispose();
        }

        private void ChangeTileable()
        {
            if (this._texture.TileableUV == 0 && this.TileableUVEnabled.Checked)
            {
                this._texture.TileableUV = 3;
                this.CommandsProcessed.Add($"{Commands.update} {tpkblock} {this.TPK.CollectionName} " +
                    $"{this._texture.CollectionName} {tileable} {true}");
            }
            else if (this._texture.TileableUV > 0 && !TileableUVEnabled.Checked)
            {
                this._texture.TileableUV = 0;
                this.CommandsProcessed.Add($"{Commands.update} {tpkblock} {this.TPK.CollectionName} " +
                    $"{this._texture.CollectionName} {tileable} {false}");
            }
        }

        private void TPKEditor_Load(object sender, EventArgs e)
        {
            PreviewImage.Image = this._texture.GetImage();
            this.CollectionName = this._texture.CollectionName;
            this.OriginalName = this.CollectionName;
            this.BoxCollectionName.Text = this.CollectionName;
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
                    this.CommandsProcessed.Add($"{Commands.duplicate} {tpkblock} {this.TPK.CollectionName} " +
                        $"0x{this._texture.BinKey:X8} {newname}");
                }
            }
        }

        private void AddTexture_Click(object sender, EventArgs e)
        {
            AddTextureDialog.ShowDialog();
        }

        private void AddTextureDialog_FileOk(object sender, CancelEventArgs e)
        {
            string CName = Path.GetFileNameWithoutExtension(AddTextureDialog.FileName);
            if (!this.TPK.TryAddTexture(CName, AddTextureDialog.FileName, out var error))
            {
                MessageBox.Show($"Error occured: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void ReplaceTexture_Click(object sender, EventArgs e)
        {
            ReplaceTextureDialog.ShowDialog();
        }

        private void ReplaceTextureDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (this.TPK.TryReplaceTexture(this._texture.BinKey, eKeyType.BINKEY,
                ReplaceTextureDialog.FileName, out var error))
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
            ExportTextureDialog.Filter = FilterExt;
            if (ExportTextureDialog.ShowDialog() == DialogResult.OK)
            {
                string path = ExportTextureDialog.FileName;
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
                this.CommandsProcessed.Add($"{Commands.delete} {tpkblock} {this.TPK.CollectionName} " +
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
            if (string.IsNullOrWhiteSpace(BoxCollectionName.Text))
            {
                MessageBox.Show("Collection Name cannot be empty or whitespace.", "Warning");
                return;
            }
            var CName = BoxCollectionName.Text;
            if (CName != this.OriginalName)
            {
                var exist = this.TPK.FindTexture(GlobalLib.Utils.Bin.Hash(CName), eKeyType.BINKEY);
                if (exist != null)
                {
                    MessageBox.Show($"Texture with CollectionName {CName} already exists.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.CommandsProcessed.Add($"{Commands.update} {tpkblock} {this.TPK.CollectionName} " +
                    $"0x{this._texture.BinKey:X8} {CName}");
                this._texture.CollectionName = CName;
            }
            this.ChangeTileable();
            this.DialogResult = DialogResult.OK;
        }
    }
}
