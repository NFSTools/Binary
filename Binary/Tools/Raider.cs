using System;
using System.Windows.Forms;
using GlobalLib.Core;
using GlobalLib.Utils;



namespace Binary.Tools
{
    public partial class Raider : Form
    {
        public Raider()
        {
            this.InitializeComponent();
        }

        private void ChooseSearchMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ChooseSearchMode.Text == "Use Bin Memory Hash search")
            {
                this.BinHashInput.ReadOnly = false;
                this.BinFileInput.ReadOnly = true;
            }
            else
            {
                this.BinFileInput.ReadOnly = false;
                this.BinHashInput.ReadOnly = true;
            }
        }

        private void BinHashInput_TextChanged(object sender, EventArgs e)
        {
            if (!this.BinHashInput.ReadOnly)
            {
                uint key = 0;
                var temp = this.BinHashInput.Text;
                try
                {
                    key = Convert.ToUInt32(temp, 16);

                    // Try looking for the hash
                    string result = Map.Lookup(key, true);
                    key = Bin.Reverse(key);
                    this.BinFileInput.Text = $"0x{key:X8}";
                    this.StringGuessed.Text = result;
                }
                catch (Exception)
                {
                    this.StringGuessed.Text = "N/A";
                    this.BinFileInput.Text = null;
                }
            }
        }

        private void BinFileInput_TextChanged(object sender, EventArgs e)
        {
            if (!this.BinFileInput.ReadOnly)
            {
                uint key = 0;
                var temp = this.BinFileInput.Text;
                try
                {
                    key = ConvertX.ToUInt32(temp);
                    key = Bin.Reverse(key);

                    // Try looking for the hash
                    string result = Map.Lookup(key, true);
                    this.BinHashInput.Text = $"0x{key:X8}";
                    this.StringGuessed.Text = result;
                }
                catch (Exception)
                {
                    this.StringGuessed.Text = "N/A";
                    this.BinHashInput.Text = null;
                }
            }
        }

        private void CopyBinHash_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.BinHashInput.Text);
        }

        private void CopyBinFile_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.BinFileInput.Text);
        }

        private void CopyString_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.StringGuessed.Text);
        }
    }
}
