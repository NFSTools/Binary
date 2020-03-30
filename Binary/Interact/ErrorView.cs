using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;



namespace Binary.Interact
{
    public partial class ErrorView : Form
    {
        public ErrorView(List<Endscript.EndLine> EndLines)
        {
            InitializeComponent();
            foreach (var endline in EndLines)
            {
                var Item = new ListViewItem();
                Item.Text = endline.Index.ToString();
                Item.SubItems.Add(Path.GetFileName(endline.Filename));
                Item.SubItems.Add(endline.Text);
                Item.SubItems.Add(endline.Error);
                ErrorListView.Items.Add(Item);
            }
        }

        private void ErrorListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(System.Drawing.Brushes.DarkGray, e.Bounds);
            e.DrawText();
        }

        private void ErrorListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
    }
}
