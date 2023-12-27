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
	public partial class Hostel_Inventory : Form
	{
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        public Hostel_Inventory()
		{
			InitializeComponent();
            con = new SqlConnection(dbcon.connection());
        }

		private void HomeBtn_Click(object sender, EventArgs e)
		{
			Home_Page home= new Home_Page();
			home.Show();
			this.Hide();
		}

        private void save_Click(object sender, EventArgs e)
        {
            //Save Button
            try
            {
                con.Open();

                cmd = new SqlCommand("INSERT INTO Product(Product_ID,Date,Item_Name,Stock_Recieved,Stock_Issued,Balance,Remarks)VALUES(@Product_ID,@Date,@Item_Name,@Stock_Recieved,@Stock_Issued,@Balance,@Remarks)", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                //    cmd.CommandType = CommandType.Text;
                //   cmd.Parameters.AddWithValue("@No#", int.Parse(this.Roll_No));
                cmd.Parameters.AddWithValue("@Product_ID", gunaTextBox1.Text);
                cmd.Parameters.AddWithValue("@Date", gunaDateTimePicker3.Value);
                cmd.Parameters.AddWithValue("@Item_Name", gunaTextBox02.Text);
                cmd.Parameters.AddWithValue("@Stock_Recieved", gunaTextBox03.Text);
                cmd.Parameters.AddWithValue("@Stock_Issued", gunaTextBox04.Text);
                cmd.Parameters.AddWithValue("@Balance", gunaTextBox05.Text);
                cmd.Parameters.AddWithValue("@Remarks", gunaTextBox6.Text);


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
            HostelInvdataGridView.Rows.Clear();
            SqlCommand cmd = new SqlCommand("SELECT Product_ID,Date,Item_Name,Stock_Recieved,Stock_Issued,Balance,Remarks FROM Product", con);
            //DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                i++;
                HostelInvdataGridView.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());

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
                SqlCommand cmd = new SqlCommand("UPDATE Product SET Date=@Date,Item_Name=@Item_Name,Stock_Recieved=@Item_Name,Stock_Issued=@Stock_Issued,Balance=@Balance,Remarks=@Remarks WHERE Product_ID=@Product_ID ", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                //    cmd.Parameters.AddWithValue("@No#", int.Parse(this.Roll_No));
                cmd.Parameters.AddWithValue("@Product_ID", gunaTextBox1.Text);
                cmd.Parameters.AddWithValue("@Date", gunaDateTimePicker3.Value);
                cmd.Parameters.AddWithValue("@Item_Name", gunaTextBox02.Text);
                cmd.Parameters.AddWithValue("@Stock_Recieved", gunaTextBox03.Text);
                cmd.Parameters.AddWithValue("@Stock_Issued", gunaTextBox04.Text);
                cmd.Parameters.AddWithValue("@Balance", gunaTextBox05.Text);
                cmd.Parameters.AddWithValue("@Remarks", gunaTextBox6.Text);

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
            //Clear Button
            ResetFunction();
        }
        private void ResetFunction()
        {
            // Clear Button
            //   object value = dateTimePicker1.Clear();
            gunaTextBox1.Clear();
            gunaTextBox02.Clear();
            gunaTextBox03.Clear();
            gunaTextBox04.Clear();
            gunaTextBox05.Clear();
            gunaTextBox6.Clear();

            gunaTextBox1.Focus();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            // Delete Button
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE Product WHERE Product_ID=@Product_ID ", con);
                //cmd.Parameters.AddWithValue("@Std_Reg_No", int.Parse(textBox1.Text));  to change int to string
                cmd.Parameters.AddWithValue("@Product_ID", gunaTextBox1.Text);
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

        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {
            //Search Button

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT Product_ID,Item_Name,Stock_Recieved,Stock_Issued,Balance,Remarks FROM Product WHERE Product_ID = '" + gunaTextBox7.Text + "' ", con);

            SqlDataReader DR1 = cmd.ExecuteReader();
            if (DR1.Read())
            {
                gunaTextBox1.Text = DR1[0].ToString();
                gunaTextBox02.Text = DR1[1].ToString();
                gunaTextBox03.Text = DR1[2].ToString();
                gunaTextBox04.Text = DR1[3].ToString();
                gunaTextBox05.Text = DR1[4].ToString();
                gunaTextBox6.Text = DR1[5].ToString();
                        

            }
            con.Close();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            // Search Button in DataGridView
            int i = 0;
            con.Open();
            HostelInvdataGridView.Rows.Clear();

            SqlCommand cmd = new SqlCommand("SELECT Product_ID,Date,Item_Name,Stock_Recieved,Stock_Issued,Balance,Remarks FROM Product WHERE Item_Name = '" + TextBox8.Text + "'  ORDER BY Date ASC ", con);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                HostelInvdataGridView.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());

            }
            dr.Close();
            con.Close();


        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            //Refresh Button
            GetProductRecord();
            TextBox8.Clear();
        }

        private void Hostel_Inventory_Load(object sender, EventArgs e)
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

        private void gunaTextBox02_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void gunaTextBox03_KeyDown(object sender, KeyEventArgs e)
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
               //Balance Stock Calculation
                int Rcd = Convert.ToInt32(gunaTextBox03.Text);
                int Isd = Convert.ToInt32(gunaTextBox04.Text);
                int Blnce = Rcd - Isd;
                gunaTextBox05.Text = Blnce.ToString();
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

        private void HostelInvdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Cell Click in Data Grid View
            int Roll_No;
            Roll_No = Convert.ToInt32(HostelInvdataGridView.Rows[0].Cells[0].Value);
            gunaTextBox1.Text = HostelInvdataGridView.SelectedRows[0].Cells[1].Value.ToString();
            gunaTextBox02.Text = HostelInvdataGridView.SelectedRows[0].Cells[3].Value.ToString();

            gunaTextBox03.Text = HostelInvdataGridView.SelectedRows[0].Cells[4].Value.ToString();
            gunaTextBox04.Text = HostelInvdataGridView.SelectedRows[0].Cells[5].Value.ToString();
            gunaTextBox05.Text = HostelInvdataGridView.SelectedRows[0].Cells[6].Value.ToString();
            gunaTextBox6.Text = HostelInvdataGridView.SelectedRows[0].Cells[7].Value.ToString();
           
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            //Load Report Button
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Product_ID,Date,Item_Name,Stock_Recieved,Stock_Issued,Balance,Remarks FROM Product ", con);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("InventoryDataSet", dt);
            reportViewer1.LocalReport.ReportPath = @"C:\Users\Risha\Desktop\IAST Details\4th Semester Dtls\DBMS\DBMS Project\Databaseproject\Databaseproject\Report\Inventory.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
            con.Close();
        }
    }
}
