using System;
using System.Windows.Forms;
using GlobalLib.Utils;



namespace Binary.Tools
{
    public partial class Raider : Form
    {
        public Raider()
        {
            InitializeComponent();
        }

        private void ChooseSearchMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChooseSearchMode.Text == "Use Bin Memory Hash search")
            {
                BinHashInput.ReadOnly = false;
                BinFileInput.ReadOnly = true;
            }
            else
            {
                BinFileInput.ReadOnly = false;
                BinHashInput.ReadOnly = true;
            }
        }

        private void BinHashInput_TextChanged(object sender, EventArgs e)
        {
            if (!BinHashInput.ReadOnly)
            {
                uint key = 0;
                var temp = BinHashInput.Text;
                try
                {
                    key = Convert.ToUInt32(temp, 16);

                    // Try looking for the hash
                    string result = GlobalLib.Core.Map.Lookup(key, true);
                    key = Bin.Reverse(key);
                    BinFileInput.Text = $"0x{key:X8}";
                    StringGuessed.Text = result;
                }
                catch (Exception)
                {
                    StringGuessed.Text = "N/A";
                    BinFileInput.Text = null;
                }
            }
        }

        private void BinFileInput_TextChanged(object sender, EventArgs e)
        {
            if (!BinFileInput.ReadOnly)
            {
                uint key = 0;
                var temp = BinFileInput.Text;
                try
                {
                    key = ConvertX.ToUInt32(temp);
                    key = Bin.Reverse(key);

                    // Try looking for the hash
                    string result = GlobalLib.Core.Map.Lookup(key, true);
                    BinHashInput.Text = $"0x{key:X8}";
                    StringGuessed.Text = result;
                }
                catch (Exception)
                {
                    StringGuessed.Text = "N/A";
                    BinHashInput.Text = null;
                }
            }
        }

        private void CopyBinHash_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(BinHashInput.Text);
        }

        private void CopyBinFile_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(BinFileInput.Text);
        }

        private void CopyString_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(StringGuessed.Text);
        }
    }
}
