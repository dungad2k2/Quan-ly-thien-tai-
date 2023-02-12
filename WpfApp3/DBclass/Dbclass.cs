using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
namespace WpfApp3.DBclass
{
    
    public class Dbclass
    {
        static string constring = "Data Source = DESKTOP-0633V5C; Initial Catalog=thientaiDB; Integrated Security = false; User ID = sa; Password = dung";
        public DataTable ketquadangnhap (string tendangnhap, string matkhau)
        {
            DataTable dt = new DataTable ();    
            try
            {
                SqlConnection conn = new SqlConnection(constring);
                conn.Open();
                string sql = "SELECT * FROM NguoiDung WHERE tendangnhap = '" + tendangnhap + "' AND matkhau = '" + matkhau + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                dt.Load(dataReader);
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Kết nối đến Server thất bại");
            }
            return dt;
        }
        
        
    }
}
