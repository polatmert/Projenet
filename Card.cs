using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Projenet
{
    public partial class Card : Form
    {
        int Id;

        public Card()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }       
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    SqlConnection card = DatabaseConnection.ConnectionDB();
                    SqlCommand sqlcmd = new SqlCommand("ItemAdd", card);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Code", txtCode.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@City", txtCity.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@State", chBoxActive.Checked);
                    sqlcmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                    sqlcmd.ExecuteNonQuery();
                    Clear();
                    List(card);
                    card.Close();
                }
                else
                {
                    MessageBox.Show("please enter the code");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection card = DatabaseConnection.ConnectionDB();
                List(card);
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = DatabaseConnection.ConnectionDB();
                Update(con);
                Clear();
                List(con);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = DatabaseConnection.ConnectionDB();
                Delete(con);
                Clear();
                List(con);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = DatabaseConnection.ConnectionDB();
                OpenFileDialog openDialog = new OpenFileDialog();
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    this.txtpath.Text = openDialog.FileName;
                }

                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                Excel.Range range;

                int rw = 0;
                int cl = 0;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(txtpath.Text, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                range = xlWorkSheet.UsedRange;
                rw = range.Rows.Count;
                cl = range.Columns.Count;

                DataTable dataTable = new DataTable();

                dynamic element = range.Rows.Value2;
                var columnCount = range.Rows.Count;
                var rowCount = range.Columns.Count;
                InserDataToDB(element, columnCount, rowCount);
                List(con);
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }

        private void dataGridView1_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }

        public void List(SqlConnection con)
        {
            try
            {
                SqlDataAdapter sqlDataAdaper = new SqlDataAdapter("Select * from Items", con);
                DataTable dataTable = new DataTable();
                sqlDataAdaper.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }

        public void Clear()
        {
            try
            {
                txtName.Text = txtSurname.Text = txtCity.Text = txtCode.Text = txtpath.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }

        public void Update(SqlConnection con)
        {
            try
            {
                if (Id != 0)
                {
                    SqlCommand sqlcmd;
                    sqlcmd = new SqlCommand("update Items set Name=@name,Surname=@Surname,Code=@Code,City=@City,State=@State,Date=@Date where Id=@Id", con);
                    sqlcmd.Parameters.AddWithValue("@Id", Id);
                    sqlcmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Code", txtCode.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@City", txtCity.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@State", chBoxActive.Checked);
                    sqlcmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);

                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully");

                }
                else
                {
                    MessageBox.Show("Please select the item");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Delete(SqlConnection con)
        {
            try
            {
                if (Id != 0)
                {
                    SqlCommand cmd = new SqlCommand("Delete Items where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Please select the item");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void InserDataToDB(dynamic data, int rowCount, int columnCount)
        {
            try
            {
                SqlConnection card = DatabaseConnection.ConnectionDB();
                int i = 2;
                while (i <= rowCount)
                {
                    SqlCommand sqlcmd = new SqlCommand("ItemAdd", card);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@Name", data[i, 1]);
                    sqlcmd.Parameters.AddWithValue("@Surname", data[i, 2]);
                    if (string.IsNullOrWhiteSpace(data[i, 3]))
                    {
                        MessageBox.Show(i + " item code is incorrect or empty");
                        break;
                    }

                    sqlcmd.Parameters.AddWithValue("@Code", data[i, 3]);
                    sqlcmd.Parameters.AddWithValue("@City", data[i, 4]);
                    DateTime newdatetime = Convert.ToDateTime(data[i, 5]);
                    sqlcmd.Parameters.AddWithValue("@Date", newdatetime);
                    if (data[i, 6] == 1)
                        sqlcmd.Parameters.AddWithValue("@State", true);
                    else
                        sqlcmd.Parameters.AddWithValue("@State", false);

                    sqlcmd.ExecuteNonQuery();
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);               
            }
        }
    }
}