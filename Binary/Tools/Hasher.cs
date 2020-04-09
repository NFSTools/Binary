/********************************************************************************
 * MIT License
 * 
 * Copyright (c) 2020 MaxHwoy & NFS Tools
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE. 
********************************************************************************/



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
