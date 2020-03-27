namespace Binary.Interact
{
	partial class Input
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Input));
			this.ButtonOK = new System.Windows.Forms.Button();
			this.ButtonCancel = new System.Windows.Forms.Button();
			this.UserAskLabel = new System.Windows.Forms.Label();
			this.UserInput = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// ButtonOK
			// 
			this.ButtonOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ButtonOK.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonOK.ForeColor = System.Drawing.SystemColors.Info;
			this.ButtonOK.Location = new System.Drawing.Point(144, 67);
			this.ButtonOK.Name = "ButtonOK";
			this.ButtonOK.Size = new System.Drawing.Size(97, 23);
			this.ButtonOK.TabIndex = 7;
			this.ButtonOK.Text = "OK";
			this.ButtonOK.UseVisualStyleBackColor = false;
			this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
			// 
			// ButtonCancel
			// 
			this.ButtonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.ButtonCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonCancel.ForeColor = System.Drawing.SystemColors.Info;
			this.ButtonCancel.Location = new System.Drawing.Point(247, 67);
			this.ButtonCancel.Name = "ButtonCancel";
			this.ButtonCancel.Size = new System.Drawing.Size(97, 23);
			this.ButtonCancel.TabIndex = 6;
			this.ButtonCancel.Text = "Cancel";
			this.ButtonCancel.UseVisualStyleBackColor = false;
			this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// UserAskLabel
			// 
			this.UserAskLabel.AutoSize = true;
			this.UserAskLabel.ForeColor = System.Drawing.SystemColors.Window;
			this.UserAskLabel.Location = new System.Drawing.Point(12, 18);
			this.UserAskLabel.Name = "UserAskLabel";
			this.UserAskLabel.Size = new System.Drawing.Size(135, 13);
			this.UserAskLabel.TabIndex = 5;
			this.UserAskLabel.Text = "Enter new Collection Name";
			// 
			// UserInput
			// 
			this.UserInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.UserInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.UserInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UserInput.ForeColor = System.Drawing.SystemColors.Window;
			this.UserInput.Location = new System.Drawing.Point(12, 34);
			this.UserInput.Name = "UserInput";
			this.UserInput.Size = new System.Drawing.Size(332, 22);
			this.UserInput.TabIndex = 4;
			// 
			// Input
			// 
			this.AcceptButton = this.ButtonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(36)))), ((int)(((byte)(53)))));
			this.CancelButton = this.ButtonCancel;
			this.ClientSize = new System.Drawing.Size(356, 108);
			this.Controls.Add(this.ButtonOK);
			this.Controls.Add(this.ButtonCancel);
			this.Controls.Add(this.UserAskLabel);
			this.Controls.Add(this.UserInput);
			this.ForeColor = System.Drawing.SystemColors.Info;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Input";
			this.Text = "Editor";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ButtonOK;
		private System.Windows.Forms.Button ButtonCancel;
		private System.Windows.Forms.Label UserAskLabel;
		private System.Windows.Forms.TextBox UserInput;
	}
}