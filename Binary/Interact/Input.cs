using System;
using System.Windows.Forms;



namespace Binary.Interact
{
	public partial class Input : Form
	{
        public string CollectionName { get; private set; }

        public Input()
        {
            this.InitializeComponent();
        }

        public Input(string text)
        {
            this.InitializeComponent();
            this.UserAskLabel.Text = text;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.UserInput.Text))
            {
                MessageBox.Show("This field cannot be left empty or be a whitespace.", "Warning");
                return;
            }
            this.CollectionName = this.UserInput.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
