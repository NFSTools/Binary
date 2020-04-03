using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;



namespace Binary.Forms.Interact
{
    public partial class TPKEditor : Form
    {
        private GlobalLib.Support.Carbon.Class.TPKBlock TPKC { get; set; }
        private GlobalLib.Support.MostWanted.Class.TPKBlock TPKMW { get; set; }
        private int ImageIndex { get; set; } = -1;
        public string CollectionName { get; set; }
        public string OriginalName { get; set; }
        public List<string> CommandsProcessed { get; set; } = new List<string>();

        public TPKEditor(GlobalLib.Support.Carbon.Class.TPKBlock TPKC, int index)
        {
            this.TPKC = TPKC;
            this.ImageIndex = index;
            InitializeComponent();
            this.BackImage.Controls.Add(this.PreviewImage);
            PreviewImage.Location = new Point(0, 0);
            PreviewImage.BackColor = Color.FromArgb(0, 0, 0, 0);
        }

        public TPKEditor(GlobalLib.Support.MostWanted.Class.TPKBlock TPKMW, int index)
        {
            this.TPKMW = TPKMW;
            this.ImageIndex = index;
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
            if (GlobalLib.Core.Process.Set == (int)GlobalLib.Core.GameINT.Carbon)
            {
                if (TPKC.Textures[this.ImageIndex].TileableUV == 0 && TileableUVEnabled.Checked)
                {
                    TPKC.Textures[this.ImageIndex].TileableUV = 3;
                    CommandsProcessed.Add($"{Endscript.Commands.Switch} TPKBlock {TPKC.CollectionName} " +
                        $"{this.CollectionName} TileableUV True");
                }
                else if (TPKC.Textures[this.ImageIndex].TileableUV > 0 && !TileableUVEnabled.Checked)
                {
                    TPKC.Textures[this.ImageIndex].TileableUV = 0;
                    CommandsProcessed.Add($"{Endscript.Commands.Switch} TPKBlock {TPKC.CollectionName} " +
                        $"{this.CollectionName} TileableUV False");
                }
            }
            else if (GlobalLib.Core.Process.Set == (int)GlobalLib.Core.GameINT.MostWanted)
            {
                if (TPKMW.Textures[this.ImageIndex].TileableUV == 0 && TileableUVEnabled.Checked)
                {
                    TPKMW.Textures[this.ImageIndex].TileableUV = 3;
                    CommandsProcessed.Add($"{Endscript.Commands.Switch} TPKBlock {TPKMW.CollectionName} " +
                        $"{this.CollectionName} Tileable True");
                }
                else if (TPKMW.Textures[this.ImageIndex].TileableUV > 0 && !TileableUVEnabled.Checked)
                {
                    TPKMW.Textures[this.ImageIndex].TileableUV = 0;
                    CommandsProcessed.Add($"{Endscript.Commands.Switch} TPKBlock {TPKMW.CollectionName} " +
                        $"{this.CollectionName} Tileable False");
                }
            }
        }

