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
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
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
            SqlConnection con = DatabaseConnection.ConnectionDB();
            Delete(con);
            Clear();
            List(con);
        }

        private void dataGridView1_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        public void List(SqlConnection con)
        {
            SqlDataAdapter sqlDataAdaper = new SqlDataAdapter("Select * from Items", con);
            DataTable dataTable = new DataTable();
            sqlDataAdaper.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            con.Close();
        }

        public void Clear()
        {
            txtName.Text = txtSurname.Text = txtCity.Text = txtCode.Text = "";
        }

        public void Update(SqlConnection con)
        {
            try
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
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Delete (SqlConnection con)
        {
            try
            {
                if(Id != 0)
                {
                    SqlCommand cmd = new SqlCommand("Delete Items where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
