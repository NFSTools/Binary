using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binary.Forms.DataSet
{
	public partial class DataSet : Form
	{
		private bool forceload = false;
		private GlobalLib.Database.Carbon dbC;
		private GlobalLib.Database.MostWanted dbMW;
		private GlobalLib.Database.Underground2 dbUG2;

		private void InstantiateControls()
		{
			this.DataSet_Split2.Panel2.Controls.Add(this.textBox1);
			this.DataSet_Split2.Panel1.Controls.Add(this.dataGridView1);
			this.DataSet_Split1.Panel2.Controls.Add(this.DataSet_Split2);
			this.DataSet_Split1.Panel1.Controls.Add(this.treeView1);
		}

		public DataSet()
		{
			InitializeComponent();
			InstantiateControls();
		}

		public DataSet(bool forceload)
		{
			InitializeComponent();
			InstantiateControls();
			DataSet_MenuStrip.Renderer = new MyRenderer();
			if (forceload)
			{
				this.forceload = forceload;
				//this.DataSet_ReloadFile_Click(null, EventArgs.Empty);
			}
		}

		private class MyRenderer : ToolStripProfessionalRenderer
		{
			public MyRenderer() : base(new MyColors()) { }
		}

		private class MyColors : ProfessionalColorTable
		{
			public override System.Drawing.Color MenuItemSelected
			{
				get { return System.Drawing.Color.FromArgb(40, 23, 60); }
			}
			public override System.Drawing.Color MenuItemSelectedGradientBegin
			{
				get { return System.Drawing.Color.FromArgb(40, 23, 60); }
			}
			public override System.Drawing.Color MenuItemSelectedGradientEnd
			{
				get { return System.Drawing.Color.FromArgb(40, 23, 60); }
			}
		}


	}
}
