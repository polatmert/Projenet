using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projenet
{
    class DatabaseConnection
    {
        public static SqlConnection ConnectionDB()
        {
            string connetionString = null;
            SqlConnection cnn ;
            connetionString = "Data Source=DESKTOP-7AMEE4G;Initial Catalog=ProjenetDb; Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();               
                return cnn;
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
               return cnn;
            }
        }
    }
}