        private void TPKEditor_Load(object sender, EventArgs e)
        {
            if (GlobalLib.Core.Process.Set == (int)GlobalLib.Core.GameINT.Carbon)
            {
                PreviewImage.Image = TPKC.Textures[ImageIndex].GetImage();
                this.CollectionName = TPKC.Textures[ImageIndex].CollectionName;
                this.OriginalName = this.CollectionName;
                BoxCollectionName.Text = this.CollectionName;
                BoxCompression.Text = TPKC.Textures[ImageIndex].Compression;
                BoxWidth.Text = TPKC.Textures[ImageIndex].Width.ToString();
                BoxHeight.Text = TPKC.Textures[ImageIndex].Height.ToString();
                BoxMipmaps.Text = TPKC.Textures[ImageIndex].Mipmaps.ToString();
                TileableUVEnabled.Checked = (TPKC.Textures[ImageIndex].TileableUV > 0) ? true : false;
                PreviewImage.Width = TPKC.Textures[ImageIndex].Width;
                PreviewImage.Height = TPKC.Textures[ImageIndex].Height;
                //if (PreviewImage.Width > 512 || PreviewImage.Height > 512)
                    //PreviewImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (GlobalLib.Core.Process.Set == (int)GlobalLib.Core.GameINT.MostWanted)
            {
                PreviewImage.Image = TPKMW.Textures[ImageIndex].GetImage();
                this.CollectionName = TPKMW.Textures[ImageIndex].CollectionName;
                this.OriginalName = this.CollectionName;
                BoxCollectionName.Text = this.CollectionName;
                BoxCompression.Text = TPKMW.Textures[ImageIndex].Compression;
                BoxWidth.Text = TPKMW.Textures[ImageIndex].Width.ToString();
                BoxHeight.Text = TPKMW.Textures[ImageIndex].Height.ToString();
                BoxMipmaps.Text = TPKMW.Textures[ImageIndex].Mipmaps.ToString();
                PreviewImage.Width = TPKMW.Textures[ImageIndex].Width;
                PreviewImage.Height = TPKMW.Textures[ImageIndex].Height;
                //if (PreviewImage.Width > 512 || PreviewImage.Height > 512)
                    //PreviewImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void TPKEditor_FormClosing(object sender, FormClosingEventArgs e) { }

        private void TPKEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            var disposer = PreviewImage.Image;
            if (disposer != null) disposer.Dispose();
        }

        private void DuplicateTexture_Click(object sender, EventArgs e)
        {
            var InputWindow = new Input();
            if (InputWindow.ShowDialog() == DialogResult.OK)
            {
                string newname = InputWindow.CollectionName;
                if (GlobalLib.Core.Process.Set == (int)GlobalLib.Core.GameINT.Carbon)
                {
                    if (!TPKC.TryCloneTexture(newname, this.CollectionName)) // use recursion if fails
                    {
                        MessageBox.Show("Texture with the same collection name already exists\n" +
                                        "or name of the new texture exceed 34 characters.", "Warning");
                        this.DuplicateTexture_Click(sender, e);
                    }
                    else
                        CommandsProcessed.Add($"{Endscript.Commands.Duplicate} TPKBlock {TPKC.CollectionName} " +
                            $"{this.CollectionName} {newname}");
                }
                else if (GlobalLib.Core.Process.Set == (int)GlobalLib.Core.GameINT.MostWanted)
                {
                    if (!TPKMW.TryCloneTexture(newname, this.CollectionName)) // use recursion if fails
                    {
                        MessageBox.Show("Texture with the same collection name already exists\n" +
                                        "or name of the new texture exceed 34 characters.", "Warning");
                        this.DuplicateTexture_Click(sender, e);
                    }
                    else
                        CommandsProcessed.Add($"{Endscript.Commands.Duplicate} TPKBlock {TPKC.CollectionName} " +
                            $"{this.CollectionName} {newname}");
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
            if (GlobalLib.Core.Process.Set == (int)GlobalLib.Core.GameINT.Carbon)
            {
                if (!this.TPKC.TryAddTexture(CName, AddTextureDialog.FileName))
                {
                    MessageBox.Show("Unable to add texture: either another texture with the\n" +
                                    "same collection name already exists, or the file chosen\n" +
                                    "is not a valid .dds format (supported types: RGBA, DXT1,\n" +
                                    "DXT3, DXT5), or name of the texture exceeds 34 characters.", "Warning");
                    e.Cancel = true;
                }
            }
            else if (GlobalLib.Core.Process.Set == (int)GlobalLib.Core.GameINT.MostWanted)
            {
                if (!this.TPKMW.TryAddTexture(CName, AddTextureDialog.FileName))
                {
                    MessageBox.Show("Unable to add texture: either another texture with the\n" +
                                    "same collection name already exists, or the file chosen\n" +
                                    "is not a valid .dds format (supported types: RGBA, DXT1,\n" +
                                    "DXT3, DXT5), or name of the texture exceeds 23 characters.", "Warning");
                    e.Cancel = true;
                }
            }
        }

        private void ReplaceTexture_Click(object sender, EventArgs e)
        {
            ReplaceTextureDialog.ShowDialog();
        }

        private void ReplaceTextureDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (GlobalLib.Core.Process.Set == (int)GlobalLib.Core.GameINT.Carbon)
            {
                if (this.TPKC.TryReplaceTexture(this.CollectionName, ReplaceTextureDialog.FileName))
                {
                    this.DisposeImage();
                    this.ImageIndex = TPKC.GetTextureIndex(this.CollectionName);
                    PreviewImage.Image = TPKC.Textures[ImageIndex].GetImage();
                    BoxCompression.Text = TPKC.Textures[ImageIndex].Compression;
                    BoxWidth.Text = TPKC.Textures[ImageIndex].Width.ToString();
                    BoxHeight.Text = TPKC.Textures[ImageIndex].Height.ToString();
                    BoxMipmaps.Text = TPKC.Textures[ImageIndex].Mipmaps.ToString();
                    PreviewImage.Width = TPKC.Textures[ImageIndex].Width;
                    PreviewImage.Height = TPKC.Textures[ImageIndex].Height;
                }
                else
                {
                    MessageBox.Show("Unable to replace texture: texture has invalid .dds format.", "Warning");
                    e.Cancel = true;
                }
            }
            else if (GlobalLib.Core.Process.Set == (int)GlobalLib.Core.GameINT.MostWanted)
            {
                if (this.TPKMW.TryReplaceTexture(this.CollectionName, ReplaceTextureDialog.FileName))
                {
                    this.DisposeImage();
                    this.ImageIndex = TPKMW.GetTextureIndex(this.CollectionName);
                    PreviewImage.Image = TPKMW.Textures[ImageIndex].GetImage();
                    BoxCompression.Text = TPKMW.Textures[ImageIndex].Compression;
                    BoxWidth.Text = TPKMW.Textures[ImageIndex].Width.ToString();
                    BoxHeight.Text = TPKMW.Textures[ImageIndex].Height.ToString();
                    BoxMipmaps.Text = TPKMW.Textures[ImageIndex].Mipmaps.ToString();
                    PreviewImage.Width = TPKC.Textures[ImageIndex].Width;
                    PreviewImage.Height = TPKC.Textures[ImageIndex].Height;
                }
                else
                {
                    MessageBox.Show("Unable to replace texture: texture has invalid .dds format.", "Warning");
                    e.Cancel = true;
                }
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
                if (GlobalLib.Core.Process.Set == (int)GlobalLib.Core.GameINT.Carbon)
                {
                    if (TPKC.TryExportTexture(this.CollectionName, path, ext))
                        MessageBox.Show("Texture has been successfully exported.", "Success");
                    else
                        MessageBox.Show("Unable to export the texture.", "Failure");
                }
                else if (GlobalLib.Core.Process.Set == (int)GlobalLib.Core.GameINT.MostWanted)
                {
                    if (TPKMW.TryExportTexture(this.CollectionName, path, ext))
                        MessageBox.Show("Texture has been successfully exported.", "Success");
                    else
                        MessageBox.Show("Unable to export the texture.", "Failure");
                }
            }
        }

        private void DeleteTexture_Click(object sender, EventArgs e)
        {
            if (GlobalLib.Core.Process.Set == (int)GlobalLib.Core.GameINT.Carbon)
            {
                if (TPKC.TryRemoveTexture(this.CollectionName))
                {
                    CommandsProcessed.Add($"{Endscript.Commands.Delete} TPKBlock {TPKC.CollectionName} " +
                        $"{this.CollectionName}");
                    this.Close();
                }
                else
                    MessageBox.Show("Unable to delete the texture.", "Failure");
            }
            if (GlobalLib.Core.Process.Set == (int)GlobalLib.Core.GameINT.MostWanted)
            {
                if (TPKMW.TryRemoveTexture(this.CollectionName))
                {
                    CommandsProcessed.Add($"{Endscript.Commands.Delete} TPKBlock {TPKMW.CollectionName} " +
                        $"{this.CollectionName}");
                    this.Close();
                }
                else
                    MessageBox.Show("Unable to delete the texture.", "Failure");
            }
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
            this.CollectionName = BoxCollectionName.Text;
            if (this.CollectionName != this.OriginalName)
            {
                if (GlobalLib.Core.Process.Set == (int)GlobalLib.Core.GameINT.Carbon)
                {
                    if (TPKC.GetTextureIndex(this.CollectionName) != -1)
                    {
                        MessageBox.Show("Texture with the same collection name already exists.", "Warning");
                        return;
                    }
                    if (this.CollectionName.Length > 0x22)
                    {
                        MessageBox.Show("Collection Name of the texture cannot exceed 34 characters.", "Warning");
                        return;
                    }
                    TPKC.Textures[this.ImageIndex].CollectionName = this.CollectionName;
                    CommandsProcessed.Add($"{Endscript.Commands.Switch} TPKBlock {TPKC.CollectionName} " +
                        $"{this.OriginalName} CollectionName {this.CollectionName}");
                }
                else if (GlobalLib.Core.Process.Set == (int)GlobalLib.Core.GameINT.MostWanted)
                {
                    if (TPKMW.GetTextureIndex(this.CollectionName) != -1)
                    {
                        MessageBox.Show("Texture with the same collection name already exists.", "Warning");
                        return;
                    }
                    if (this.CollectionName.Length > 0x17)
                    {
                        MessageBox.Show("Collection Name of the texture cannot exceed 23 characters.", "Warning");
                        return;
                    }
                    TPKMW.Textures[this.ImageIndex].CollectionName = this.CollectionName;
                    CommandsProcessed.Add($"{Endscript.Commands.Switch} TPKBlock {TPKMW.CollectionName} " +
                        $"{this.OriginalName} CollectionName {this.CollectionName}");
                }
            }
            this.ChangeTileable();
            this.DialogResult = DialogResult.OK;
        }

        private void TileableUVEnabled_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
