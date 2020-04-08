using System;
using System.Windows.Forms;
using Binary.Properties;



namespace Binary.Interact
{
	public partial class Welcome : Form
	{
		public Welcome()
		{
			this.InitializeComponent();
		}

		private void ExitButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void ConfirmButton_Click(object sender, EventArgs e)
		{
			string PasswordPassed = "I_Am_The_Most_Wanted";
			string PasswordEntered = this.PasswordBox.Text;
			if (PasswordPassed == PasswordEntered)
			{
				Settings.Default.PasswordPassed = true;
				Settings.Default.Save();
				this.Close();
			}
			else
			{
				this.PasswordBox.Text = "";
				MessageBox.Show("Incorrect password. Please read Readme.txt to find the correct one.", "Warning");
			}
		}
	}
}
