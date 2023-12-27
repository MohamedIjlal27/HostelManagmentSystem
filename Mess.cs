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
	public partial class Mess : Form
	{
		public Mess()
		{
			InitializeComponent();
		}

		private void homeBtn_Click(object sender, EventArgs e)
		{
			Home_Page h=new Home_Page();
			h.Show();
			this.Hide();
		}

		private void menuBtn_Click(object sender, EventArgs e)
		{
			Mess_Menu mm=new Mess_Menu();
			mm.Show();
			this.Hide();
		}

		private void attendanceBtn_Click(object sender, EventArgs e)
		{
			Mess_Attendancecs ma=new Mess_Attendancecs();
			ma.Show();
			this.Hide();
		}

		private void feesBtn_Click(object sender, EventArgs e)
		{
			Mess_Fee fe=new Mess_Fee();
			fe.Show();
			this.Hide();
		}

		private void expnidtureBtn_Click(object sender, EventArgs e)
		{
			Mess_Expenditure me=new Mess_Expenditure();
			me.Show();
			this.Hide();
		}

		private void listBtn_Click(object sender, EventArgs e)
		{
			Default_List d=new Default_List();
			d.Show();
			this.Hide();
		}
	}
}
