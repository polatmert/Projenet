using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projenet
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection login = DatabaseConnection.ConnectionDB();
                SqlParameter username = new SqlParameter("@username", txtUsername.Text.Trim());
                SqlParameter password = new SqlParameter("@password", txtPassword.Text.Trim());
                SqlCommand sqlcmd = new SqlCommand("UserLogin", login);
                sqlcmd.Parameters.Add(username);
                sqlcmd.Parameters.Add(password);
                sqlcmd.CommandType = CommandType.StoredProcedure;

               
                SqlDataReader dr =   sqlcmd.ExecuteReader();

                if(dr.Read())
                {
                    Card card = new Card();
                    card.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Username and password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
