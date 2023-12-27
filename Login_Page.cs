using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Databaseproject
{
	public partial class Login_Page : Form
	{
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        public Login_Page()
		{
			InitializeComponent();
            con = new SqlConnection(dbcon.connection());
        }

		private void Form1_Load(object sender, EventArgs e)
		{
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void bunifuThinButton21_Click(object sender, EventArgs e)
		{
            // Login Button
            string _name = "";
            byte[] _imageData;

            string us = textBox1.Text;
            string ps = textBox2.Text;

            /*    try
                { */
                    con.Open();

                    String sql = "SELECT Full_Name, Image FROM Register_Login WHERE  User_Name= '" + us + "' AND Password='" + ps + "' ";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@User_Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                    dr = cmd.ExecuteReader();
                     
                    if (dr.Read())
                    {
                         _name = dr["Full_Name"].ToString();
                        _imageData = (byte[])dr["Image"];

                     MessageBox.Show(" Welcome " + _name + " Your Login Loading... ", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     Home_Page main = new Home_Page();
                     using (MemoryStream ms = new MemoryStream(_imageData))
                     {
                       main.gunaCirclePictureBox1.Image = Image.FromStream(ms);
                     }
                     main.label1.Text = _name;
                     this.Hide();
                     main.ShowDialog();
                     //MessageBox.Show(" Welcome " + _name + " Your Login Loading... ", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Close();

                     }
                    else
                    {
                        MessageBox.Show("Invalid User Name or Password! ", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        con.Close();
                    }
                   

            /*}catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Your Login Failed....!..");

            }*/






            //  Home_Page hp = new Home_Page();
            //hp.Show();
            //this.Hide();
        }

		private void bunifuThinButton22_Click(object sender, EventArgs e)
		{
			Register r=new Register();
			r.Show();
			this.Hide();
		}

		private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Forgot_Password f=new Forgot_Password();
			f.Show();
			this.Hide();
		}

        private void gunaCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
