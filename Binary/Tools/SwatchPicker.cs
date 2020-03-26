using System;
using System.Drawing;
using System.Windows.Forms;



namespace Binary.Tools
{
    public partial class SwatchPicker : Form
    {
        public SwatchPicker()
        {
            InitializeComponent();
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

            TextBoxPaintSwatch.Text = ((int)hue).ToString();
            TextBoxSaturation.Text = sat.ToString();
            TextBoxBrightness.Text = brt.ToString();
            ColorPreview.BackColor = Color.FromArgb((int)TrackBar_Red.Value, (int)TrackBar_Green.Value, (int)TrackBar_Blue.Value);
        }

        private void TrackBar_Red_Scroll(object sender, EventArgs e)
        {
            float red = Convert.ToSingle(TrackBar_Red.Value) / 255;
            float green = Convert.ToSingle(TrackBar_Green.Value) / 255;
            float blue = Convert.ToSingle(TrackBar_Blue.Value) / 255;
            RGBtoHSV(red, green, blue);
        }

        private void TrackBar_Green_Scroll(object sender, EventArgs e)
        {
            float red = Convert.ToSingle(TrackBar_Red.Value) / 255;
            float green = Convert.ToSingle(TrackBar_Green.Value) / 255;
            float blue = Convert.ToSingle(TrackBar_Blue.Value) / 255;
            RGBtoHSV(red, green, blue);
        }

        private void TrackBar_Blue_Scroll(object sender, EventArgs e)
        {
            float red = Convert.ToSingle(TrackBar_Red.Value) / 255;
            float green = Convert.ToSingle(TrackBar_Green.Value) / 255;
            float blue = Convert.ToSingle(TrackBar_Blue.Value) / 255;
            RGBtoHSV(red, green, blue);
        }

        private void OpenWindowsColorForm_Click(object sender, EventArgs e)
        {
            if (SwatchDialog.ShowDialog() == DialogResult.OK)
            {

                TrackBar_Red.Value = SwatchDialog.Color.R;
                TrackBar_Green.Value = SwatchDialog.Color.G;
                TrackBar_Blue.Value = SwatchDialog.Color.B;

                float red = Convert.ToSingle(TrackBar_Red.Value) / 255;
                float green = Convert.ToSingle(TrackBar_Green.Value) / 255;
                float blue = Convert.ToSingle(TrackBar_Blue.Value) / 255;

                RGBtoHSV(red, green, blue);
            }
        }

        private void CopyPaintSwatchValue_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TextBoxPaintSwatch.Text);
        }

        private void CopySaturationValue_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TextBoxSaturation.Text);
        }

        private void CopyBrightnessValue_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TextBoxBrightness.Text);
        }
    }
}
