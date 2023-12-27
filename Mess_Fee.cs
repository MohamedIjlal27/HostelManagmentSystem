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

namespace Databaseproject
{
	public partial class Mess_Fee : Form
	{
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        public Mess_Fee()
		{
			InitializeComponent();
            con = new SqlConnection(dbcon.connection());
        }

		private void HomeBtn_Click(object sender, EventArgs e)
		{
			Home_Page p=new Home_Page();
			p.Show();
			this.Hide();
		}

		private void MessBtn_Click(object sender, EventArgs e)
		{
			Mess mess = new Mess();
			mess.Show();
			this.Hide();
		}

        private void gunaTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Student_Name FROM Student_Attendance WHERE Std_Reg_No = '" + gunaTextBox1.Text + "' ", con);

                SqlDataReader DR1 = cmd.ExecuteReader();
                if (DR1.Read())
                {
                    gunaTextBox2.Text = DR1[0].ToString();                    

                }
                con.Close();
                SendKeys.Send("{TAB}");
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            //Save Button
            con.Open();

            cmd = new SqlCommand("INSERT INTO Mess_Fee(Month_Year,DateFrom,DateTo,Std_Reg_No,Student_Name,No_of_Days_Mess_Avail,Per_Day_Mess_Fee,Total_Fee)VALUES(@Month_Year,@DateFrom,@DateTo,@Std_Reg_No,@Student_Name,@No_of_Days_Mess_Avail,@Per_Day_Mess_Fee,@Total_Fee)", con);
            //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
            //    cmd.CommandType = CommandType.Text;
            //   cmd.Parameters.AddWithValue("@No#", int.Parse(this.Roll_No));
            cmd.Parameters.AddWithValue("@Month_Year", comboBox3.Text);
            cmd.Parameters.AddWithValue("@DateFrom", gunaDateTimePicker4.Value);
            cmd.Parameters.AddWithValue("@DateTo", gunaDateTimePicker5.Value);
            cmd.Parameters.AddWithValue("@Std_Reg_No", gunaTextBox1.Text);
            cmd.Parameters.AddWithValue("@Student_Name", gunaTextBox2.Text);
            cmd.Parameters.AddWithValue("@No_of_Days_Mess_Avail", gunaTextBox3.Text);
            cmd.Parameters.AddWithValue("@Per_Day_Mess_Fee", gunaTextBox4.Text);
            cmd.Parameters.AddWithValue("@Total_Fee", gunaTextBox5.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Data SuccessFully Saved..", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            GetStudentRecord();
            ResetFunction();
        }

