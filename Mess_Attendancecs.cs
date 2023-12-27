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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Reporting.WinForms;

namespace Databaseproject
{
	public partial class Mess_Attendancecs : Form
	{
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        //int Pr;
        public Mess_Attendancecs()
		{
			InitializeComponent();
            con = new SqlConnection(dbcon.connection());
        }

		private void MessBtn_Click(object sender, EventArgs e)
		{
			Mess m =new Mess();
			m.Show();
			this.Hide();
		}

		private void HomeBtn_Click(object sender, EventArgs e)
		{
			Home_Page h=new Home_Page();
			h.Show();
			this.Hide();
		}

        private void b1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            // Save Button
            /*
            try
            {
                
                int Pr;
                cmd = new SqlCommand("INSERT INTO Student_Attendance(Date, Std_Reg_No,Student_Name,Room_No, Breakfast, Lunch, Dinner, Count)VALUES(@Date, @Std_Reg_No, @Student_Name, @Room_No, @Breakfast, @Lunch, @Dinner,@Count)", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                cmd.CommandType = CommandType.Text;
                //   cmd.Parameters.AddWithValue("@No#", int.Parse(this.Roll_No));
                cmd.Parameters.AddWithValue("@Date", gunaDateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@Std_Reg_No", gunaTextBox1.Text);
                cmd.Parameters.AddWithValue("@Student_Name", gunaTextBox2.Text);
                cmd.Parameters.AddWithValue("@Room_No", gunaTextBox3.Text);
                con.Open();
                if (gunaRadioButton1.Checked == true)
                {
                    Pr = 1;
                    cmd.Parameters.AddWithValue("@Breakfast", "P");
                }
                else
                {
                    Pr = 0;
                    cmd.Parameters.AddWithValue("@Breakfast", "N/A");
                }

                if (gunaRadioButton3.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Lunch", "P");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Lunch", "N/A");
                }

                if (gunaRadioButton5.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Dinner", "P");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Dinner", "N/A");
                }
                cmd.Parameters.AddWithValue("@Count", Pr);

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show(" Data SuccessFully Saved..", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetStudentRecord();
            }  catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }  */

            
                try
                {
                    int Pr = 0;
                    string breakfastValue = "N/A";
                    string lunchValue = "N/A";
                    string dinnerValue = "N/A";

                    if (gunaRadioButton1.Checked)
                    {
                        Pr = 1;
                        breakfastValue = "P";
                    }

                    if (gunaRadioButton3.Checked)
                    {
                        lunchValue = "P";
                    }

                    if (gunaRadioButton5.Checked)
                    {
                        dinnerValue = "P";
                    }

                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-0LKEO4VQ;Initial Catalog=Paf-iast(DBMS_Project);Persist Security Info=True;User ID=sa;Password=12345"))
                {

                    SqlCommand command = new SqlCommand("INSERT INTO Student_Attendance (Date, Std_Reg_No, Student_Name, Room_No, Breakfast, Lunch, Dinner, Count) VALUES (@Date, @Std_Reg_No, @Student_Name, @Room_No, @Breakfast, @Lunch, @Dinner, @Count)", conn);
                    command.Parameters.AddWithValue("@Date", gunaDateTimePicker2.Value);
                    command.Parameters.AddWithValue("@Std_Reg_No", gunaTextBox1.Text);
                    command.Parameters.AddWithValue("@Student_Name", gunaTextBox2.Text);
                    command.Parameters.AddWithValue("@Room_No", gunaTextBox3.Text);
                    command.Parameters.AddWithValue("@Breakfast", breakfastValue);
                    command.Parameters.AddWithValue("@Lunch", lunchValue);
                    command.Parameters.AddWithValue("@Dinner", dinnerValue);
                    command.Parameters.AddWithValue("@Count", Pr);

                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();

                }
                    MessageBox.Show("Data Successfully Saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetStudentRecord();
                    
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }
            


        }

