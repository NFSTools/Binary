using System;
using System.Windows.Forms;
using GlobalLib.Utils;


namespace Binary.Tools
{
    public partial class Hasher : Form
    {
        public Hasher()
        {
            this.InitializeComponent();
        }

        private void StringTextbox_TextChanged(object sender, EventArgs e)
        {
            var str = this.StringTextbox.Text;

            uint result = 0;
            string _0x = "0x";

            // Bin memory hash
            result = Bin.Hash(str);
            this.BinHashTextbox.Text = $"{_0x}{result:X8}";

            // Bin file hash
            result = Bin.Reverse(result);
            this.BinFileTextbox.Text = $"{_0x}{result:X8}";

            // Vlt memory hash
            result = Vlt.Hash(str);
            this.VltHashTextbox.Text = $"{_0x}{result:X8}";

            // Vlt file hash
            result = Vlt.Reverse(result);
            this.VltFileTextbox.Text = $"{_0x}{result:X8}";
        }

        private void CopyString_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.StringTextbox.Text);
        }

        private void CopyBinHash_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.BinHashTextbox.Text);
        }

        private void CopyBinFile_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.BinFileTextbox.Text);
        }

        private void CopyVltHash_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.VltHashTextbox.Text);
        }

        private void CopyVltFile_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.VltFileTextbox.Text);
        }
    }
}
