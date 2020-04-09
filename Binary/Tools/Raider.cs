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
