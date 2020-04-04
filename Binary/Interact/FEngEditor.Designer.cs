namespace Binary.Interact
{
    partial class FEngEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FEngEditor));
			this.CheckKeepAlpha = new System.Windows.Forms.CheckBox();
			this.CheckReplaceAll = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.NewColorBox = new System.Windows.Forms.PictureBox();
			this.NewBackground = new System.Windows.Forms.PictureBox();
			this.TrackBar_Red = new System.Windows.Forms.TrackBar();
			this.LabelB = new System.Windows.Forms.Label();
			this.LabelG = new System.Windows.Forms.Label();
			this.OpenWindowsColorForm = new System.Windows.Forms.Button();
			this.LabelR = new System.Windows.Forms.Label();
			this.TrackBar_Alpha = new System.Windows.Forms.TrackBar();
			this.LabelA = new System.Windows.Forms.Label();
			this.TrackBar_Blue = new System.Windows.Forms.TrackBar();
			this.NewRed = new System.Windows.Forms.NumericUpDown();
			this.TrackBar_Green = new System.Windows.Forms.TrackBar();
			this.NewGreen = new System.Windows.Forms.NumericUpDown();
			this.NewBlue = new System.Windows.Forms.NumericUpDown();
			this.NewAlpha = new System.Windows.Forms.NumericUpDown();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.CurrentColorBox = new System.Windows.Forms.PictureBox();
			this.CurrentBackground = new System.Windows.Forms.PictureBox();
			this.CurrentOffset = new System.Windows.Forms.TextBox();
			this.CurrentGreen = new System.Windows.Forms.TextBox();
			this.CurrentAlpha = new System.Windows.Forms.TextBox();
			this.CurrentBlue = new System.Windows.Forms.TextBox();
			this.CurrentRed = new System.Windows.Forms.TextBox();
			this.CurrentIndex = new System.Windows.Forms.TextBox();
			this.LabelIndex = new System.Windows.Forms.Label();
			this.LabelOffset = new System.Windows.Forms.Label();
			this.LabelCurrentBlue = new System.Windows.Forms.Label();
			this.LabelCurrentRed = new System.Windows.Forms.Label();
			this.LabelCurrentGreen = new System.Windows.Forms.Label();
			this.LabelCurrentAlpha = new System.Windows.Forms.Label();
			this.ButtonCancel = new System.Windows.Forms.Button();
			this.ButtonOK = new System.Windows.Forms.Button();
			this.SwatchDialog = new System.Windows.Forms.ColorDialog();
			this.CheckReplaceSame = new System.Windows.Forms.CheckBox();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NewColorBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NewBackground)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Red)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Alpha)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Blue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NewRed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Green)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NewGreen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NewBlue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NewAlpha)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CurrentColorBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CurrentBackground)).BeginInit();
			this.SuspendLayout();
			// 
			// CheckKeepAlpha
			// 
			this.CheckKeepAlpha.AutoSize = true;
			this.CheckKeepAlpha.Enabled = false;
			this.CheckKeepAlpha.ForeColor = System.Drawing.SystemColors.Info;
			this.CheckKeepAlpha.Location = new System.Drawing.Point(272, 396);
			this.CheckKeepAlpha.Name = "CheckKeepAlpha";
			this.CheckKeepAlpha.Size = new System.Drawing.Size(119, 17);
			this.CheckKeepAlpha.TabIndex = 16;
			this.CheckKeepAlpha.Text = "Keep Original Alpha";
			this.CheckKeepAlpha.UseVisualStyleBackColor = true;
			// 
			// CheckReplaceAll
			// 
			this.CheckReplaceAll.AutoSize = true;
			this.CheckReplaceAll.ForeColor = System.Drawing.SystemColors.Info;
			this.CheckReplaceAll.Location = new System.Drawing.Point(47, 396);
			this.CheckReplaceAll.Name = "CheckReplaceAll";
			this.CheckReplaceAll.Size = new System.Drawing.Size(155, 17);
			this.CheckReplaceAll.TabIndex = 15;
			this.CheckReplaceAll.Text = "Replace All With This Color";
			this.CheckReplaceAll.UseVisualStyleBackColor = true;
			this.CheckReplaceAll.CheckedChanged += new System.EventHandler(this.CheckReplaceAll_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.NewColorBox);
			this.groupBox2.Controls.Add(this.NewBackground);
			this.groupBox2.Controls.Add(this.TrackBar_Red);
			this.groupBox2.Controls.Add(this.LabelB);
			this.groupBox2.Controls.Add(this.LabelG);
			this.groupBox2.Controls.Add(this.OpenWindowsColorForm);
			this.groupBox2.Controls.Add(this.LabelR);
			this.groupBox2.Controls.Add(this.TrackBar_Alpha);
			this.groupBox2.Controls.Add(this.LabelA);
			this.groupBox2.Controls.Add(this.TrackBar_Blue);
			this.groupBox2.Controls.Add(this.NewRed);
			this.groupBox2.Controls.Add(this.TrackBar_Green);
			this.groupBox2.Controls.Add(this.NewGreen);
			this.groupBox2.Controls.Add(this.NewBlue);
			this.groupBox2.Controls.Add(this.NewAlpha);
			this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.groupBox2.Location = new System.Drawing.Point(272, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(400, 369);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "New Color";
			// 
			// NewColorBox
			// 
			this.NewColorBox.BackColor = System.Drawing.Color.Black;
			this.NewColorBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.NewColorBox.ErrorImage = null;
			this.NewColorBox.InitialImage = null;
			this.NewColorBox.Location = new System.Drawing.Point(144, 269);
			this.NewColorBox.Name = "NewColorBox";
			this.NewColorBox.Size = new System.Drawing.Size(100, 50);
			this.NewColorBox.TabIndex = 7;
			this.NewColorBox.TabStop = false;
			// 
			// NewBackground
			// 
			this.NewBackground.BackColor = System.Drawing.Color.Black;
			this.NewBackground.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.NewBackground.ErrorImage = null;
			this.NewBackground.Image = global::Binary.Properties.Resources.background;
			this.NewBackground.InitialImage = null;
			this.NewBackground.Location = new System.Drawing.Point(144, 269);
			this.NewBackground.Name = "NewBackground";
			this.NewBackground.Size = new System.Drawing.Size(100, 50);
			this.NewBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.NewBackground.TabIndex = 4;
			this.NewBackground.TabStop = false;
			// 
			// TrackBar_Red
			// 
			this.TrackBar_Red.Location = new System.Drawing.Point(33, 78);
			this.TrackBar_Red.Maximum = 255;
			this.TrackBar_Red.Name = "TrackBar_Red";
			this.TrackBar_Red.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.TrackBar_Red.Size = new System.Drawing.Size(45, 179);
			this.TrackBar_Red.TabIndex = 4;
			this.TrackBar_Red.Scroll += new System.EventHandler(this.TrackBar_Red_Scroll);
			// 
			// LabelB
			// 
			this.LabelB.AutoSize = true;
			this.LabelB.Location = new System.Drawing.Point(227, 29);
			this.LabelB.Name = "LabelB";
			this.LabelB.Size = new System.Drawing.Size(28, 13);
			this.LabelB.TabIndex = 2;
			this.LabelB.Text = "Blue";
			// 
			// LabelG
			// 
			this.LabelG.AutoSize = true;
			this.LabelG.Location = new System.Drawing.Point(127, 29);
			this.LabelG.Name = "LabelG";
			this.LabelG.Size = new System.Drawing.Size(36, 13);
			this.LabelG.TabIndex = 2;
			this.LabelG.Text = "Green";
			// 
			// OpenWindowsColorForm
			// 
			this.OpenWindowsColorForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.OpenWindowsColorForm.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.OpenWindowsColorForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.OpenWindowsColorForm.ForeColor = System.Drawing.SystemColors.Control;
			this.OpenWindowsColorForm.Location = new System.Drawing.Point(33, 334);
			this.OpenWindowsColorForm.Name = "OpenWindowsColorForm";
			this.OpenWindowsColorForm.Size = new System.Drawing.Size(340, 23);
			this.OpenWindowsColorForm.TabIndex = 5;
			this.OpenWindowsColorForm.Text = "Use Windows Color Picker";
			this.OpenWindowsColorForm.UseVisualStyleBackColor = false;
			this.OpenWindowsColorForm.Click += new System.EventHandler(this.OpenWindowsColorForm_Click);
			// 
			// LabelR
			// 
			this.LabelR.AutoSize = true;
			this.LabelR.Location = new System.Drawing.Point(30, 29);
			this.LabelR.Name = "LabelR";
			this.LabelR.Size = new System.Drawing.Size(27, 13);
			this.LabelR.TabIndex = 2;
			this.LabelR.Text = "Red";
			// 
			// TrackBar_Alpha
			// 
			this.TrackBar_Alpha.Location = new System.Drawing.Point(328, 78);
			this.TrackBar_Alpha.Maximum = 255;
			this.TrackBar_Alpha.Name = "TrackBar_Alpha";
			this.TrackBar_Alpha.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.TrackBar_Alpha.Size = new System.Drawing.Size(45, 179);
			this.TrackBar_Alpha.TabIndex = 4;
			this.TrackBar_Alpha.Scroll += new System.EventHandler(this.TrackBar_Alpha_Scroll);
			// 
			// LabelA
			// 
			this.LabelA.AutoSize = true;
			this.LabelA.Location = new System.Drawing.Point(326, 29);
			this.LabelA.Name = "LabelA";
			this.LabelA.Size = new System.Drawing.Size(34, 13);
			this.LabelA.TabIndex = 2;
			this.LabelA.Text = "Alpha";
			// 
			// TrackBar_Blue
			// 
			this.TrackBar_Blue.Location = new System.Drawing.Point(230, 78);
			this.TrackBar_Blue.Maximum = 255;
			this.TrackBar_Blue.Name = "TrackBar_Blue";
			this.TrackBar_Blue.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.TrackBar_Blue.Size = new System.Drawing.Size(45, 179);
			this.TrackBar_Blue.TabIndex = 4;
			this.TrackBar_Blue.Scroll += new System.EventHandler(this.TrackBar_Blue_Scroll);
			// 
			// NewRed
			// 
			this.NewRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.NewRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.NewRed.ForeColor = System.Drawing.SystemColors.Info;
			this.NewRed.Location = new System.Drawing.Point(33, 52);
			this.NewRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.NewRed.Name = "NewRed";
			this.NewRed.Size = new System.Drawing.Size(44, 20);
			this.NewRed.TabIndex = 3;
			this.NewRed.ValueChanged += new System.EventHandler(this.NewRed_ValueChanged);
			// 
			// TrackBar_Green
			// 
			this.TrackBar_Green.Location = new System.Drawing.Point(130, 78);
			this.TrackBar_Green.Maximum = 255;
			this.TrackBar_Green.Name = "TrackBar_Green";
			this.TrackBar_Green.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.TrackBar_Green.Size = new System.Drawing.Size(45, 179);
			this.TrackBar_Green.TabIndex = 4;
			this.TrackBar_Green.Scroll += new System.EventHandler(this.TrackBar_Green_Scroll);
			// 
			// NewGreen
			// 
			this.NewGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.NewGreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.NewGreen.ForeColor = System.Drawing.SystemColors.Info;
			this.NewGreen.Location = new System.Drawing.Point(130, 53);
			this.NewGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.NewGreen.Name = "NewGreen";
			this.NewGreen.Size = new System.Drawing.Size(44, 20);
			this.NewGreen.TabIndex = 3;
			this.NewGreen.ValueChanged += new System.EventHandler(this.NewGreen_ValueChanged);
			// 
			// NewBlue
			// 
			this.NewBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.NewBlue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.NewBlue.ForeColor = System.Drawing.SystemColors.Info;
			this.NewBlue.Location = new System.Drawing.Point(230, 52);
			this.NewBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.NewBlue.Name = "NewBlue";
			this.NewBlue.Size = new System.Drawing.Size(44, 20);
			this.NewBlue.TabIndex = 3;
			this.NewBlue.ValueChanged += new System.EventHandler(this.NewBlue_ValueChanged);
			// 
			// NewAlpha
			// 
			this.NewAlpha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.NewAlpha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.NewAlpha.ForeColor = System.Drawing.SystemColors.Info;
			this.NewAlpha.Location = new System.Drawing.Point(329, 52);
			this.NewAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.NewAlpha.Name = "NewAlpha";
			this.NewAlpha.Size = new System.Drawing.Size(44, 20);
			this.NewAlpha.TabIndex = 3;
			this.NewAlpha.ValueChanged += new System.EventHandler(this.NewAlpha_ValueChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.CurrentColorBox);
			this.groupBox1.Controls.Add(this.CurrentBackground);
			this.groupBox1.Controls.Add(this.CurrentOffset);
			this.groupBox1.Controls.Add(this.CurrentGreen);
			this.groupBox1.Controls.Add(this.CurrentAlpha);
			this.groupBox1.Controls.Add(this.CurrentBlue);
			this.groupBox1.Controls.Add(this.CurrentRed);
			this.groupBox1.Controls.Add(this.CurrentIndex);
			this.groupBox1.Controls.Add(this.LabelIndex);
			this.groupBox1.Controls.Add(this.LabelOffset);
			this.groupBox1.Controls.Add(this.LabelCurrentBlue);
			this.groupBox1.Controls.Add(this.LabelCurrentRed);
			this.groupBox1.Controls.Add(this.LabelCurrentGreen);
			this.groupBox1.Controls.Add(this.LabelCurrentAlpha);
			this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(246, 344);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Current Color";
			// 
			// CurrentColorBox
			// 
			this.CurrentColorBox.BackColor = System.Drawing.Color.Black;
			this.CurrentColorBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.CurrentColorBox.ErrorImage = null;
			this.CurrentColorBox.InitialImage = null;
			this.CurrentColorBox.Location = new System.Drawing.Point(69, 269);
			this.CurrentColorBox.Name = "CurrentColorBox";
			this.CurrentColorBox.Size = new System.Drawing.Size(100, 50);
			this.CurrentColorBox.TabIndex = 6;
			this.CurrentColorBox.TabStop = false;
			// 
			// CurrentBackground
			// 
			this.CurrentBackground.BackColor = System.Drawing.Color.Black;
			this.CurrentBackground.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.CurrentBackground.ErrorImage = null;
			this.CurrentBackground.Image = global::Binary.Properties.Resources.background;
			this.CurrentBackground.InitialImage = null;
			this.CurrentBackground.Location = new System.Drawing.Point(69, 269);
			this.CurrentBackground.Name = "CurrentBackground";
			this.CurrentBackground.Size = new System.Drawing.Size(100, 50);
			this.CurrentBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.CurrentBackground.TabIndex = 4;
			this.CurrentBackground.TabStop = false;
			// 
			// CurrentOffset
			// 
			this.CurrentOffset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.CurrentOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CurrentOffset.ForeColor = System.Drawing.SystemColors.Info;
			this.CurrentOffset.Location = new System.Drawing.Point(86, 72);
			this.CurrentOffset.Name = "CurrentOffset";
			this.CurrentOffset.ReadOnly = true;
			this.CurrentOffset.Size = new System.Drawing.Size(100, 20);
			this.CurrentOffset.TabIndex = 3;
			this.CurrentOffset.Text = "0";
			// 
			// CurrentGreen
			// 
			this.CurrentGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.CurrentGreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CurrentGreen.ForeColor = System.Drawing.SystemColors.Info;
			this.CurrentGreen.Location = new System.Drawing.Point(86, 155);
			this.CurrentGreen.Name = "CurrentGreen";
			this.CurrentGreen.ReadOnly = true;
			this.CurrentGreen.Size = new System.Drawing.Size(100, 20);
			this.CurrentGreen.TabIndex = 3;
			this.CurrentGreen.Text = "0";
			// 
			// CurrentAlpha
			// 
			this.CurrentAlpha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.CurrentAlpha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CurrentAlpha.ForeColor = System.Drawing.SystemColors.Info;
			this.CurrentAlpha.Location = new System.Drawing.Point(86, 221);
			this.CurrentAlpha.Name = "CurrentAlpha";
			this.CurrentAlpha.ReadOnly = true;
			this.CurrentAlpha.Size = new System.Drawing.Size(100, 20);
			this.CurrentAlpha.TabIndex = 3;
			this.CurrentAlpha.Text = "0";
			// 
			// CurrentBlue
			// 
			this.CurrentBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.CurrentBlue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CurrentBlue.ForeColor = System.Drawing.SystemColors.Info;
			this.CurrentBlue.Location = new System.Drawing.Point(86, 188);
			this.CurrentBlue.Name = "CurrentBlue";
			this.CurrentBlue.ReadOnly = true;
			this.CurrentBlue.Size = new System.Drawing.Size(100, 20);
			this.CurrentBlue.TabIndex = 3;
			this.CurrentBlue.Text = "0";
			// 
			// CurrentRed
			// 
			this.CurrentRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.CurrentRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CurrentRed.ForeColor = System.Drawing.SystemColors.Info;
			this.CurrentRed.Location = new System.Drawing.Point(86, 122);
			this.CurrentRed.Name = "CurrentRed";
			this.CurrentRed.ReadOnly = true;
			this.CurrentRed.Size = new System.Drawing.Size(100, 20);
			this.CurrentRed.TabIndex = 3;
			this.CurrentRed.Text = "0";
			// 
			// CurrentIndex
			// 
			this.CurrentIndex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.CurrentIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CurrentIndex.ForeColor = System.Drawing.SystemColors.Info;
			this.CurrentIndex.Location = new System.Drawing.Point(86, 39);
			this.CurrentIndex.Name = "CurrentIndex";
			this.CurrentIndex.ReadOnly = true;
			this.CurrentIndex.Size = new System.Drawing.Size(100, 20);
			this.CurrentIndex.TabIndex = 3;
			this.CurrentIndex.Text = "0";
			// 
			// LabelIndex
			// 
			this.LabelIndex.AutoSize = true;
			this.LabelIndex.ForeColor = System.Drawing.Color.White;
			this.LabelIndex.Location = new System.Drawing.Point(47, 41);
			this.LabelIndex.Name = "LabelIndex";
			this.LabelIndex.Size = new System.Drawing.Size(33, 13);
			this.LabelIndex.TabIndex = 2;
			this.LabelIndex.Text = "Index";
			// 
			// LabelOffset
			// 
			this.LabelOffset.AutoSize = true;
			this.LabelOffset.ForeColor = System.Drawing.Color.White;
			this.LabelOffset.Location = new System.Drawing.Point(45, 74);
			this.LabelOffset.Name = "LabelOffset";
			this.LabelOffset.Size = new System.Drawing.Size(35, 13);
			this.LabelOffset.TabIndex = 2;
			this.LabelOffset.Text = "Offset";
			// 
			// LabelCurrentBlue
			// 
			this.LabelCurrentBlue.AutoSize = true;
			this.LabelCurrentBlue.ForeColor = System.Drawing.Color.White;
			this.LabelCurrentBlue.Location = new System.Drawing.Point(52, 190);
			this.LabelCurrentBlue.Name = "LabelCurrentBlue";
			this.LabelCurrentBlue.Size = new System.Drawing.Size(28, 13);
			this.LabelCurrentBlue.TabIndex = 2;
			this.LabelCurrentBlue.Text = "Blue";
			// 
			// LabelCurrentRed
			// 
			this.LabelCurrentRed.AutoSize = true;
			this.LabelCurrentRed.ForeColor = System.Drawing.Color.White;
			this.LabelCurrentRed.Location = new System.Drawing.Point(53, 124);
			this.LabelCurrentRed.Name = "LabelCurrentRed";
			this.LabelCurrentRed.Size = new System.Drawing.Size(27, 13);
			this.LabelCurrentRed.TabIndex = 2;
			this.LabelCurrentRed.Text = "Red";
			// 
			// LabelCurrentGreen
			// 
			this.LabelCurrentGreen.AutoSize = true;
			this.LabelCurrentGreen.ForeColor = System.Drawing.Color.White;
			this.LabelCurrentGreen.Location = new System.Drawing.Point(44, 157);
			this.LabelCurrentGreen.Name = "LabelCurrentGreen";
			this.LabelCurrentGreen.Size = new System.Drawing.Size(36, 13);
			this.LabelCurrentGreen.TabIndex = 2;
			this.LabelCurrentGreen.Text = "Green";
			// 
			// LabelCurrentAlpha
			// 
			this.LabelCurrentAlpha.AutoSize = true;
			this.LabelCurrentAlpha.ForeColor = System.Drawing.Color.White;
			this.LabelCurrentAlpha.Location = new System.Drawing.Point(46, 223);
			this.LabelCurrentAlpha.Name = "LabelCurrentAlpha";
			this.LabelCurrentAlpha.Size = new System.Drawing.Size(34, 13);
			this.LabelCurrentAlpha.TabIndex = 2;
			this.LabelCurrentAlpha.Text = "Alpha";
			// 
			// ButtonCancel
			// 
			this.ButtonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.ButtonCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ButtonCancel.ForeColor = System.Drawing.SystemColors.Control;
			this.ButtonCancel.Location = new System.Drawing.Point(549, 393);
			this.ButtonCancel.Name = "ButtonCancel";
			this.ButtonCancel.Size = new System.Drawing.Size(123, 23);
			this.ButtonCancel.TabIndex = 11;
			this.ButtonCancel.Text = "Cancel";
			this.ButtonCancel.UseVisualStyleBackColor = false;
			// 
			// ButtonOK
			// 
			this.ButtonOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
			this.ButtonOK.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ButtonOK.ForeColor = System.Drawing.SystemColors.Control;
			this.ButtonOK.Location = new System.Drawing.Point(420, 393);
			this.ButtonOK.Name = "ButtonOK";
			this.ButtonOK.Size = new System.Drawing.Size(123, 23);
			this.ButtonOK.TabIndex = 12;
			this.ButtonOK.Text = "OK";
			this.ButtonOK.UseVisualStyleBackColor = false;
			this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
			// 
			// CheckReplaceSame
			// 
			this.CheckReplaceSame.AutoSize = true;
			this.CheckReplaceSame.ForeColor = System.Drawing.SystemColors.Info;
			this.CheckReplaceSame.Location = new System.Drawing.Point(47, 373);
			this.CheckReplaceSame.Name = "CheckReplaceSame";
			this.CheckReplaceSame.Size = new System.Drawing.Size(171, 17);
			this.CheckReplaceSame.TabIndex = 17;
			this.CheckReplaceSame.Text = "Replace Same With This Color";
			this.CheckReplaceSame.UseVisualStyleBackColor = true;
			this.CheckReplaceSame.CheckedChanged += new System.EventHandler(this.CheckReplaceSame_CheckedChanged);
			// 
			// FEngEditor
			// 
			this.AcceptButton = this.ButtonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(36)))), ((int)(((byte)(53)))));
			this.CancelButton = this.ButtonCancel;
			this.ClientSize = new System.Drawing.Size(684, 428);
			this.Controls.Add(this.CheckReplaceSame);
			this.Controls.Add(this.CheckKeepAlpha);
			this.Controls.Add(this.CheckReplaceAll);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.ButtonCancel);
			this.Controls.Add(this.ButtonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FEngEditor";
			this.Text = "FEng Editor by MaxHwoy";
			this.Load += new System.EventHandler(this.FEngEditor_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NewColorBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NewBackground)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Red)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Alpha)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Blue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NewRed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Green)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NewGreen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NewBlue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NewAlpha)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CurrentColorBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CurrentBackground)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckKeepAlpha;
        private System.Windows.Forms.CheckBox CheckReplaceAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox NewBackground;
        private System.Windows.Forms.TrackBar TrackBar_Red;
        private System.Windows.Forms.Label LabelB;
        private System.Windows.Forms.Label LabelG;
        private System.Windows.Forms.Button OpenWindowsColorForm;
        private System.Windows.Forms.Label LabelR;
        private System.Windows.Forms.TrackBar TrackBar_Alpha;
        private System.Windows.Forms.Label LabelA;
        private System.Windows.Forms.TrackBar TrackBar_Blue;
        private System.Windows.Forms.NumericUpDown NewRed;
        private System.Windows.Forms.TrackBar TrackBar_Green;
        private System.Windows.Forms.NumericUpDown NewGreen;
        private System.Windows.Forms.NumericUpDown NewBlue;
        private System.Windows.Forms.NumericUpDown NewAlpha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox CurrentBackground;
        private System.Windows.Forms.TextBox CurrentOffset;
        private System.Windows.Forms.TextBox CurrentGreen;
        private System.Windows.Forms.TextBox CurrentAlpha;
        private System.Windows.Forms.TextBox CurrentBlue;
        private System.Windows.Forms.TextBox CurrentRed;
        private System.Windows.Forms.TextBox CurrentIndex;
        private System.Windows.Forms.Label LabelIndex;
        private System.Windows.Forms.Label LabelOffset;
        private System.Windows.Forms.Label LabelCurrentBlue;
        private System.Windows.Forms.Label LabelCurrentRed;
        private System.Windows.Forms.Label LabelCurrentGreen;
        private System.Windows.Forms.Label LabelCurrentAlpha;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.ColorDialog SwatchDialog;
        private System.Windows.Forms.PictureBox NewColorBox;
        private System.Windows.Forms.PictureBox CurrentColorBox;
        private System.Windows.Forms.CheckBox CheckReplaceSame;
    }
}