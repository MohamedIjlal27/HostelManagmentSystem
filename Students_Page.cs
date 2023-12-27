using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Databaseproject
{
	public partial class Students_Page : Form
	{
		public Students_Page()
		{
			InitializeComponent();
		}

		private void gunaGradientButton5_Click(object sender, EventArgs e)
		{
			Home_Page hp=new Home_Page();
			hp.Show();
			this.Hide();
		}

		private void gunaGradientTileButton1_Click(object sender, EventArgs e)
		{
			Student_Database sd =new Student_Database();
			sd.Show();
			this.Hide();
		}

		private void gunaGradientTileButton2_Click(object sender, EventArgs e)
		{
			Room_Allotment r=new Room_Allotment();
			r.Show();
			this.Close();
		}

		private void gunaGradientTileButton3_Click(object sender, EventArgs e)
		{
			Vacant_Room v =new Vacant_Room();
			v.Show();
			this.Hide();
		}
	}
}
