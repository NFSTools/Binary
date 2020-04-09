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
