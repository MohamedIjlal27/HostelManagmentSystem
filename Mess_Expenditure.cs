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
	public partial class Mess_Expenditure : Form
	{
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        public Mess_Expenditure()
		{
			InitializeComponent();
            con = new SqlConnection(dbcon.connection());
        }

		private void MessBtn_Click(object sender, EventArgs e)
		{
			Mess m=new Mess();
			m.Show();
			this.Hide();
		}

		private void HomeBtn_Click(object sender, EventArgs e)
		{
			Home_Page h=new Home_Page();
			h.Show();
			this.Hide();
		}

		private void txtUsername_TextChanged(object sender, EventArgs e)
		{

		}

        private void saveBtn_Click(object sender, EventArgs e)
        {
            // Save Button
            try
            {
                //SqlConnection Con = new SqlConnection("Data Source=LAPTOP-0LKEO4VQ;Initial Catalog=Paf-iast(DBMS_Project);Persist Security Info=True;User ID=sa;Password=12345");

                con.Open();

                cmd = new SqlCommand("INSERT INTO Mess_Expenditure(Month_Year,Date,Description,Bill_Amount)VALUES(@Month_Year,@Date, @Description, @Bill_Amount)", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                //    cmd.CommandType = CommandType.Text;
                //   cmd.Parameters.AddWithValue("@No#", int.Parse(this.Roll_No));
                cmd.Parameters.AddWithValue("@Month_Year", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Date", gunaDateTimePicker4.Value);
                cmd.Parameters.AddWithValue("@Description", gunaTextBox1.Text);
                cmd.Parameters.AddWithValue("@Bill_Amount", gunaTextBox2.Text);



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
            MessExpenditureDBRecordGridView.Rows.Clear();
            SqlCommand cmd = new SqlCommand("SELECT Month_Year,Date,Description,Bill_Amount FROM Mess_Expenditure", con);
            //DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                i++;
                MessExpenditureDBRecordGridView.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());

            }
            dr.Close();
            con.Close();

        }

        private void SearchBtn2_Click(object sender, EventArgs e)
        {
            //Search Button In GridView
            int i = 0;
            con.Open();
            MessExpenditureDBRecordGridView.Rows.Clear();
            DateTime date1 = DateTime.Parse(gunaDateTimePicker3.Text);
            DateTime date2 = DateTime.Parse(gunaDateTimePicker5.Text);
            SqlCommand cmd = new SqlCommand("SELECT Month_Year,Date,Description,Bill_Amount FROM Mess_Expenditure WHERE Month_Year = '" + comboBox2.Text + "' AND Date BETWEEN '" + date1.ToString("MM/dd/yyyy") + "' AND '" + date2.ToString("MM/dd/yyyy") + "' ", con);
            SqlCommand cm = new SqlCommand("SELECT SUM(Bill_Amount) AS TotalSum FROM Mess_Expenditure WHERE Month_Year = '" + comboBox2.Text + "' AND Date BETWEEN '" + date1.ToString("MM/dd/yyyy") + "' AND '" + date2.ToString("MM/dd/yyyy") + "' ", con);
            int totalBillAmount = Convert.ToInt32(cm.ExecuteScalar());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                MessExpenditureDBRecordGridView.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            gunaTextBox7.Text = totalBillAmount.ToString();

            dr.Close();
            con.Close();
        }
 
        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            //Refresh Button
            GetStudentRecord();
            ResetFunction();
            gunaTextBox7.Clear();

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            // Save Button in Calculation Table
            try
            {
                con.Open();

                cmd = new SqlCommand("INSERT INTO Mess_Expenditure_Calculation(Date,Month_Year,Availing_Students,No_of_Days_in_a_Month,Per_Month_Amount,Per_Day_Amount)VALUES(@Date,@Month_Year,@Availing_Students,@No_of_Days_in_a_Month,@Per_Month_Amount,@Per_Day_Amount)", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                //    cmd.CommandType = CommandType.Text;
                //   cmd.Parameters.AddWithValue("@No#", int.Parse(this.Roll_No));
                cmd.Parameters.AddWithValue("@Date", gunaDateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Month_Year", comboBox3.Text);
                cmd.Parameters.AddWithValue("@Availing_Students", gunaTextBox3.Text);
                cmd.Parameters.AddWithValue("@No_of_Days_in_a_Month", gunaTextBox4.Text);
                cmd.Parameters.AddWithValue("@Per_Month_Amount", gunaTextBox5.Text);
                cmd.Parameters.AddWithValue("@Per_Day_Amount", gunaTextBox6.Text);


                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(" Data SuccessFully Saved..", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetStudentRecord2NW();
                ResetFunction2Nw();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Saved");


            }
        }
        private void GetStudentRecord2NW()
        {
            int i = 0;
            con.Open();
            MessExCalculationDBRecordGridView.Rows.Clear();
            SqlCommand cmd = new SqlCommand("SELECT Month_Year,Availing_Students,No_of_Days_in_a_Month,Per_Month_Amount,Per_Day_Amount FROM Mess_Expenditure_Calculation", con);
            //DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                i++;
                MessExCalculationDBRecordGridView.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());

            }
            dr.Close();
            con.Close();

        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            // Update Button in Calculation Table
            try
            {
                //SqlConnection Con = new SqlConnection("Data Source=LAPTOP-0LKEO4VQ;Initial Catalog=Paf-iast(DBMS_Project);Persist Security Info=True;User ID=sa;Password=***********");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Mess_Expenditure_Calculation SET Availing_Students=@Availing_Students, No_of_Days_in_a_Month=@No_of_Days_in_a_Month,Per_Month_Amount=@Per_Month_Amount, Per_Day_Amount=@Per_Day_Amount WHERE Month_Year=@Month_Year AND Date=@Date ", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                //    cmd.Parameters.AddWithValue("@No#", int.Parse(this.Roll_No));
                cmd.Parameters.AddWithValue("@Date", gunaDateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Month_Year", comboBox3.Text);
                cmd.Parameters.AddWithValue("@Availing_Students", gunaTextBox3.Text);
                cmd.Parameters.AddWithValue("@No_of_Days_in_a_Month", gunaTextBox4.Text);
                cmd.Parameters.AddWithValue("@Per_Month_Amount", gunaTextBox5.Text);
                cmd.Parameters.AddWithValue("@Per_Day_Amount", gunaTextBox6.Text);


                cmd.ExecuteNonQuery();
                MessageBox.Show(" Data SuccessFully Updated..");
                con.Close();
                GetStudentRecord2NW();
                ResetFunction2Nw();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Update");

            }

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            // Update Button
            try
            {
                //SqlConnection Con = new SqlConnection("Data Source=LAPTOP-0LKEO4VQ;Initial Catalog=Paf-iast(DBMS_Project);Persist Security Info=True;User ID=sa;Password=***********");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Mess_Expenditure SET Date=@Date, Description=@Description,  Month_Year=@Month_Year,Bill_Amount=@Bill_Amount Where Date=@Date  AND Description=@Description ", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                //    cmd.Parameters.AddWithValue("@No#", int.Parse(this.Roll_No));
                cmd.Parameters.AddWithValue("@Month_Year", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Date", gunaDateTimePicker4.Value);
                cmd.Parameters.AddWithValue("@Description", gunaTextBox1.Text);
                cmd.Parameters.AddWithValue("@Bill_Amount", gunaTextBox2.Text);



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
            // Clear Function
            gunaTextBox1.Clear();
            gunaTextBox2.Clear();
            txtDescription.Clear();
            gunaTextBox7.Clear();

            comboBox1.Focus();            
        }
            private void clearBtn_Click(object sender, EventArgs e)
        {
            // Clear Button
            ResetFunction();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            //Delete Button
        /*    try
            {  */
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE Mess_Expenditure WHERE Description=@Description AND Date=@Date ", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                cmd.Parameters.AddWithValue("@Description", gunaTextBox1.Text);
                cmd.Parameters.AddWithValue("@Date", gunaDateTimePicker4.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentRecord();
                MessageBox.Show(" Data SuccessFully Deleted..");
                ResetFunction();

       /*    }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Delete");
            }*/
        }

        private void SearchBtn1_Click(object sender, EventArgs e)
        {
            //Search Button

            con.Open();
            String Desc = txtDescription.Text;
            DateTime date1 = DateTime.Parse(gunaDateTimePicker2.Text);

            SqlCommand cmd = new SqlCommand("SELECT Month_Year,Description,Bill_Amount FROM Mess_Expenditure WHERE Date = '" + date1.ToString("MM/dd/yyyy") + "' AND Description ='" + Desc + "'   ", con);

            SqlDataReader DR1 = cmd.ExecuteReader();
            if (DR1.Read())
            {
                //  dateTimePicker1.Value = DR1[0].ToString();
                comboBox1.Text = DR1[0].ToString();

                gunaTextBox1.Text = DR1[1].ToString();
                gunaTextBox2.Text = DR1[2].ToString();
            }
         
            con.Close();
        }
        private void ResetFunction2Nw()
        {
            // Clear Function
            gunaTextBox3.Clear();
            gunaTextBox4.Clear();
            gunaTextBox5.Clear();
            gunaTextBox6.Clear();
            gunaTextBox8.Clear();

            comboBox3.Focus();
        }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            //Clear Button in Calculation Table
            ResetFunction2Nw();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            //Delete Button in Calculation Table
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE Mess_Expenditure_Calculation WHERE Month_Year=@Month_Year AND Date=@Date ", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                cmd.Parameters.AddWithValue("@Month_Year", comboBox3.Text);
                cmd.Parameters.AddWithValue("@Date", gunaDateTimePicker1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentRecord2NW();
                MessageBox.Show(" Data SuccessFully Deleted..");
                ResetFunction2Nw();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Delete");
            }

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            // Find in Calculate Table to Calculate No of Sttudents Availing Mess
            DateTime date1 = DateTime.Parse(gunaDateTimePicker6.Text);
            DateTime date2 = DateTime.Parse(gunaDateTimePicker7.Text);

            SqlCommand cmd = new SqlCommand("SELECT  COUNT(DISTINCT Student_Name) AS DistinctCount FROM Student_Attendance WHERE Date BETWEEN '" + date1.ToString("MM/dd/yyyy") + "' AND '" + date2.ToString("MM/dd/yyyy") + "' ", con);
            con.Open();
            int studentCount = (int)cmd.ExecuteScalar();
            gunaTextBox8.Text = studentCount.ToString();
            con.Close();
        }

        private void Mess_Expenditure_Load(object sender, EventArgs e)
        {
            GetStudentRecord();
            GetStudentRecord2NW();
            ResetFunction2Nw();
            ResetFunction();

            this.reportViewer1.RefreshReport();
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
            /* 
             //Enter press After No of Days in a Month
            // Find in Calculate Table to Calculate Permonth Amount
            if (e.KeyCode == Keys.Enter)
            {
                DateTime date1 = DateTime.Parse(gunaDateTimePicker6.Text);
                DateTime date2 = DateTime.Parse(gunaDateTimePicker7.Text);

                SqlCommand cmd = new SqlCommand("SELECT SUM(Bill_Amount) AS Bill_Amount FROM Mess_Expenditure WHERE Date BETWEEN '" + date1.ToString("MM/dd/yyyy") + "' AND '" + date2.ToString("MM/dd/yyyy") + "' ", con);
                con.Open();
                int totalSum = Convert.ToInt32(cmd.ExecuteScalar());
                //   int studentCount = (int)cmd.ExecuteScalar();
                int Student = Convert.ToInt32(gunaTextBox3.Text);
                int Month_Amount = totalSum / Student;
                gunaTextBox5.Text = Month_Amount.ToString();
                con.Close();
                SendKeys.Send("{TAB}");
            }

            
            */
            //"SELECT SUM(YourColumnName) AS TotalSum FROM YourTableName"

            if (e.KeyCode == Keys.Enter)
            {
                DateTime date1 = DateTime.Parse(gunaDateTimePicker6.Text);
                DateTime date2 = DateTime.Parse(gunaDateTimePicker7.Text);

                
                    SqlCommand cmd = new SqlCommand("SELECT SUM(Bill_Amount) AS TotalSum FROM Mess_Expenditure WHERE Date >= @StartDate AND Date <= @EndDate AND Month_Year = '" + comboBox3.Text + "'", con);
                    cmd.Parameters.AddWithValue("@StartDate", date1);
                    cmd.Parameters.AddWithValue("@EndDate", date2);

                    con.Open();
                    int totalSum = Convert.ToInt32(cmd.ExecuteScalar());

                    int studentCount = Convert.ToInt32(gunaTextBox3.Text);
                    int monthAmount = totalSum / studentCount;
                    gunaTextBox5.Text = monthAmount.ToString();

                    con.Close();
                

                SendKeys.Send("{TAB}");
            }
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            //Calculate Per Day Amount
            int Month_Days = Convert.ToInt32(gunaTextBox4.Text);
            int Month_Amount = Convert.ToInt32(gunaTextBox5.Text); 
            int Per_Day_Amount = Month_Amount / Month_Days;
            gunaTextBox6.Text = Per_Day_Amount.ToString();

        }

        private void MessExpenditureDBRecordGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Cell Click From DataGridView
            comboBox1.Text = MessExpenditureDBRecordGridView.SelectedRows[0].Cells[1].Value.ToString();
            gunaTextBox1.Text = MessExpenditureDBRecordGridView.SelectedRows[0].Cells[3].Value.ToString();
            gunaTextBox2.Text = MessExpenditureDBRecordGridView.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void MessExCalculationDBRecordGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Expenditure Calculation Table Cell Click
            comboBox3.Text = MessExCalculationDBRecordGridView.SelectedRows[0].Cells[1].Value.ToString();
            gunaTextBox3.Text = MessExCalculationDBRecordGridView.SelectedRows[0].Cells[2].Value.ToString();
            gunaTextBox4.Text = MessExCalculationDBRecordGridView.SelectedRows[0].Cells[3].Value.ToString();
            gunaTextBox5.Text = MessExCalculationDBRecordGridView.SelectedRows[0].Cells[4].Value.ToString();
            gunaTextBox6.Text = MessExCalculationDBRecordGridView.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            //Load Report
            con.Open();
            DateTime date1 = DateTime.Parse(gunaDateTimePicker3.Text);
            DateTime date2 = DateTime.Parse(gunaDateTimePicker1.Text);
            SqlCommand cmd = new SqlCommand("SELECT Month_Year,Date,Description,Bill_Amount FROM Mess_Expenditure WHERE Month_Year = '" + comboBox2.Text + "' AND Date BETWEEN '" + date1.ToString("MM/dd/yyyy") + "' AND '" + date2.ToString("MM/dd/yyyy") + "'", con);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("MessExpDataSet", dt);
            reportViewer1.LocalReport.ReportPath = @"C:\Users\Risha\Desktop\IAST Details\4th Semester Dtls\DBMS\DBMS Project\Databaseproject\Databaseproject\Report\MessExpenditureReport.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
            con.Close();
        }
    }
}
