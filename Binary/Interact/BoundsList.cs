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
