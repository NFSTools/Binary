using System;
using System.Drawing;
using System.Windows.Forms;



namespace Binary.Tools
{
    public partial class ColorPicker : Form
    {
        public ColorPicker()
        {
            InitializeComponent();
            ColorBackground.Controls.Add(ColorPreview);
            ColorPreview.Location = new Point(0, 0);
            ComboTypeSelection.Text = ComboTypeSelection.Items[0].ToString();
        }

        private void TrackBar_Red_Scroll(object sender, EventArgs e)
        {
            if (ComboTypeSelection.SelectedIndex == 0)
            {
                float red = Convert.ToSingle(TrackBar_Red.Value) / 255;
                TextBoxRed.Text = red.ToString();
            }
            else
            {
                TextBoxRed.Text = TrackBar_Red.Value.ToString();
            }
            ColorPreview.BackColor = Color.FromArgb(ColorPreview.BackColor.A, TrackBar_Red.Value, ColorPreview.BackColor.G, ColorPreview.BackColor.B);
        }

        private void TrackBar_Green_Scroll(object sender, EventArgs e)
        {
            if (ComboTypeSelection.SelectedIndex == 0)
            {
                float green = Convert.ToSingle(TrackBar_Green.Value) / 255;
                TextBoxGreen.Text = green.ToString();
            }
            else
            {
                TextBoxGreen.Text = TrackBar_Green.Value.ToString();
            }
            ColorPreview.BackColor = Color.FromArgb(ColorPreview.BackColor.A, ColorPreview.BackColor.R, TrackBar_Green.Value, ColorPreview.BackColor.B);
        }

        private void TrackBar_Blue_Scroll(object sender, EventArgs e)
        {
            if (ComboTypeSelection.SelectedIndex == 0)
            {
                float blue = Convert.ToSingle(TrackBar_Blue.Value) / 255;
                TextBoxBlue.Text = blue.ToString();
            }
            else
            {
                TextBoxBlue.Text = TrackBar_Blue.Value.ToString();
            }
            ColorPreview.BackColor = Color.FromArgb(ColorPreview.BackColor.A, ColorPreview.BackColor.R, ColorPreview.BackColor.G, TrackBar_Blue.Value);
        }

        private void TrackBar_Level_Scroll(object sender, EventArgs e)
        {
            if (ComboTypeSelection.SelectedIndex == 0)
            {
                float level = Convert.ToSingle(TrackBar_Level.Value) / 255;
                TextBoxLevel.Text = level.ToString();
            }
            else
            {
                TextBoxLevel.Text = TrackBar_Level.Value.ToString();
            }
            ColorPreview.BackColor = Color.FromArgb(TrackBar_Level.Value, ColorPreview.BackColor.R, ColorPreview.BackColor.G, ColorPreview.BackColor.B);
        }

        private void OpenWindowsColorForm_Click(object sender, EventArgs e)
        {
            if (SwatchDialog.ShowDialog() == DialogResult.OK)
            {

                TrackBar_Red.Value = SwatchDialog.Color.R;
                TrackBar_Green.Value = SwatchDialog.Color.G;
                TrackBar_Blue.Value = SwatchDialog.Color.B;

                if (ComboTypeSelection.SelectedIndex == 0)
                {
                    float red = Convert.ToSingle(TrackBar_Red.Value) / 255;
                    float green = Convert.ToSingle(TrackBar_Green.Value) / 255;
                    float blue = Convert.ToSingle(TrackBar_Blue.Value) / 255;

                    TextBoxRed.Text = red.ToString();
                    TextBoxGreen.Text = green.ToString();
                    TextBoxBlue.Text = blue.ToString();

                }
                else
                {
                    TextBoxRed.Text = TrackBar_Red.Value.ToString();
                    TextBoxGreen.Text = TrackBar_Green.Value.ToString();
                    TextBoxBlue.Text = TrackBar_Blue.Value.ToString();
                }
                
                ColorPreview.BackColor = Color.FromArgb((int)TrackBar_Level.Value, SwatchDialog.Color.R, SwatchDialog.Color.G, SwatchDialog.Color.B);
            }
        }

        private void CopyRedValue_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TextBoxRed.Text);
        }

        private void CopyGreenValue_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TextBoxGreen.Text);
        }

        private void CopyBlueValue_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TextBoxBlue.Text);
        }

        private void CopyLevelValue_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TextBoxLevel.Text);
        }

        private void ComboTypeSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboTypeSelection.SelectedIndex == 0)
            {
                MainGroupBox.Text = "Material/Paint Color Picker";
                LabelLevel.Text = "Level";
                TextBoxLevel.Text = (Convert.ToSingle(TrackBar_Level.Value) / 255).ToString();
                TextBoxRed.Text = (Convert.ToSingle(TrackBar_Red.Value) / 255).ToString();
                TextBoxGreen.Text = (Convert.ToSingle(TrackBar_Green.Value) / 255).ToString();
                TextBoxBlue.Text = (Convert.ToSingle(TrackBar_Blue.Value) / 255).ToString();
            }
            else
            {
                MainGroupBox.Text = "FEng/Vinyl Color Picker";
                LabelLevel.Text = "Alpha";
                TextBoxLevel.Text = TrackBar_Level.Value.ToString();
                TextBoxRed.Text = TrackBar_Red.Value.ToString();
                TextBoxGreen.Text = TrackBar_Green.Value.ToString();
                TextBoxBlue.Text = TrackBar_Blue.Value.ToString();
            }
        }
    }
}
