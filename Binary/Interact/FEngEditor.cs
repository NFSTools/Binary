using System;
using System.Drawing;
using System.Windows.Forms;



namespace Binary.Forms.Interact
{
    public partial class FEngEditor : Form
    {
        public int Index { get; set; }
        public uint Offset { get; set; }
        public byte Alpha { get; set; }
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public bool KeepAlpha { get; set; } = false;
        public bool ReplaceSame { get; set; } = false;
        public bool ReplaceAll { get; set; } = false;
        
        public FEngEditor()
        {
            InitializeComponent();
        }

        private void TrackBar_Red_Scroll(object sender, EventArgs e)
        {
            NewRed.Value = (int)TrackBar_Red.Value;
            NewColorBox.BackColor = Color.FromArgb(NewColorBox.BackColor.A, (int)NewRed.Value, NewColorBox.BackColor.G, NewColorBox.BackColor.B);
        }

        private void TrackBar_Green_Scroll(object sender, EventArgs e)
        {
            NewGreen.Value = (int)TrackBar_Green.Value;
            NewColorBox.BackColor = Color.FromArgb(NewColorBox.BackColor.A, NewColorBox.BackColor.R, (int)NewGreen.Value, NewColorBox.BackColor.B);
        }

        private void TrackBar_Blue_Scroll(object sender, EventArgs e)
        {
            NewBlue.Value = (int)TrackBar_Blue.Value;
            NewColorBox.BackColor = Color.FromArgb(NewColorBox.BackColor.A, NewColorBox.BackColor.R, NewColorBox.BackColor.G, (int)NewBlue.Value);
        }

        private void TrackBar_Alpha_Scroll(object sender, EventArgs e)
        {
            NewAlpha.Value = (int)TrackBar_Alpha.Value;
            NewColorBox.BackColor = Color.FromArgb((int)NewAlpha.Value, NewColorBox.BackColor.R, NewColorBox.BackColor.G, NewColorBox.BackColor.B);
        }

        private void NewRed_ValueChanged(object sender, EventArgs e)
        {
            TrackBar_Red.Value = (int)NewRed.Value;
            NewColorBox.BackColor = Color.FromArgb(NewColorBox.BackColor.A, (int)NewRed.Value, NewColorBox.BackColor.G, NewColorBox.BackColor.B);
        }

        private void NewGreen_ValueChanged(object sender, EventArgs e)
        {
            TrackBar_Green.Value = (int)NewGreen.Value;
            NewColorBox.BackColor = Color.FromArgb(NewColorBox.BackColor.A, NewColorBox.BackColor.R, (int)NewGreen.Value, NewColorBox.BackColor.B);
        }

        private void NewBlue_ValueChanged(object sender, EventArgs e)
        {
            TrackBar_Blue.Value = (int)NewBlue.Value;
            NewColorBox.BackColor = Color.FromArgb(NewColorBox.BackColor.A, NewColorBox.BackColor.R, NewColorBox.BackColor.G, (int)NewBlue.Value);
        }

        private void NewAlpha_ValueChanged(object sender, EventArgs e)
        {
            TrackBar_Alpha.Value = (int)NewAlpha.Value;
            NewColorBox.BackColor = Color.FromArgb((int)NewAlpha.Value, NewColorBox.BackColor.R, NewColorBox.BackColor.G, NewColorBox.BackColor.B);
        }

        private void OpenWindowsColorForm_Click(object sender, EventArgs e)
        {
            if (SwatchDialog.ShowDialog() == DialogResult.OK)
            {
                TrackBar_Blue.Value = SwatchDialog.Color.B;
                TrackBar_Green.Value = SwatchDialog.Color.G;
                TrackBar_Red.Value = SwatchDialog.Color.R;
                NewBlue.Value = SwatchDialog.Color.B;
                NewGreen.Value = SwatchDialog.Color.G;
                NewRed.Value = SwatchDialog.Color.R;
                NewColorBox.BackColor = Color.FromArgb((int)NewAlpha.Value, (int)NewRed.Value, (int)NewGreen.Value, (int)NewBlue.Value);
            }
        }

        private void FEngEditor_Load(object sender, EventArgs e)
        {
            CurrentBackground.Controls.Add(CurrentColorBox);
            NewBackground.Controls.Add(NewColorBox);
            CurrentColorBox.Location = new Point(0, 0);
            NewColorBox.Location = new Point(0, 0);
            CurrentIndex.Text = this.Index.ToString();
            CurrentOffset.Text = "0x" + this.Offset.ToString("X");
            CurrentAlpha.Text = this.Alpha.ToString();
            CurrentRed.Text = this.Red.ToString();
            CurrentGreen.Text = this.Green.ToString();
            CurrentBlue.Text = this.Blue.ToString();

            CurrentColorBox.BackColor = Color.FromArgb(Alpha, Red, Green, Blue);
            NewColorBox.BackColor = CurrentColorBox.BackColor;

            TrackBar_Alpha.Value = CurrentColorBox.BackColor.A;
            TrackBar_Red.Value = CurrentColorBox.BackColor.R;
            TrackBar_Green.Value = CurrentColorBox.BackColor.G;
            TrackBar_Blue.Value = CurrentColorBox.BackColor.B;

            NewAlpha.Value = CurrentColorBox.BackColor.A;
            NewRed.Value = CurrentColorBox.BackColor.R;
            NewGreen.Value = CurrentColorBox.BackColor.G;
            NewBlue.Value = CurrentColorBox.BackColor.B;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            this.Alpha = NewColorBox.BackColor.A;
            this.Red = NewColorBox.BackColor.R;
            this.Green = NewColorBox.BackColor.G;
            this.Blue = NewColorBox.BackColor.B;
            this.KeepAlpha = CheckKeepAlpha.Checked;
            this.ReplaceSame = CheckReplaceSame.Checked;
            this.ReplaceAll = CheckReplaceAll.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CheckReplaceAll_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckReplaceAll.Checked) CheckKeepAlpha.Enabled = true;
            else if (!CheckReplaceSame.Checked)
            {
                CheckKeepAlpha.Enabled = false;
                CheckKeepAlpha.Checked = false;
            }
        }

        private void CheckReplaceSame_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckReplaceSame.Checked) CheckKeepAlpha.Enabled = true;
            else if (!CheckReplaceAll.Checked)
            {
                CheckKeepAlpha.Enabled = false;
                CheckKeepAlpha.Checked = false;
            }
        }
    }
}