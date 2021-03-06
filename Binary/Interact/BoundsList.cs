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
using GlobalLib.Core;



namespace Binary.Interact
{
	public partial class BoundsList : Form
	{
		public BoundsList()
		{
			this.InitializeComponent();
		}

		private void BoundsList_Load(object sender, EventArgs e)
		{
			int index = 0;
			foreach (var bound in Map.CollisionMap)
			{
				var Item = new ListViewItem();
				Item.Text = (index++).ToString();
				Item.SubItems.Add($"0x{bound.Key:X8}");
				Item.SubItems.Add(bound.Value);
				this.BoundListView.Items.Add(Item);
			}
		}

		private void BoundListView_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			var HitTest = this.BoundListView.HitTest(e.X, e.Y);
			var Item = HitTest.Item;
			Clipboard.SetText(Item.SubItems[2].Text);
		}

		private void ButtonOK_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void BoundListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.Graphics.FillRectangle(Brushes.DarkGray, e.Bounds);
			e.DrawText();
		}

		private void BoundListView_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			e.DrawDefault = true;
		}
	}
}