        private void GetStudentRecord()
        {
            int i = 0;
            con.Open();
            MessFeedataGridView.Rows.Clear();
            SqlCommand cmd = new SqlCommand("SELECT Month_Year,DateFrom,DateTo,Std_Reg_No,Student_Name,No_of_Days_Mess_Avail,Per_Day_Mess_Fee,Total_Fee FROM Mess_Fee", con);
            //DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                i++;
                MessFeedataGridView.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());

            }
            dr.Close();
            con.Close();

        }

        private void update_Click(object sender, EventArgs e)
        {
            // Update Button
            try
            {
                //SqlConnection Con = new SqlConnection("Data Source=LAPTOP-0LKEO4VQ;Initial Catalog=Paf-iast(DBMS_Project);Persist Security Info=True;User ID=sa;Password=***********");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Mess_Fee SET DateFrom=@DateFrom,DateTo=@DateTo,Student_Name=@Student_Name,No_of_Days_Mess_Avail=@No_of_Days_Mess_Avail,Per_Day_Mess_Fee=@Per_Day_Mess_Fee,Total_Fee=@Total_Fee WHERE Std_Reg_No=@Std_Reg_No AND Month_Year=@Month_Year", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                //    cmd.Parameters.AddWithValue("@No#", int.Parse(this.Roll_No));
                cmd.Parameters.AddWithValue("@Month_Year", comboBox3.Text);
                cmd.Parameters.AddWithValue("@DateFrom", gunaDateTimePicker4.Value);
                cmd.Parameters.AddWithValue("@DateTo", gunaDateTimePicker5.Value);
                cmd.Parameters.AddWithValue("@Std_Reg_No", gunaTextBox1.Text);
                cmd.Parameters.AddWithValue("@Student_Name", gunaTextBox2.Text);
                cmd.Parameters.AddWithValue("@No_of_Days_Mess_Avail", gunaTextBox3.Text);
                cmd.Parameters.AddWithValue("@Per_Day_Mess_Fee", gunaTextBox4.Text);
                cmd.Parameters.AddWithValue("@Total_Fee", gunaTextBox4.Text);

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
        private void ResetFunction()
        {
            //Clear Function
            gunaTextBox1.Clear();
            gunaTextBox2.Clear();
            gunaTextBox3.Clear();
            gunaTextBox4.Clear();
            gunaTextBox5.Clear();
            gunaTextBox6.Clear();
            txtUsername.Clear();

            gunaTextBox1.Focus();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            //Clear Button
            ResetFunction();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            // Delete Button
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE Mess_Fee WHERE Std_Reg_No=@Std_Reg_No AND Month_Year=@Month_Year ", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                cmd.Parameters.AddWithValue("@Std_Reg_No", gunaTextBox1.Text);
                cmd.Parameters.AddWithValue("@Month_Year", comboBox3.Text);
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

        private void Search_Click(object sender, EventArgs e)
        {
            //Search 
            con.Open();
          
            SqlCommand cmd = new SqlCommand("SELECT Month_Year,Std_Reg_No, Student_Name,No_of_Days_Mess_Avail,Per_Day_Mess_Fee,Total_Fee FROM Mess_Fee WHERE Std_Reg_No = '" + txtUsername.Text + "' AND Month_Year ='" + comboBox1.Text + "' ", con);

            SqlDataReader DR1 = cmd.ExecuteReader();
            if (DR1.Read())
            {
                //  dateTimePicker1.Value = DR1[0].ToString();
                comboBox1.Text = DR1[0].ToString();

                gunaTextBox1.Text = DR1[1].ToString();
                gunaTextBox2.Text = DR1[2].ToString();
                gunaTextBox3.Text = DR1[3].ToString();
                gunaTextBox4.Text = DR1[4].ToString();
                gunaTextBox5.Text = DR1[5].ToString();
            }

            con.Close();
        }

        private void NameSearch_Click(object sender, EventArgs e)
        {
            //Search button in DataGridView
            try
            {
                int i = 0;
                con.Open();
                MessFeedataGridView.Rows.Clear();

                SqlCommand cmd = new SqlCommand("SELECT Month_Year,DateFrom,DateTo,Std_Reg_No,Student_Name,No_of_Days_Mess_Avail,Per_Day_Mess_Fee,Total_Fee FROM Mess_Fee WHERE Std_Reg_No = '" + gunaTextBox6.Text + "' AND Month_Year = '" + comboBox2.Text + "' ", con);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    MessFeedataGridView.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Invalid SELECTION OF SEARCH");
            }
            
        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            //Refresh Button
            gunaTextBox6.Clear();
            GetStudentRecord();
        }

        private void MessFeedataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Roll_No;
            //Cell Click in Data Grid View
            Roll_No = Convert.ToInt32(MessFeedataGridView.Rows[0].Cells[0].Value);
            comboBox3.Text= MessFeedataGridView.SelectedRows[0].Cells[1].Value.ToString();
            gunaTextBox1.Text = MessFeedataGridView.SelectedRows[0].Cells[4].Value.ToString();
            gunaTextBox2.Text = MessFeedataGridView.SelectedRows[0].Cells[5].Value.ToString();
            gunaTextBox3.Text = MessFeedataGridView.SelectedRows[0].Cells[6].Value.ToString();
            gunaTextBox4.Text = MessFeedataGridView.SelectedRows[0].Cells[7].Value.ToString();
            gunaTextBox5.Text = MessFeedataGridView.SelectedRows[0].Cells[8].Value.ToString();
          
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            //Search From Mess Fee Data Entry
            //Count the No of Days Availing Mess
            con.Open();
          //  MessFeedataGridView.Rows.Clear();
            DateTime date1 = DateTime.Parse(gunaDateTimePicker4.Text);
            DateTime date2 = DateTime.Parse(gunaDateTimePicker5.Text);
            SqlCommand cmd = new SqlCommand("SELECT SUM(Count) FROM Student_Attendance  WHERE Std_Reg_No = '" + gunaTextBox1.Text + "' AND Date BETWEEN '" + date1.ToString("MM/dd/yyyy") + "' AND '" + date2.ToString("MM/dd/yyyy") + "' ", con);
            
            
            int totalSum = Convert.ToInt32(cmd.ExecuteScalar());

            gunaTextBox3.Text = totalSum.ToString();
            SqlCommand cm = new SqlCommand("SELECT Per_Day_Amount FROM Mess_Expenditure_Calculation  WHERE Month_Year = '" + comboBox3.Text + "' ", con);
            SqlDataReader DR1 = cm.ExecuteReader();
            if (DR1.Read())
            {
                gunaTextBox4.Text = DR1[0].ToString();             
            }
            con.Close();
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            //Calculation Total Mess Fee Button
            int No_of_Days_Avail = Convert.ToInt32(gunaTextBox3.Text);
            int PerDayFee = Convert.ToInt32(gunaTextBox4.Text);
            int TotalFee = PerDayFee * No_of_Days_Avail;
            gunaTextBox5.Text = TotalFee.ToString();

        }

        private void Mess_Fee_Load(object sender, EventArgs e)
        {
            GetStudentRecord();
            ResetFunction();
            this.reportViewer1.RefreshReport();
            
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            //Load Voucher Button
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Month_Year,DateFrom,DateTo,Std_Reg_No,Student_Name,No_of_Days_Mess_Avail,Per_Day_Mess_Fee,Total_Fee FROM Mess_Fee WHERE Std_Reg_No = '" + gunaTextBox6.Text + "' AND Month_Year = '"+ comboBox2.Text+ "' ", con);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("MessFeeDataSet", dt);
            reportViewer1.LocalReport.ReportPath = @"C:\Users\Risha\Desktop\IAST Details\4th Semester Dtls\DBMS\DBMS Project\Databaseproject\Databaseproject\Report\MessFeeReport.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
            con.Close();
        }
    }
}
