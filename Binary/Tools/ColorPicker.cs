using System;
using System.Drawing;
using System.Windows.Forms;



namespace Binary.Tools
{
    public partial class ColorPicker : Form
    {
        public ColorPicker()
        {
            this.InitializeComponent();
            this.ColorBackground.Controls.Add(this.ColorPreview);
            this.ColorPreview.Location = new Point(0, 0);
            this.ComboTypeSelection.Text = this.ComboTypeSelection.Items[0].ToString();
        }

        private void TrackBar_Red_Scroll(object sender, EventArgs e)
        {
            if (this.ComboTypeSelection.SelectedIndex == 0)
            {
                float red = Convert.ToSingle(this.TrackBar_Red.Value) / 255;
                this.TextBoxRed.Text = red.ToString();
            }
            else
            {
                this.TextBoxRed.Text = this.TrackBar_Red.Value.ToString();
            }
            this.ColorPreview.BackColor = Color.FromArgb(this.ColorPreview.BackColor.A,
                this.TrackBar_Red.Value, this.ColorPreview.BackColor.G, this.ColorPreview.BackColor.B);
        }

        private void TrackBar_Green_Scroll(object sender, EventArgs e)
        {
            if (this.ComboTypeSelection.SelectedIndex == 0)
            {
                float green = Convert.ToSingle(this.TrackBar_Green.Value) / 255;
                this.TextBoxGreen.Text = green.ToString();
            }
            else
            {
                this.TextBoxGreen.Text = this.TrackBar_Green.Value.ToString();
            }
            this.ColorPreview.BackColor = Color.FromArgb(this.ColorPreview.BackColor.A,
                this.ColorPreview.BackColor.R, this.TrackBar_Green.Value, this.ColorPreview.BackColor.B);
        }

        private void TrackBar_Blue_Scroll(object sender, EventArgs e)
        {
            if (this.ComboTypeSelection.SelectedIndex == 0)
            {
                float blue = Convert.ToSingle(this.TrackBar_Blue.Value) / 255;
                this.TextBoxBlue.Text = blue.ToString();
            }
            else
            {
                this.TextBoxBlue.Text = this.TrackBar_Blue.Value.ToString();
            }
            this.ColorPreview.BackColor = Color.FromArgb(this.ColorPreview.BackColor.A,
                this.ColorPreview.BackColor.R, this.ColorPreview.BackColor.G, this.TrackBar_Blue.Value);
        }

        private void TrackBar_Level_Scroll(object sender, EventArgs e)
        {
            if (this.ComboTypeSelection.SelectedIndex == 0)
            {
                float level = Convert.ToSingle(this.TrackBar_Level.Value) / 255;
                this.TextBoxLevel.Text = level.ToString();
            }
            else
            {
                this.TextBoxLevel.Text = this.TrackBar_Level.Value.ToString();
            }
            this.ColorPreview.BackColor = Color.FromArgb(this.TrackBar_Level.Value,
                this.ColorPreview.BackColor.R, this.ColorPreview.BackColor.G, this.ColorPreview.BackColor.B);
        }

        private void OpenWindowsColorForm_Click(object sender, EventArgs e)
        {
            if (this.SwatchDialog.ShowDialog() == DialogResult.OK)
            {

                this.TrackBar_Red.Value = this.SwatchDialog.Color.R;
                this.TrackBar_Green.Value = this.SwatchDialog.Color.G;
                this.TrackBar_Blue.Value = this.SwatchDialog.Color.B;

                if (this.ComboTypeSelection.SelectedIndex == 0)
                {
                    float red = Convert.ToSingle(this.TrackBar_Red.Value) / 255;
                    float green = Convert.ToSingle(this.TrackBar_Green.Value) / 255;
                    float blue = Convert.ToSingle(this.TrackBar_Blue.Value) / 255;

                    this.TextBoxRed.Text = red.ToString();
                    this.TextBoxGreen.Text = green.ToString();
                    this.TextBoxBlue.Text = blue.ToString();

                }
                else
                {
                    this.TextBoxRed.Text = this.TrackBar_Red.Value.ToString();
                    this.TextBoxGreen.Text = this.TrackBar_Green.Value.ToString();
                    this.TextBoxBlue.Text = this.TrackBar_Blue.Value.ToString();
                }
                
                this.ColorPreview.BackColor = Color.FromArgb(this.TrackBar_Level.Value,
                    this.SwatchDialog.Color.R, this.SwatchDialog.Color.G, this.SwatchDialog.Color.B);
            }
        }

        private void CopyRedValue_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.TextBoxRed.Text);
        }

        private void CopyGreenValue_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.TextBoxGreen.Text);
        }

        private void CopyBlueValue_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.TextBoxBlue.Text);
        }

        private void CopyLevelValue_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.TextBoxLevel.Text);
        }

        private void ComboTypeSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ComboTypeSelection.SelectedIndex == 0)
            {
                this.MainGroupBox.Text = "Material/Paint Color Picker";
                this.LabelLevel.Text = "Level";
                this.TextBoxLevel.Text = (Convert.ToSingle(this.TrackBar_Level.Value) / 255).ToString();
                this.TextBoxRed.Text = (Convert.ToSingle(this.TrackBar_Red.Value) / 255).ToString();
                this.TextBoxGreen.Text = (Convert.ToSingle(this.TrackBar_Green.Value) / 255).ToString();
                this.TextBoxBlue.Text = (Convert.ToSingle(this.TrackBar_Blue.Value) / 255).ToString();
            }
            else
            {
                this.MainGroupBox.Text = "FEng/Vinyl Color Picker";
                this.LabelLevel.Text = "Alpha";
                this.TextBoxLevel.Text = this.TrackBar_Level.Value.ToString();
                this.TextBoxRed.Text = this.TrackBar_Red.Value.ToString();
                this.TextBoxGreen.Text = this.TrackBar_Green.Value.ToString();
                this.TextBoxBlue.Text = this.TrackBar_Blue.Value.ToString();
            }
        }
    }
}
