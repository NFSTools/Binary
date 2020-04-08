using System;
using System.Drawing;
using System.Windows.Forms;



namespace Binary.Tools
{
    public partial class SwatchPicker : Form
    {
        public SwatchPicker()
        {
            this.InitializeComponent();
        }

        private void RGBtoHSV(float red, float green, float blue)
        {
            float hue = 0; // paintswatch
            float sat = 0; // saturation
            float brt = 0; // brightness

            float min = 0; // min rgb value
            float max = 0; // max rgb value
            float dif = 0; // delta of max & min

            max = (red > green) ? red : green;
            max = (max > blue) ? max : blue;
            min = (red < green) ? red : green;
            min = (min < blue) ? min : blue;

            brt = max; // set brightness
            dif = max - min;

            if (max == 0)
                sat = 0; // set brightness
            else
                sat = dif / max;

            if (max == min)
                hue = 0;
            else if (max == red)
                hue = (60 * ((green - blue) / dif) + 360) % 360;
            else if (max == green)
                hue = (60 * ((blue - red) / dif) + 120) % 360;
            else if (max == blue)
                hue = (60 * ((red - green) / dif) + 240) % 360;

            hue = 90 - (hue / 4);

            this.TextBoxPaintSwatch.Text = ((int)hue).ToString();
            this.TextBoxSaturation.Text = sat.ToString();
            this.TextBoxBrightness.Text = brt.ToString();
            this.ColorPreview.BackColor = Color.FromArgb(this.TrackBar_Red.Value, this.TrackBar_Green.Value, this.TrackBar_Blue.Value);
        }

        private void TrackBar_Red_Scroll(object sender, EventArgs e)
        {
            float red = Convert.ToSingle(this.TrackBar_Red.Value) / 255;
            float green = Convert.ToSingle(this.TrackBar_Green.Value) / 255;
            float blue = Convert.ToSingle(this.TrackBar_Blue.Value) / 255;
            this.RGBtoHSV(red, green, blue);
        }

        private void TrackBar_Green_Scroll(object sender, EventArgs e)
        {
            float red = Convert.ToSingle(this.TrackBar_Red.Value) / 255;
            float green = Convert.ToSingle(this.TrackBar_Green.Value) / 255;
            float blue = Convert.ToSingle(this.TrackBar_Blue.Value) / 255;
            this.RGBtoHSV(red, green, blue);
        }

        private void TrackBar_Blue_Scroll(object sender, EventArgs e)
        {
            float red = Convert.ToSingle(this.TrackBar_Red.Value) / 255;
            float green = Convert.ToSingle(this.TrackBar_Green.Value) / 255;
            float blue = Convert.ToSingle(this.TrackBar_Blue.Value) / 255;
            this.RGBtoHSV(red, green, blue);
        }

        private void OpenWindowsColorForm_Click(object sender, EventArgs e)
        {
            if (this.SwatchDialog.ShowDialog() == DialogResult.OK)
            {

                this.TrackBar_Red.Value = this.SwatchDialog.Color.R;
                this.TrackBar_Green.Value = this.SwatchDialog.Color.G;
                this.TrackBar_Blue.Value = this.SwatchDialog.Color.B;

                float red = Convert.ToSingle(this.TrackBar_Red.Value) / 255;
                float green = Convert.ToSingle(this.TrackBar_Green.Value) / 255;
                float blue = Convert.ToSingle(this.TrackBar_Blue.Value) / 255;

                this.RGBtoHSV(red, green, blue);
            }
        }

        private void CopyPaintSwatchValue_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.TextBoxPaintSwatch.Text);
        }

        private void CopySaturationValue_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.TextBoxSaturation.Text);
        }

        private void CopyBrightnessValue_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.TextBoxBrightness.Text);
        }
    }
}
