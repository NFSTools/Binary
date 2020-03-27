namespace Binary.Interact
{
	partial class Welcome
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
			this.ExitButton = new System.Windows.Forms.Button();
			this.ConfirmButton = new System.Windows.Forms.Button();
			this.PasswordBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ExitButton
			// 
			this.ExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
			this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ExitButton.ForeColor = System.Drawing.SystemColors.Info;
			this.ExitButton.Location = new System.Drawing.Point(214, 118);
			this.ExitButton.Name = "ExitButton";
			this.ExitButton.Size = new System.Drawing.Size(134, 27);
			this.ExitButton.TabIndex = 9;
			this.ExitButton.Text = "Exit";
			this.ExitButton.UseVisualStyleBackColor = false;
			this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
			// 
			// ConfirmButton
			// 
			this.ConfirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
			this.ConfirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ConfirmButton.ForeColor = System.Drawing.SystemColors.Info;
			this.ConfirmButton.Location = new System.Drawing.Point(63, 118);
			this.ConfirmButton.Name = "ConfirmButton";
			this.ConfirmButton.Size = new System.Drawing.Size(134, 27);
			this.ConfirmButton.TabIndex = 8;
			this.ConfirmButton.Text = "Confirm";
			this.ConfirmButton.UseVisualStyleBackColor = false;
			this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
			// 
			// PasswordBox
			// 
			this.PasswordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(65)))), ((int)(((byte)(72)))));
			this.PasswordBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PasswordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PasswordBox.ForeColor = System.Drawing.SystemColors.Info;
			this.PasswordBox.Location = new System.Drawing.Point(94, 82);
			this.PasswordBox.Name = "PasswordBox";
			this.PasswordBox.ShortcutsEnabled = false;
			this.PasswordBox.Size = new System.Drawing.Size(310, 22);
			this.PasswordBox.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.Info;
			this.label2.Location = new System.Drawing.Point(17, 83);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Password:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.Info;
			this.label1.Location = new System.Drawing.Point(17, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(381, 48);
			this.label1.TabIndex = 5;
			this.label1.Text = "Welcome to NFS-Binary! Before we continue, please enter the\r\npassword that you fo" +
    "und in Readme.txt file. This is a one-time\r\nlog-in, once you enter the password " +
    "you won\'t need to reenter it.\r\n";
			// 
			// Welcome
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(36)))), ((int)(((byte)(53)))));
			this.ClientSize = new System.Drawing.Size(424, 162);
			this.Controls.Add(this.ExitButton);
			this.Controls.Add(this.ConfirmButton);
			this.Controls.Add(this.PasswordBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Welcome";
			this.Text = "Welcome";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ExitButton;
		private System.Windows.Forms.Button ConfirmButton;
		private System.Windows.Forms.TextBox PasswordBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}