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
        public string constring = "Data Source = DESKTOP-0633V5C; Initial Catalog=thientaiDB; Integrated Security = false; User ID = sa; Password = dung";
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
        public void themdulieuthientai (thientai ThienTai)
        {
                SqlConnection conn = new SqlConnection(constring);
                conn.Open();
                string column1 = "MaThienTai";
                string column2 = "LoaiThienTai";
                string column3 = "DiaDiem";
                string column4 = "MucDoThietHai";
                string column5 = "ThoiGian";
                string value1 = ThienTai.MaThienTai;
                string value2 = ThienTai.LoaiThienTai;
                string value3 = ThienTai.DiaDiem;
                int value4 = ThienTai.MucDo;
                DateTime value5 = ThienTai.ThoiGian;
                string sql = "INSERT INTO ThienTai(" + column1 + "," + column2 + "," + column3+ "," + column4 + "," + column5 +") VALUES (" +"'" + value1  +"'," + "N'" + value2 + "'," + "N'" + value3 + "'," + value4 + ",'" + value5 + "'" + ")";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
         
        }
        public void xoadulieuthientai (thientai ThienTai)
        {
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            string value1 = ThienTai.MaThienTai;
            string sql = "DELETE FROM ThienTai WHERE MaThienTai='" + value1 + "';";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
        public void suadulieuthientai(thientai ThienTai)
        {
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            string value1 = ThienTai.MaThienTai;
            string value2 = ThienTai.LoaiThienTai;
            string value3 = ThienTai.DiaDiem;
            int value4 = ThienTai.MucDo;
            DateTime value5 = ThienTai.ThoiGian;
            string sql = "UPDATE ThienTai SET LoaiThienTai = N'" + value2 + "'," + "DiaDiem = N'" + value3 + "'," + "MucDoThietHai = " + value4 + ", ThoiGian = '" + value5 + "' WHERE MaThienTai = '" + value1 + "';";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public DataTable timkiemthientai(thientai ThienTai)
        {
            DataTable dt = new DataTable();   
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            string sql = "SELECT * FROM ThienTai";
            SqlDataAdapter adapter= new SqlDataAdapter(sql, conn);
            adapter.Fill(dt);
            return dt;
        }
    }
}
