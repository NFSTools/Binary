using System;
using System.Drawing;
using System.Windows.Forms;
using GlobalLib.Support.Shared.Parts.FNGParts;



namespace Binary.Interact
{
    public partial class FEngEditor : Form
    {
        private int _index;
        private FEngColor _color;
        public bool KeepAlpha { get; set; } = false;
        public bool ReplaceSame { get; set; } = false;
        public bool ReplaceAll { get; set; } = false;
        
        public FEngEditor()
        {
            this.InitializeComponent();
        }

        public FEngEditor(FEngColor color, int index)
        {
            this._color = color;
            this._index = index;
        }

        private void TrackBar_Red_Scroll(object sender, EventArgs e)
        {
            this.NewRed.Value = this.TrackBar_Red.Value;
            this.NewColorBox.BackColor = Color.FromArgb(this.NewColorBox.BackColor.A,
                (int)NewRed.Value, this.NewColorBox.BackColor.G, this.NewColorBox.BackColor.B);
        }

        private void TrackBar_Green_Scroll(object sender, EventArgs e)
        {
            this.NewGreen.Value = this.TrackBar_Green.Value;
            this.NewColorBox.BackColor = Color.FromArgb(this.NewColorBox.BackColor.A,
                this.NewColorBox.BackColor.R, (int)NewGreen.Value, this.NewColorBox.BackColor.B);
        }

        private void TrackBar_Blue_Scroll(object sender, EventArgs e)
        {
            this.NewBlue.Value = this.TrackBar_Blue.Value;
            this.NewColorBox.BackColor = Color.FromArgb(this.NewColorBox.BackColor.A,
                this.NewColorBox.BackColor.R, this.NewColorBox.BackColor.G, (int)NewBlue.Value);
        }

        private void TrackBar_Alpha_Scroll(object sender, EventArgs e)
        {
            this.NewAlpha.Value = this.TrackBar_Alpha.Value;
            this.NewColorBox.BackColor = Color.FromArgb((int)NewAlpha.Value,
                this.NewColorBox.BackColor.R, this.NewColorBox.BackColor.G, this.NewColorBox.BackColor.B);
        }

        private void NewRed_ValueChanged(object sender, EventArgs e)
        {
            this.TrackBar_Red.Value = (int)NewRed.Value;
            this.NewColorBox.BackColor = Color.FromArgb(this.NewColorBox.BackColor.A,
                (int)NewRed.Value, this.NewColorBox.BackColor.G, this.NewColorBox.BackColor.B);
        }

        private void NewGreen_ValueChanged(object sender, EventArgs e)
        {
            this.TrackBar_Green.Value = (int)NewGreen.Value;
            this.NewColorBox.BackColor = Color.FromArgb(NewColorBox.BackColor.A,
                this.NewColorBox.BackColor.R, (int)NewGreen.Value, this.NewColorBox.BackColor.B);
        }

        private void NewBlue_ValueChanged(object sender, EventArgs e)
        {
            this.TrackBar_Blue.Value = (int)NewBlue.Value;
            this.NewColorBox.BackColor = Color.FromArgb(this.NewColorBox.BackColor.A,
                this.NewColorBox.BackColor.R, this.NewColorBox.BackColor.G, (int)NewBlue.Value);
        }

        private void NewAlpha_ValueChanged(object sender, EventArgs e)
        {
            this.TrackBar_Alpha.Value = (int)NewAlpha.Value;
            this.NewColorBox.BackColor = Color.FromArgb((int)NewAlpha.Value,
                this.NewColorBox.BackColor.R, this.NewColorBox.BackColor.G, this.NewColorBox.BackColor.B);
        }

        private void OpenWindowsColorForm_Click(object sender, EventArgs e)
        {
            if (this.SwatchDialog.ShowDialog() == DialogResult.OK)
            {
                this.TrackBar_Blue.Value = this.SwatchDialog.Color.B;
                this.TrackBar_Green.Value = this.SwatchDialog.Color.G;
                this.TrackBar_Red.Value = this.SwatchDialog.Color.R;
                this.NewBlue.Value = this.SwatchDialog.Color.B;
                this.NewGreen.Value = this.SwatchDialog.Color.G;
                this.NewRed.Value = this.SwatchDialog.Color.R;
                this.NewColorBox.BackColor = Color.FromArgb((int)this.NewAlpha.Value,
                    (int)this.NewRed.Value, (int)this.NewGreen.Value, (int)this.NewBlue.Value);
            }
        }

        private void FEngEditor_Load(object sender, EventArgs e)
        {
            this.CurrentBackground.Controls.Add(this.CurrentColorBox);
            this.NewBackground.Controls.Add(this.NewColorBox);
            this.CurrentColorBox.Location = new Point(0, 0);
            this.NewColorBox.Location = new Point(0, 0);
            this.CurrentIndex.Text = this._index.ToString();
            this.CurrentOffset.Text = $"0x{this._color.Offset:X8}";
            this.CurrentAlpha.Text = this._color.Alpha.ToString();
            this.CurrentRed.Text = this._color.Red.ToString();
            this.CurrentGreen.Text = this._color.Green.ToString();
            this.CurrentBlue.Text = this._color.Blue.ToString();

            this.CurrentColorBox.BackColor = Color.FromArgb(this._color.Alpha, this._color.Red,
                this._color.Green, this._color.Blue);
            this.NewColorBox.BackColor = this.CurrentColorBox.BackColor;

            this.TrackBar_Alpha.Value = this.CurrentColorBox.BackColor.A;
            this.TrackBar_Red.Value = this.CurrentColorBox.BackColor.R;
            this.TrackBar_Green.Value = this.CurrentColorBox.BackColor.G;
            this.TrackBar_Blue.Value = this.CurrentColorBox.BackColor.B;

            this.NewAlpha.Value = this.CurrentColorBox.BackColor.A;
            this.NewRed.Value = this.CurrentColorBox.BackColor.R;
            this.NewGreen.Value = this.CurrentColorBox.BackColor.G;
            this.NewBlue.Value = this.CurrentColorBox.BackColor.B;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            this._color.Alpha = this.NewColorBox.BackColor.A;
            this._color.Red = this.NewColorBox.BackColor.R;
            this._color.Green = this.NewColorBox.BackColor.G;
            this._color.Blue = this.NewColorBox.BackColor.B;
            this.KeepAlpha = this.CheckKeepAlpha.Checked;
            this.ReplaceSame = this.CheckReplaceSame.Checked;
            this.ReplaceAll = this.CheckReplaceAll.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CheckReplaceAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CheckReplaceAll.Checked) this.CheckKeepAlpha.Enabled = true;
            else if (!this.CheckReplaceSame.Checked)
            {
                this.CheckKeepAlpha.Enabled = false;
                this.CheckKeepAlpha.Checked = false;
            }
        }

        private void CheckReplaceSame_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CheckReplaceSame.Checked) this.CheckKeepAlpha.Enabled = true;
            else if (!this.CheckReplaceAll.Checked)
            {
                this.CheckKeepAlpha.Enabled = false;
                this.CheckKeepAlpha.Checked = false;
            }
        }
    }
}