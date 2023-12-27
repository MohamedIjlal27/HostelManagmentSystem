using Guna.UI.WinForms;
using Guna.UI2.WinForms;
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
	public partial class Employee : Form
	{
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        public Employee()
		{
			InitializeComponent();
            con = new SqlConnection(dbcon.connection());
        }

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void gunaTextBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void gunaTextBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void HomeBtn_Click(object sender, EventArgs e)
		{
			Home_Page home = new Home_Page();
			home.Show();
			this.Hide();
		}

        private void save_Click(object sender, EventArgs e)
        {
            //Save Button
            try
            {
                con.Open();

                cmd = new SqlCommand("INSERT INTO Employee(Emp_Id,Employee_Name,Phone_No,Position,Remarks)VALUES(@Emp_Id,@Employee_Name,@Phone_No,@Position,@Remarks)", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                //    cmd.CommandType = CommandType.Text;
                //   cmd.Parameters.AddWithValue("@No#", int.Parse(this.Roll_No));
                cmd.Parameters.AddWithValue("@Emp_Id", gunaTextBox1.Text);
                cmd.Parameters.AddWithValue("@Employee_Name", gunaTextBox2.Text);
                cmd.Parameters.AddWithValue("@Phone_No", gunaTextBox3.Text);
                cmd.Parameters.AddWithValue("@Position", gunaTextBox4.Text);
                cmd.Parameters.AddWithValue("@Remarks", gunaTextBox5.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(" Data SuccessFully Saved..", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetProductRecord();
                ResetFunction();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Saved");
            }
        }
        private void GetProductRecord()
        {

            int i = 0;
            con.Open();
            EmployeedataGridView.Rows.Clear();
            SqlCommand cmd = new SqlCommand("SELECT Emp_Id,Employee_Name,Phone_No,Position,Remarks FROM Employee", con);
            //DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                i++;
                EmployeedataGridView.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());

            }
            dr.Close();
            con.Close();


        }
        private void ResetFunction()
        {
            // Clear Button
            //   object value = dateTimePicker1.Clear();
            gunaTextBox1.Clear();
            gunaTextBox2.Clear();
            gunaTextBox3.Clear();
            gunaTextBox4.Clear();
            gunaTextBox5.Clear();
            gunaTextBox6.Clear();

            gunaTextBox1.Focus();
        }

        private void update_Click(object sender, EventArgs e)
        {
            //Update Button
            try
            {
                //SqlConnection Con = new SqlConnection("Data Source=LAPTOP-0LKEO4VQ;Initial Catalog=Paf-iast(DBMS_Project);Persist Security Info=True;User ID=sa;Password=***********");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Employee SET Employee_Name=@Employee_Name,Phone_No=@Phone_No,Position=@Position,Remarks=@Remarks WHERE Emp_Id=@Emp_Id ", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                //    cmd.Parameters.AddWithValue("@No#", int.Parse(this.Roll_No));
                cmd.Parameters.AddWithValue("@Emp_Id", gunaTextBox1.Text);
                cmd.Parameters.AddWithValue("@Employee_Name", gunaTextBox2.Text);
                cmd.Parameters.AddWithValue("@Phone_No", gunaTextBox3.Text);
                cmd.Parameters.AddWithValue("@Position", gunaTextBox4.Text);
                cmd.Parameters.AddWithValue("@Remarks", gunaTextBox5.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show(" Data SuccessFully Updated..");
                con.Close();
                GetProductRecord();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Update");

            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            ResetFunction();

        }

        private void delete_Click(object sender, EventArgs e)
        {
            // Delete Button
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE Employee WHERE Emp_Id=@Emp_Id ", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                cmd.Parameters.AddWithValue("@Emp_Id", gunaTextBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                GetProductRecord();
                MessageBox.Show(" Data SuccessFully Deleted..");
                ResetFunction();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Delete");
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            //Search Button
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT Emp_Id,Employee_Name,Phone_No,Position,Remarks FROM Employee WHERE Emp_Id = '" + gunaTextBox6.Text + "' ", con);

            SqlDataReader DR1 = cmd.ExecuteReader();
            if (DR1.Read())
            {

                gunaTextBox1.Text = DR1[0].ToString();
                gunaTextBox2.Text = DR1[1].ToString();
                gunaTextBox3.Text = DR1[2].ToString();
                gunaTextBox4.Text = DR1[3].ToString();
                gunaTextBox5.Text = DR1[4].ToString();
                

            }
            con.Close();
        }

        private void NameSearch_Click(object sender, EventArgs e)
        {
            //Search Button in DataGridView
            int i = 0;
            con.Open();
            EmployeedataGridView.Rows.Clear();

            SqlCommand cmd = new SqlCommand("SELECT Emp_Id,Employee_Name,Phone_No,Position,Remarks FROM Employee WHERE Employee_Name = '" + gunaTextBox7.Text + "' ", con);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                EmployeedataGridView.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());

            }
            dr.Close();
            con.Close();

        }

        private void Employee_Load(object sender, EventArgs e)
        {
            GetProductRecord();
            ResetFunction();
            this.reportViewer1.RefreshReport();
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

        private void EmployeedataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Roll_No;
            //Cell Click in Data Grid View
            Roll_No = Convert.ToInt32(EmployeedataGridView.Rows[0].Cells[0].Value);
            gunaTextBox1.Text = EmployeedataGridView.SelectedRows[0].Cells[1].Value.ToString();
            gunaTextBox2.Text = EmployeedataGridView.SelectedRows[0].Cells[2].Value.ToString();
            gunaTextBox3.Text = EmployeedataGridView.SelectedRows[0].Cells[3].Value.ToString();
            gunaTextBox4.Text = EmployeedataGridView.SelectedRows[0].Cells[4].Value.ToString();
            gunaTextBox5.Text = EmployeedataGridView.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            //Load Report
            con.Open();
           // DateTime date1 = DateTime.Parse(gunaDateTimePicker3.Text);
            //DateTime date2 = DateTime.Parse(gunaDateTimePicker1.Text);
            SqlCommand cmd = new SqlCommand("SELECT Emp_Id,Employee_Name,Phone_No,Position,Remarks FROM Employee ", con);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("EmployeeDataSet", dt);
            reportViewer1.LocalReport.ReportPath = @"C:\Users\Risha\Desktop\IAST Details\4th Semester Dtls\DBMS\DBMS Project\Databaseproject\Databaseproject\Report\EmployeeReport.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
            con.Close();
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            // Refresh Button
            GetProductRecord();
            ResetFunction();
        }
    }
}
