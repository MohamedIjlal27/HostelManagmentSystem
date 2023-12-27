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
	public partial class Default_List : Form
	{
		public Default_List()
		{
			InitializeComponent();
		}

		private void MessBtn_Click(object sender, EventArgs e)
		{
			Mess n = new Mess();
			n.Show();
			this.Hide();
		}

		private void HomeBtn_Click(object sender, EventArgs e)
		{
			Home_Page h = new Home_Page();
			h.Show();
			this.Hide();
		}
	}
}
