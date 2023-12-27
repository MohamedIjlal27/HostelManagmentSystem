using Microsoft.Reporting.WinForms;
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
	public partial class Student_Database : Form
	{
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        public Student_Database()
		{
			InitializeComponent();
            con = new SqlConnection(dbcon.connection());
        }

		private void gunaTextBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void gunaGradientButton1_Click(object sender, EventArgs e)
		{
			Students_Page sp = new Students_Page();
			sp.Show();
			this.Hide();
		}

		private void gunaGradientButton5_Click(object sender, EventArgs e)
		{
			Home_Page hp = new Home_Page();
			hp.Show();
			this.Hide();
		}

		private void Student_Database_Load(object sender, EventArgs e)
		{
            GetStudentRecord();
            this.reportViewer1.RefreshReport();
        }

        private void save_Click(object sender, EventArgs e)
        {
            // Save Button
            try
            {
                con.Open();

                cmd = new SqlCommand("INSERT INTO Student_Database(Std_Reg_No,Student_Name,Father_Name,CNIC_No,Contact_No,Email_Address,Postal_Address,Program)VALUES(@Std_Reg_No,@Student_Name, @Father_Name, @CNIC_No,@Contact_No,@Email_Address,@Postal_Address,@Program)", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                //    cmd.CommandType = CommandType.Text;
                //   cmd.Parameters.AddWithValue("@No#", int.Parse(this.Roll_No));
                cmd.Parameters.AddWithValue("@Std_Reg_No", gunaTextBox1.Text);
                cmd.Parameters.AddWithValue("@Student_Name", gunaTextBox2.Text);
                cmd.Parameters.AddWithValue("@Father_Name", gunaTextBox3.Text);
                cmd.Parameters.AddWithValue("@CNIC_No", gunaTextBox4.Text);
                cmd.Parameters.AddWithValue("@Contact_No", gunaTextBox5.Text);
                cmd.Parameters.AddWithValue("@Email_Address", gunaTextBox6.Text);
                cmd.Parameters.AddWithValue("@Postal_Address", gunaTextBox7.Text);
                cmd.Parameters.AddWithValue("@Program", gunaTextBox8.Text);


                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(" Data SuccessFully Saved..", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetStudentRecord();
                ResetFunction();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Saved");
            }
        }
        private void GetStudentRecord()
        {
            int i = 0;
            con.Open();
            StudentDBRecordGridView.Rows.Clear();
            SqlCommand cmd = new SqlCommand("SELECT Std_Reg_No,Student_Name,Father_Name,CNIC_No,Contact_No,Email_Address,Postal_Address,Program FROM Student_Database", con);
            //DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                i++;
                StudentDBRecordGridView.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());

            }
            dr.Close();
            con.Close();
        }
        private void ResetFunction()
        {
            //Clear
            gunaTextBox1.Clear();
            gunaTextBox2.Clear();
            gunaTextBox3.Clear();
            gunaTextBox4.Clear();
            gunaTextBox5.Clear();
            gunaTextBox6.Clear();
            gunaTextBox7.Clear();
            gunaTextBox8.Clear();

            txtUsername.Clear();
            comboBox1.Items.Clear();


            gunaTextBox1.Focus();
        }
        private void update_Click(object sender, EventArgs e)
        {
            // Update Button
            try
            {
                //SqlConnection Con = new SqlConnection("Data Source=LAPTOP-0LKEO4VQ;Initial Catalog=Paf-iast(DBMS_Project);Persist Security Info=True;User ID=sa;Password=***********");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Student_Database SET Student_Name=@Student_Name, Father_Name=@Father_Name, CNIC_No=@CNIC_No, Contact_No=@Contact_No, Email_Address=@Email_Address, Postal_Address=@Postal_Address, Program=@Program WHERE Std_Reg_No=@Std_Reg_No ", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                //    cmd.Parameters.AddWithValue("@No#", int.Parse(this.Roll_No));
                cmd.Parameters.AddWithValue("@Std_Reg_No", gunaTextBox1.Text);
                cmd.Parameters.AddWithValue("@Student_Name", gunaTextBox2.Text);
                cmd.Parameters.AddWithValue("@Father_Name", gunaTextBox3.Text);
                cmd.Parameters.AddWithValue("@CNIC_No", gunaTextBox4.Text);
                cmd.Parameters.AddWithValue("@Contact_No", gunaTextBox5.Text);
                cmd.Parameters.AddWithValue("@Email_Address", gunaTextBox6.Text);
                cmd.Parameters.AddWithValue("@Postal_Address", gunaTextBox7.Text);
                cmd.Parameters.AddWithValue("@Program", gunaTextBox8.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show(" Data SuccessFully Updated..");
                con.Close();
                GetStudentRecord();
                ResetFunction();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Update");

            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            // Clear Button
            ResetFunction();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            // Delete Button
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE Student_Database WHERE Std_Reg_No=@Std_Reg_No ", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                cmd.Parameters.AddWithValue("@Std_Reg_No", gunaTextBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentRecord();
                MessageBox.Show(" Data SuccessFully Deleted..");
                ResetFunction();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Delete");
            }
        }

        private void NameSearch_Click(object sender, EventArgs e)
        {
            //Search Button in Data grid view
          
            int i = 0;
            con.Open();
            StudentDBRecordGridView.Rows.Clear();

            //SqlCommand cmd = new SqlCommand("SELECT Std_Reg_No,Student_Name,Father_Name,CNIC_No,Contact_No,Email_Address,Postal_Address,Program FROM Student_Database WHERE Student_Name = '" + comboBox1.Text + "'  ORDER BY Student_Name ASC ", con);
            SqlCommand cmd = new SqlCommand("SELECT * from Student_Database WHERE Student_Name LIKE @Student_Name", con);
            cmd.Parameters.AddWithValue("@Student_Name", "%" + comboBox1.Text + "%");
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                i++;
                StudentDBRecordGridView.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());

            }
            dr.Close();
            con.Close();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            //Search Button

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT Std_Reg_No,Student_Name,Father_Name,CNIC_No,Contact_No,Email_Address,Postal_Address,Program FROM Student_Database WHERE Std_Reg_No = '" + txtUsername.Text + "' ", con);

            SqlDataReader DR1 = cmd.ExecuteReader();
            if (DR1.Read())
            {

                //    dateTimePicker1.Value = DR1[0].ToString();
                gunaTextBox1.Text = DR1[0].ToString();
                gunaTextBox2.Text = DR1[1].ToString();
                gunaTextBox3.Text = DR1[2].ToString();
                gunaTextBox4.Text = DR1[3].ToString();
                gunaTextBox5.Text = DR1[4].ToString();
                gunaTextBox6.Text = DR1[5].ToString();
                gunaTextBox7.Text = DR1[6].ToString();
                gunaTextBox8.Text = DR1[7].ToString();

            }
            con.Close();   
        }

        private void StudentDBRecordGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Cell Click in Data Grid View
            int Roll_No;
            Roll_No = Convert.ToInt32(StudentDBRecordGridView.Rows[0].Cells[0].Value);
            gunaTextBox1.Text = StudentDBRecordGridView.SelectedRows[0].Cells[1].Value.ToString();
            gunaTextBox2.Text = StudentDBRecordGridView.SelectedRows[0].Cells[2].Value.ToString();
            gunaTextBox3.Text = StudentDBRecordGridView.SelectedRows[0].Cells[3].Value.ToString();
            gunaTextBox4.Text = StudentDBRecordGridView.SelectedRows[0].Cells[4].Value.ToString();
            gunaTextBox5.Text = StudentDBRecordGridView.SelectedRows[0].Cells[5].Value.ToString();
            gunaTextBox6.Text = StudentDBRecordGridView.SelectedRows[0].Cells[6].Value.ToString();
            gunaTextBox7.Text = StudentDBRecordGridView.SelectedRows[0].Cells[7].Value.ToString();
            gunaTextBox8.Text = StudentDBRecordGridView.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            //Refresh Button
            GetStudentRecord();
            ResetFunction();
            comboBox1.Items.Clear();    
        }

        private void gunaTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gunaTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gunaTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gunaTextBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gunaTextBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gunaTextBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gunaTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaTextBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            //Load Report
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Std_Reg_No,Student_Name,Father_Name,CNIC_No,Contact_No,Email_Address,Postal_Address,Program FROM Student_Database", con);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("StudentDBDataSet", dt);
            reportViewer1.LocalReport.ReportPath = @"C:\Users\Risha\Desktop\IAST Details\4th Semester Dtls\DBMS\DBMS Project\Databaseproject\Databaseproject\Report\ReportStudentDB.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
            con.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaTextBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
