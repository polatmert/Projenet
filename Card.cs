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
        public Card()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clear();
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
                clear();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void List(SqlConnection con)
        {
            SqlDataAdapter sqlDataAdaper = new SqlDataAdapter("Select * from Items", con);
            DataTable dataTable = new DataTable();
            sqlDataAdaper.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Visible = true;
            dataGridView1.Enabled = false;
        }

        void clear()
        {
            txtName.Text = txtSurname.Text = txtCity.Text = txtCode.Text = "";
        }
    }
}
