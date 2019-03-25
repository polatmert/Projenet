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
                string passwordText = Encrypt(txtPassword.Text.Trim());
                SqlParameter username = new SqlParameter("@username", txtUsername.Text.Trim());
                SqlParameter password = new SqlParameter("@password", passwordText);
                SqlCommand sqlcmd = new SqlCommand("UserLogin", login);
                sqlcmd.Parameters.Add(username);
                sqlcmd.Parameters.Add(password);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = sqlcmd.ExecuteReader();

                if (dr.Read())
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

        //TO DO : To be removed
        public string Decrypt(string strPass)
        {
            string hash = "f0xle@rn";
            byte[] data = Convert.FromBase64String(strPass);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                {
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripDes.CreateEncryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        string decryptPassword = UTF8Encoding.UTF8.GetString(results);
                        return decryptPassword;
                    }
                }
            }
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
    }
}
