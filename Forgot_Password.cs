using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Databaseproject
{
	public partial class Forgot_Password : Form
	{
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        public Forgot_Password()
		{
			InitializeComponent();
            con = new SqlConnection(dbcon.connection());
        }

		private void bunifuThinButton22_Click(object sender, EventArgs e)
		{
            // Save Password Button
            string username = gunaTextBox1.Text;
            string Nw_psswd = gunaTextBox2.Text;
            string Cm_psswd = gunaTextBox3.Text;
            string Cptch = gunaTextBox4.Text;

            try
            {   
                con.Open();
                if (Nw_psswd == Cm_psswd && Cptch == label3.Text)
                {
             
                        SqlCommand cm = new SqlCommand("Update Register_Login SET Password = '" + Nw_psswd + "' WHERE User_Name = '" + username + "' ", con);
                        cm.ExecuteNonQuery();
                        MessageBox.Show(" Your Password Changed Successfully... ");

       
                }
                else
                {
                    MessageBox.Show("Invalid Password | Captcha | UserName ");
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error in Connection ");
                con.Close();
            }  
        }

		private void Forgot_Password_Load(object sender, EventArgs e)
		{
            GenerateCaptcha();
        }

		private void bunifuThinButton23_Click(object sender, EventArgs e)
		{
			Login_Page l=new Login_Page();
			l.Show();
			this.Hide();
		}

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            gunaTextBox1.Clear();
            gunaTextBox2.Clear();
            gunaTextBox3.Clear();
            gunaTextBox4.Clear();

            gunaTextBox1.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void GenerateCaptcha()
        {
            int captchaCode;
            Random rm = new Random();
            captchaCode = rm.Next(1000, 9999); // Generate a random four-digit number for the captcha
            label3.Text = captchaCode.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            // Refresh Button
            GenerateCaptcha();
        }
    }
}
