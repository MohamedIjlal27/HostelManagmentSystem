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
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Databaseproject
{
	public partial class Register : Form
	{
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        public Register()
		{
			InitializeComponent();
            con = new SqlConnection(dbcon.connection());
        }

		private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Login_Page l=new Login_Page();
			l.Show();
			this.Hide();
		}
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
		{

            // Save Button
            try
            {
                // if (IsValid())
                // {
                    byte[] imageData = ImageToByteArray(guna2CirclePictureBox1.Image);
                    cmd = new SqlCommand("Insert INTO Register_Login(Full_Name, User_Name, Email, Password, Phone_No, Image)VALUES(@Full_Name, @User_Name, @Email, @Password, @Phone_No, @Image)", con);
                    //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                    cmd.CommandType = CommandType.Text;
                    //   cmd.Parameters.AddWithValue("@No#", int.Parse(this.Roll_No));
                    cmd.Parameters.AddWithValue("@Full_Name", gunaTextBox1.Text);
                    cmd.Parameters.AddWithValue("@User_Name", gunaTextBox2.Text);
                    cmd.Parameters.AddWithValue("@Email", gunaTextBox3.Text);
                    cmd.Parameters.AddWithValue("@Password", gunaTextBox4.Text);
                    cmd.Parameters.AddWithValue("@Phone_No", gunaTextBox5.Text);
                    cmd.Parameters.AddWithValue("@Image", imageData);

                con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show(" Your Account Successfully Created. Login Now...", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

               // }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Saved");
                con.Close();
            }
        }

        private bool IsValid()
        {
            if (gunaTextBox1.Text == string.Empty)
            {
                MessageBox.Show("Full Name is Required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (gunaTextBox2.Text == string.Empty)
            {
                MessageBox.Show("User Name is Required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        private void browseBtn_Click(object sender, EventArgs e)
		{

		}

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            gunaTextBox1.Clear();
            gunaTextBox2.Clear();
            gunaTextBox3.Clear();
            gunaTextBox4.Clear();
            gunaTextBox5.Clear();

            gunaTextBox1.Focus();
        }

        private void gunaTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|.jpg;.jpeg;.png;.gif;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;
                // Perform further operations with the selected image path, such as displaying it in the PictureBox or saving it to the database.
                guna2CirclePictureBox1.Image = Image.FromFile(selectedImagePath);
            }
        }
    }
}
