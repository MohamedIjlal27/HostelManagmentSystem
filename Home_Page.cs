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
	public partial class Home_Page : Form
	{
		public Home_Page()
		{
			InitializeComponent();
		}

		private void gunaPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void gunaGradientButton5_Click(object sender, EventArgs e)
		{
			Login_Page lp = new Login_Page();
			lp.Show();
			this.Hide();
		}

		private void gunaGradientButton3_Click(object sender, EventArgs e)
		{
			Students_Page lp = new Students_Page();
			lp.Show();
			this.Hide();
		}

		private void gunaGradientButton1_Click(object sender, EventArgs e)
		{
			Mess m=new Mess();
			m.Show();
			this.Hide();
		}

		private void gunaGradientButton2_Click(object sender, EventArgs e)
		{
			Hostel_Inventory h=new Hostel_Inventory();
			h.Show();
			this.Hide();
		}

		private void gunaGradientButton2_Click_1(object sender, EventArgs e)
		{
			Hostel_Inventory hi=new Hostel_Inventory();
			hi.Show();
			this.Hide();
		}

		private void gunaGradientButton4_Click(object sender, EventArgs e)
		{
			Employee emp=new Employee();
			emp.Show();
			this.Hide();
		}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
