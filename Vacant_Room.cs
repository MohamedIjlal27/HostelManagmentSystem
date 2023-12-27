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
	public partial class Vacant_Room : Form
	{
		public Vacant_Room()
		{
			InitializeComponent();
		}

		private void gunaGradientButton1_Click(object sender, EventArgs e)
		{
			Students_Page st = new Students_Page();
			st.Show();
			this.Hide();
		}

		private void gunaGradientButton2_Click(object sender, EventArgs e)
		{
			Home_Page h=new Home_Page();
			h.Show();
			this.Hide();
		}
	}
}
