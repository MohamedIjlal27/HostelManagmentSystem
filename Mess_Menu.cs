using Guna.UI.WinForms;
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
	public partial class Mess_Menu : Form
	{
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        public Mess_Menu()
		{
			InitializeComponent();
            con = new SqlConnection(dbcon.connection());
        }

		private void StudentBtn_Click(object sender, EventArgs e)
		{
			Mess m=new Mess();
			m.Show();
			this.Hide();
		}

		private void HomeBtn_Click(object sender, EventArgs e)
		{
			Home_Page h =new Home_Page();
			h.Show();
			this.Hide();
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

        private void save_Click(object sender, EventArgs e)
        {
            //Save Button
            try
            {               
                con.Open();

                cmd = new SqlCommand("INSERT INTO Messing_Menu(Date,Month, Day, Breakfast, Lunch,Brunch, Dinner)VALUES(@Date, @Month,@Day,@Breakfast, @Lunch, @Brunch, @Dinner)", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                //    cmd.CommandType = CommandType.Text;
                //   cmd.Parameters.AddWithValue("@No#", int.Parse(this.Roll_No));
                cmd.Parameters.AddWithValue("@Date", gunaDateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@Month", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Day", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Breakfast", gunaTextBox1.Text);
                cmd.Parameters.AddWithValue("@Lunch", gunaTextBox2.Text);
                cmd.Parameters.AddWithValue("@Brunch", gunaTextBox3.Text);
                cmd.Parameters.AddWithValue("@Dinner", gunaTextBox4.Text);


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
            MessMenuDBRecordGridView.Rows.Clear();
            cmd = new SqlCommand("SELECT Month, Day, Breakfast, Lunch, Brunch, Dinner FROM Messing_Menu ORDER BY Date", con);
            //DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                i++;
                MessMenuDBRecordGridView.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());

            }
            dr.Close();
            con.Close();

        }

        private void clear_Click(object sender, EventArgs e)
        {
            //Clear Button
            ResetFunction();
        }

        private void ResetFunction()
        {
            //Clear

            gunaTextBox1.Clear();
            gunaTextBox2.Clear();
            gunaTextBox3.Clear();
            gunaTextBox4.Clear();
                   

            gunaTextBox1.Focus();
        }

        private void update_Click(object sender, EventArgs e)
        {
            // Update Button
            try
            {
                //SqlConnection Con = new SqlConnection("Data Source=LAPTOP-0LKEO4VQ;Initial Catalog=Paf-iast(DBMS_Project);Persist Security Info=True;User ID=sa;Password=***********");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Messing_Menu SET  Month=@Month, Breakfast=@Breakfast, Lunch=@Lunch, Brunch=@Brunch, Dinner=@Dinner WHERE Date=@Date AND Day=@Day ", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                //    cmd.Parameters.AddWithValue("@No#", int.Parse(this.Roll_No));
                cmd.Parameters.AddWithValue("@Date", gunaDateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@Month", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Day", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Breakfast", gunaTextBox1.Text);
                cmd.Parameters.AddWithValue("@Lunch", gunaTextBox2.Text);
                cmd.Parameters.AddWithValue("@Brunch", gunaTextBox3.Text);
                cmd.Parameters.AddWithValue("@Dinner", gunaTextBox4.Text);


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

        private void delete_Click(object sender, EventArgs e)
        {
            //Delete Button
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Messing_Menu WHERE Day=@Day ", con);
            //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
           // cmd.Parameters.AddWithValue("@Date", gunaDateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@Day", comboBox2.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show(" Data SuccessFully Deleted..");
            ResetFunction();
            GetStudentRecord();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void gunaDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            // Refresh
            GetStudentRecord();
        }

        private void NameSearch_Click(object sender, EventArgs e)
        {
            //Search button of the GridView
            int i = 0;
            con.Open();
            MessMenuDBRecordGridView.Rows.Clear();
            DateTime date1 = DateTime.Parse(gunaDateTimePicker3.Text);
            DateTime date2 = DateTime.Parse(gunaDateTimePicker1.Text);
            SqlCommand cmd = new SqlCommand("SELECT Month, Day, Breakfast, Lunch, Brunch, Dinner FROM Messing_Menu WHERE Month='" + comboBox3.Text + "' AND Date BETWEEN '" + date1.ToString("MM/dd/yyyy") + "' AND '" + date2.ToString("MM/dd/yyyy") + "' ORDER BY Date ASC ", con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                i++;
                MessMenuDBRecordGridView.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());

            }
            dr.Close();
            con.Close();
        }

        private void MessMenuDBRecordGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessMenuDBRecordGridView
            //Cell Click in Data Grid View
            int Roll_No;
            Roll_No = Convert.ToInt32(MessMenuDBRecordGridView.Rows[0].Cells[0].Value);
            comboBox1.Text = MessMenuDBRecordGridView.SelectedRows[0].Cells[1].Value.ToString();
            comboBox2.Text = MessMenuDBRecordGridView.SelectedRows[0].Cells[2].Value.ToString();

            gunaTextBox1.Text = MessMenuDBRecordGridView.SelectedRows[0].Cells[3].Value.ToString();
            gunaTextBox2.Text = MessMenuDBRecordGridView.SelectedRows[0].Cells[4].Value.ToString();
            gunaTextBox3.Text = MessMenuDBRecordGridView.SelectedRows[0].Cells[5].Value.ToString();
            gunaTextBox4.Text = MessMenuDBRecordGridView.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void Mess_Menu_Load(object sender, EventArgs e)
        {
            GetStudentRecord();
            ResetFunction();
            this.reportViewer1.RefreshReport();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            //Load Report
            con.Open();
            DateTime date1 = DateTime.Parse(gunaDateTimePicker3.Text);
            DateTime date2 = DateTime.Parse(gunaDateTimePicker1.Text);
            SqlCommand cmd = new SqlCommand("SELECT Day, Breakfast, Lunch, Brunch, Dinner FROM Messing_Menu WHERE Month='" + comboBox3.Text + "' AND Date BETWEEN '" + date1.ToString("MM/dd/yyyy") + "' AND '" + date2.ToString("MM/dd/yyyy") + "' ORDER BY Date ASC ", con);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("MessMenuDataSet", dt);
            reportViewer1.LocalReport.ReportPath = @"C:\Users\Risha\Desktop\IAST Details\4th Semester Dtls\DBMS\DBMS Project\Databaseproject\Databaseproject\Report\MessMenuReport.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
            con.Close();
        }
    }
}
