﻿/********************************************************************************
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
using System.Drawing;
using System.Windows.Forms;
using Binary.Endscript;
using GlobalLib.Utils.EA;
using GlobalLib.Support.Shared.Parts.FNGParts;



namespace Binary.Interact
{
    public partial class FEngEditor : Form
    {
        private int _index;
        private FEngColor _color;
        public string CommandProcessed { get; set; }
        public const string FNGroups = "FNGroups";
        public const string ReplaceAllNoAlpha = "ReplaceAllNoAlpha";
        public const string ReplaceAllWithAlpha = "ReplaceAllWithAlpha";
        public const string ReplaceSameNoAlpha = "ReplaceSameNoAlpha";
        public const string ReplaceSameWithAlpha = "ReplaceSameWithAlpha";
        
        public FEngEditor()
        {
            this.InitializeComponent();
        }

        public FEngEditor(FEngColor color, int index)
        {
            this._color = color;
            this._index = index;
            this.InitializeComponent();
        }

        private void TrackBar_Red_Scroll(object sender, EventArgs e)
        {
            this.NewRed.Value = this.TrackBar_Red.Value;
            this.NewColorBox.BackColor = Color.FromArgb(this.NewColorBox.BackColor.A,
                (int)NewRed.Value, this.NewColorBox.BackColor.G, this.NewColorBox.BackColor.B);
        }

        private void TrackBar_Green_Scroll(object sender, EventArgs e)
        {
            this.NewGreen.Value = this.TrackBar_Green.Value;
            this.NewColorBox.BackColor = Color.FromArgb(this.NewColorBox.BackColor.A,
                this.NewColorBox.BackColor.R, (int)NewGreen.Value, this.NewColorBox.BackColor.B);
        }

        private void TrackBar_Blue_Scroll(object sender, EventArgs e)
        {
            this.NewBlue.Value = this.TrackBar_Blue.Value;
            this.NewColorBox.BackColor = Color.FromArgb(this.NewColorBox.BackColor.A,
                this.NewColorBox.BackColor.R, this.NewColorBox.BackColor.G, (int)NewBlue.Value);
        }

        private void TrackBar_Alpha_Scroll(object sender, EventArgs e)
        {
            this.NewAlpha.Value = this.TrackBar_Alpha.Value;
            this.NewColorBox.BackColor = Color.FromArgb((int)NewAlpha.Value,
                this.NewColorBox.BackColor.R, this.NewColorBox.BackColor.G, this.NewColorBox.BackColor.B);
        }

        private void NewRed_ValueChanged(object sender, EventArgs e)
        {
            this.TrackBar_Red.Value = (int)NewRed.Value;
            this.NewColorBox.BackColor = Color.FromArgb(this.NewColorBox.BackColor.A,
                (int)NewRed.Value, this.NewColorBox.BackColor.G, this.NewColorBox.BackColor.B);
        }

        private void NewGreen_ValueChanged(object sender, EventArgs e)
        {
            this.TrackBar_Green.Value = (int)NewGreen.Value;
            this.NewColorBox.BackColor = Color.FromArgb(NewColorBox.BackColor.A,
                this.NewColorBox.BackColor.R, (int)NewGreen.Value, this.NewColorBox.BackColor.B);
        }

        private void NewBlue_ValueChanged(object sender, EventArgs e)
        {
            this.TrackBar_Blue.Value = (int)NewBlue.Value;
            this.NewColorBox.BackColor = Color.FromArgb(this.NewColorBox.BackColor.A,
                this.NewColorBox.BackColor.R, this.NewColorBox.BackColor.G, (int)NewBlue.Value);
        }

        private void NewAlpha_ValueChanged(object sender, EventArgs e)
        {
            this.TrackBar_Alpha.Value = (int)NewAlpha.Value;
            this.NewColorBox.BackColor = Color.FromArgb((int)NewAlpha.Value,
                this.NewColorBox.BackColor.R, this.NewColorBox.BackColor.G, this.NewColorBox.BackColor.B);
        }

        private void OpenWindowsColorForm_Click(object sender, EventArgs e)
        {
            if (this.SwatchDialog.ShowDialog() == DialogResult.OK)
            {
                this.TrackBar_Blue.Value = this.SwatchDialog.Color.B;
                this.TrackBar_Green.Value = this.SwatchDialog.Color.G;
                this.TrackBar_Red.Value = this.SwatchDialog.Color.R;
                this.NewBlue.Value = this.SwatchDialog.Color.B;
                this.NewGreen.Value = this.SwatchDialog.Color.G;
                this.NewRed.Value = this.SwatchDialog.Color.R;
                this.NewColorBox.BackColor = Color.FromArgb((int)this.NewAlpha.Value,
                    (int)this.NewRed.Value, (int)this.NewGreen.Value, (int)this.NewBlue.Value);
            }
        }

        private void FEngEditor_Load(object sender, EventArgs e)
        {
            this.CurrentBackground.Controls.Add(this.CurrentColorBox);
            this.NewBackground.Controls.Add(this.NewColorBox);
            this.CurrentColorBox.Location = new Point(0, 0);
            this.NewColorBox.Location = new Point(0, 0);
            this.CurrentIndex.Text = this._index.ToString();
            this.CurrentOffset.Text = $"0x{this._color.Offset:X8}";
            this.CurrentAlpha.Text = this._color.Alpha.ToString();
            this.CurrentRed.Text = this._color.Red.ToString();
            this.CurrentGreen.Text = this._color.Green.ToString();
            this.CurrentBlue.Text = this._color.Blue.ToString();

            this.CurrentColorBox.BackColor = Color.FromArgb(this._color.Alpha, this._color.Red,
                this._color.Green, this._color.Blue);
            this.NewColorBox.BackColor = this.CurrentColorBox.BackColor;

            this.TrackBar_Alpha.Value = this.CurrentColorBox.BackColor.A;
            this.TrackBar_Red.Value = this.CurrentColorBox.BackColor.R;
            this.TrackBar_Green.Value = this.CurrentColorBox.BackColor.G;
            this.TrackBar_Blue.Value = this.CurrentColorBox.BackColor.B;

            this.NewAlpha.Value = this.CurrentColorBox.BackColor.A;
            this.NewRed.Value = this.CurrentColorBox.BackColor.R;
            this.NewGreen.Value = this.CurrentColorBox.BackColor.G;
            this.NewBlue.Value = this.CurrentColorBox.BackColor.B;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            string path = $"{eCommands.update} {FNGroups} {this._color.ThisFNGroup.CollectionName}";
            string hex = SAT.ColorToHex(this.NewColorBox.BackColor.A, this.NewColorBox.BackColor.R,
                this.NewColorBox.BackColor.G, this.NewColorBox.BackColor.B);
            bool keepalpha = this.CheckKeepAlpha.Checked;
            if (this.CheckReplaceSame.Checked)
            {
                var newcolor = new FEngColor(null)
                {
                    Alpha = this.NewColorBox.BackColor.A,
                    Red = this.NewColorBox.BackColor.R,
                    Green = this.NewColorBox.BackColor.G,
                    Blue = this.NewColorBox.BackColor.B
                };
                this._color.ThisFNGroup.TrySetSame(this._index, newcolor, keepalpha);
                if (keepalpha)
                    this.CommandProcessed = $"{path} {ReplaceSameNoAlpha}[{this._index}] {hex}";
                else
                    this.CommandProcessed = $"{path} {ReplaceSameWithAlpha}[{this._index}] {hex}";
            }
            else
            {
                this._color.Alpha = this.NewColorBox.BackColor.A;
                this._color.Red = this.NewColorBox.BackColor.R;
                this._color.Green = this.NewColorBox.BackColor.G;
                this._color.Blue = this.NewColorBox.BackColor.B;
                if (this.CheckReplaceAll.Checked)
                {
                    this._color.ThisFNGroup.TrySetAll(this._color, keepalpha);
                    if (keepalpha)
                        this.CommandProcessed = $"{path} {ReplaceAllNoAlpha} {hex}";
                    else
                        this.CommandProcessed = $"{path} {ReplaceAllWithAlpha} {hex}";
                }
                else
                    this.CommandProcessed = $"{path} Color[{this._index}] {hex}";
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CheckReplaceAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CheckReplaceAll.Checked) this.CheckKeepAlpha.Enabled = true;
            else if (!this.CheckReplaceSame.Checked)
            {
                this.CheckKeepAlpha.Enabled = false;
                this.CheckKeepAlpha.Checked = false;
            }
        }

        private void CheckReplaceSame_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CheckReplaceSame.Checked) this.CheckKeepAlpha.Enabled = true;
            else if (!this.CheckReplaceAll.Checked)
            {
                this.CheckKeepAlpha.Enabled = false;
                this.CheckKeepAlpha.Checked = false;
            }
        }
    }
}