        private void GetStudentRecord()
        {
         
            int i = 0;
            con.Open();
            StdAttendancedataGridView.Rows.Clear();
            SqlCommand cmd = new SqlCommand("SELECT Date, Std_Reg_No,Student_Name,Room_No, Breakfast, Lunch, Dinner FROM Student_Attendance", con);
            //DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                i++;
                StdAttendancedataGridView.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());

            }
            dr.Close();
            con.Close();

        }

        private void update_Click(object sender, EventArgs e)
        {
            // Update Button
            try
            {
                int Pr;
                //SqlConnection Con = new SqlConnection("Data Source=LAPTOP-0LKEO4VQ;Initial Catalog=Paf-iast(DBMS_Project);Persist Security Info=True;User ID=sa;Password=***********");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Student_Attendance SET Date=@Date,Student_Name=@Student_Name,Room_No=@Room_No, Breakfast=@Breakfast, Lunch=@Lunch, Dinner=@Dinner WHERE Std_Reg_No=@Std_Reg_No ", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                //    cmd.Parameters.AddWithValue("@No#", int.Parse(this.Roll_No));
                cmd.Parameters.AddWithValue("@Date", gunaDateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@Std_Reg_No", gunaTextBox1.Text);
                cmd.Parameters.AddWithValue("@Student_Name", gunaTextBox2.Text);
                cmd.Parameters.AddWithValue("@Room_No", gunaTextBox3.Text);
                if (gunaRadioButton1.Checked == true)
                {
                    Pr = 1;
                    cmd.Parameters.AddWithValue("@Breakfast", "P");
                }
                else
                {
                    Pr = 0;
                    cmd.Parameters.AddWithValue("@Breakfast", "N/A");
                }

                if (gunaRadioButton3.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Lunch", "P");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Lunch", "N/A");
                }

                if (gunaRadioButton5.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Dinner", "P");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Dinner", "N/A");
                }
                cmd.Parameters.AddWithValue("@Count", Pr);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Data SuccessFully Updated..");
                con.Close();
                GetStudentRecord();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Update");

            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            //Clear Button
            ResetFunction();
        }

        private void ResetFunction()
        {
            // Clear Button
            //   object value = dateTimePicker1.Clear();
            gunaTextBox1.Clear();
            gunaTextBox2.Clear();
            gunaTextBox3.Clear();

            txtRegNo.Clear();
            if (gunaRadioButton1.Checked)
            {
                gunaRadioButton1.Checked = false;
            }
            if (gunaRadioButton2.Checked)
            {
                gunaRadioButton2.Checked = false;
            }
            if (gunaRadioButton3.Checked)
            {
                gunaRadioButton3.Checked = false;
            }
            if (gunaRadioButton4.Checked)
            {
                gunaRadioButton4.Checked = false;
            }
            if (gunaRadioButton5.Checked)
            {
                gunaRadioButton5.Checked = false;
            }
            if (gunaRadioButton6.Checked)
            {
                gunaRadioButton6.Checked = false;
            }

            gunaTextBox1.Focus();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            //Delete Button
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Student_Attendance WHERE Std_Reg_No=@Std_Reg_No ", con);
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

        private void StdAttendancedataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //StdAttendancedataGridView
            //Cell Click in Data Grid View
            //Roll_No = Convert.ToInt32(StudentDBRecordGridView.Rows[0].Cells[0].Value);
            // dateTimePicker1.Text = StdAttendancedataGridView.SelectedRows[0].Cells[0].Value.ToString();
            gunaTextBox1.Text = StdAttendancedataGridView.SelectedRows[0].Cells[2].Value.ToString();
            gunaTextBox2.Text = StdAttendancedataGridView.SelectedRows[0].Cells[3].Value.ToString();
            gunaTextBox3.Text = StdAttendancedataGridView.SelectedRows[0].Cells[4].Value.ToString();

            string Breakfast = StdAttendancedataGridView.SelectedRows[0].Cells[5].Value.ToString();
            string Lunch = StdAttendancedataGridView.SelectedRows[0].Cells[6].Value.ToString();
            string Dinner = StdAttendancedataGridView.SelectedRows[0].Cells[7].Value.ToString();

            // Assign the value to the radio button based on your condition
            if (Breakfast != "[P] - Present")
            {
                gunaRadioButton1.Checked = true;
            }
            else
            {
                gunaRadioButton2.Checked = true;
            }
            if (Lunch != "[P] - Present")
            {
                gunaRadioButton3.Checked = true;
            }
            else
            {
                gunaRadioButton4.Checked = true;
            }
            if (Dinner != "[P] - Present")
            {
                gunaRadioButton5.Checked = true;
            }
            else
            {
                gunaRadioButton6.Checked = true;
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            // Search Button in TextView


            con.Open();
            DateTime date1 = DateTime.Parse(gunaDateTimePicker4.Text);
            SqlCommand cmd = new SqlCommand("SELECT Date, Std_Reg_No,Student_Name,Room_No, Breakfast, Lunch, Dinner FROM Student_Attendance WHERE Std_Reg_No ='" + txtRegNo.Text + "' AND Date = '" + date1.ToString("MM/dd/yyyy") + "' ", con);

            SqlDataReader DR1 = cmd.ExecuteReader();
            if (DR1.Read())
            {

                //    dateTimePicker1.Value = DR1[0].ToString();
                gunaTextBox1.Text = DR1[1].ToString();
                gunaTextBox2.Text = DR1[2].ToString();
                gunaTextBox3.Text = DR1[3].ToString();
                string Breakfast = DR1["Breakfast"].ToString();
                string Lunch = DR1["Lunch"].ToString();
                string Dinner = DR1["Dinner"].ToString();

                // Assign the value to the radio button based on your condition
                if (Breakfast != "[P] - Present")
                {
                    gunaRadioButton1.Checked = true;
                }
                else
                {
                    gunaRadioButton2.Checked = true;
                }
                if (Lunch != "[P] - Present")
                {
                    gunaRadioButton3.Checked = true;
                }
                else
                {
                    gunaRadioButton4.Checked = true;
                }
                if (Dinner != "[P] - Present")
                {
                    gunaRadioButton5.Checked = true;
                }
                else
                {
                    gunaRadioButton6.Checked = true;
                }


            }
            con.Close();
        }

        private void NameSearch_Click(object sender, EventArgs e)
        {
            // Search Button in DataGridView
            CalculateUniqueCharacterSum();
            int i = 0;
            con.Open();
            StdAttendancedataGridView.Rows.Clear();
            DateTime date1 = DateTime.Parse(gunaDateTimePicker3.Text);
            DateTime date2 = DateTime.Parse(gunaDateTimePicker1.Text);
            SqlCommand cmd = new SqlCommand("SELECT Date, Std_Reg_No,Student_Name,Room_No, Breakfast, Lunch, Dinner FROM Student_Attendance WHERE Std_Reg_No = '" + gunaTextBox5.Text + "' AND Date BETWEEN '" + date1.ToString("MM/dd/yyyy") + "' AND '" + date2.ToString("MM/dd/yyyy") + "' ORDER BY Date ASC ", con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                i++;
                StdAttendancedataGridView.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());

            }
            dr.Close();
            con.Close();
            
        }

        private void CalculateUniqueCharacterSum()
        {
            //Count the No of Days Availing Mess
            con.Open();
            StdAttendancedataGridView.Rows.Clear();
            DateTime date1 = DateTime.Parse(gunaDateTimePicker3.Text);
            DateTime date2 = DateTime.Parse(gunaDateTimePicker1.Text);
            SqlCommand cmd = new SqlCommand("SELECT SUM(Count) FROM Student_Attendance  WHERE Std_Reg_No = '" + gunaTextBox5.Text + "' AND Date BETWEEN '" + date1.ToString("MM/dd/yyyy") + "' AND '" + date2.ToString("MM/dd/yyyy") + "' ", con);

            int totalSum = Convert.ToInt32(cmd.ExecuteScalar());

            NoOfDays.Text = totalSum.ToString();

            con.Close();

        }

        private void gunaTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Student_Name,Room_No FROM Room_Allotments WHERE Std_Reg_No = '" + gunaTextBox1.Text + "' ", con);

                SqlDataReader DR1 = cmd.ExecuteReader();
                if (DR1.Read())
                {
                    gunaTextBox2.Text = DR1[0].ToString();
                    gunaTextBox3.Text = DR1[1].ToString();

                }
                else
                    con.Close();

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

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            GetStudentRecord();
            gunaTextBox5.Clear();
        }

        private void Mess_Attendancecs_Load(object sender, EventArgs e)
        {
            GetStudentRecord();
            ResetFunction();
            this.reportViewer1.RefreshReport();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.StdAttendancedataGridView.Width, this.StdAttendancedataGridView.Height);
            StdAttendancedataGridView.DrawToBitmap(bm, new Rectangle(4, 0, this.StdAttendancedataGridView.Width, this.StdAttendancedataGridView.Height));
            e.Graphics.DrawImage(bm, 4, 0);
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            //Load Report
            con.Open();
            DateTime date1 = DateTime.Parse(gunaDateTimePicker3.Text);
            DateTime date2 = DateTime.Parse(gunaDateTimePicker1.Text);
            SqlCommand cmd = new SqlCommand("SELECT Date, Std_Reg_No,Student_Name,Room_No, Breakfast, Lunch, Dinner FROM Student_Attendance WHERE Std_Reg_No = '" + gunaTextBox5.Text + "' AND Date BETWEEN '" + date1.ToString("MM/dd/yyyy") + "' AND '" + date2.ToString("MM/dd/yyyy") + "' ORDER BY Date ASC ", con);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("MessAttendanceDataSet", dt);
            reportViewer1.LocalReport.ReportPath = @"C:\Users\Risha\Desktop\IAST Details\4th Semester Dtls\DBMS\DBMS Project\Databaseproject\Databaseproject\Report\MessAttendanceReport.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
            con.Close();

        }
    }
}
