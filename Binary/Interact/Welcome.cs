using System;
using System.Windows.Forms;



namespace Binary.Interact
{
	public partial class Welcome : Form
	{
		public Welcome()
		{
			InitializeComponent();
		}

		private void ExitButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void ConfirmButton_Click(object sender, EventArgs e)
		{
			string PasswordPassed = "I_Am_The_Most_Wanted";
			string PasswordEntered = PasswordBox.Text;
			if (PasswordPassed == PasswordEntered)
			{
				Properties.Settings.Default.PasswordPassed = true;
				Properties.Settings.Default.Save();
				this.Close();
			}
			else
			{
				PasswordBox.Text = "";
				MessageBox.Show("Incorrect password. Please read Readme.txt to find the correct one.", "Warning");
			}
		}
	}
}
