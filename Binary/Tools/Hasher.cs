using System;
using System.Windows.Forms;
using GlobalLib.Utils;


namespace Binary.Tools
{
    public partial class Hasher : Form
    {
        public Hasher()
        {
            InitializeComponent();
        }

        private void StringTextbox_TextChanged(object sender, EventArgs e)
        {
            var str = StringTextbox.Text;

            uint result = 0;
            string _0x = "0x";

            // Bin memory hash
            result = Bin.Hash(str);
            BinHashTextbox.Text = $"{_0x}{result:X8}";

            // Bin file hash
            result = Bin.Reverse(result);
            BinFileTextbox.Text = $"{_0x}{result:X8}";

            // Vlt memory hash
            result = Vlt.Hash(str);
            VltHashTextbox.Text = $"{_0x}{result:X8}";

            // Vlt file hash
            result = Vlt.Reverse(result);
            VltFileTextbox.Text = $"{_0x}{result:X8}";
        }

        private void CopyString_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(StringTextbox.Text);
        }

        private void CopyBinHash_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(BinHashTextbox.Text);
        }

        private void CopyBinFile_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(BinFileTextbox.Text);
        }

        private void CopyVltHash_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(VltHashTextbox.Text);
        }

        private void CopyVltFile_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(VltFileTextbox.Text);
        }
    }
}
