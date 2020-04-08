using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Binary.Endscript;



namespace Binary.Interact
{
    public partial class ErrorView : Form
    {
        public ErrorView(List<EndLine> EndLines)
        {
            this.InitializeComponent();
            foreach (var endline in EndLines)
            {
                var Item = new ListViewItem();
                Item.Text = endline.Index.ToString();
                Item.SubItems.Add(Path.GetFileName(endline.Filename));
                Item.SubItems.Add(endline.Text);
                Item.SubItems.Add(endline.Error);
                this.ErrorListView.Items.Add(Item);
            }
        }

        private void ErrorListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkGray, e.Bounds);
            e.DrawText();
        }

        private void ErrorListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
    }
}
