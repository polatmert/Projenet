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
    public partial class SıgnUp : Form
    {
        public SıgnUp()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection signUp = DatabaseConnection.ConnectionDB();
                SqlCommand sqlcmd = new SqlCommand("UserAdd", signUp);
                string passwordCrypto = Encrypt(txtPassword.Text.Trim());
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Password", passwordCrypto);
                sqlcmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("Registration is successfull");
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void clear()
        {
            txtName.Text = txtSurname.Text = txtUsername.Text = txtPassword.Text = txtEmail.Text = "";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clear();
        }
        public string Encrypt(string strPass)
        {
            string hash = "f0xle@rn";

            if (strPass == "" || strPass == null)
            {
                throw new ArgumentNullException("Şifrelenecek veri yok");
            }
            else
            {
                byte[] data = UTF8Encoding.UTF8.GetBytes(strPass);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                    {
                        using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                        {
                            ICryptoTransform transform = tripDes.CreateEncryptor();
                            byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                            string encryptPassword = Convert.ToBase64String(results, 0, results.Length);
                            return encryptPassword;
                        }
                    }
                }
            }
        }

        private void lblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SıgnUp frmSignUp = new SıgnUp();
            frmSignUp.Close();

            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();

            this.Hide();
        }
    }
}
