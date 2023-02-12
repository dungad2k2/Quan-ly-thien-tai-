using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for DuLieuThienTai.xaml
    /// </summary>
    public partial class DuLieuThienTai : Window
    {
        SqlConnection conn;
        public DuLieuThienTai()
        {
            InitializeComponent();
            string constring = "Data Source = DESKTOP-0633V5C; Initial Catalog=thientaiDB; Integrated Security = false; User ID = sa; Password = dung";
            conn = new SqlConnection(constring);
            conn.Open();
            databinding();
        }
        private void databinding()
        {
            string sql = "SELECT * FROM ThienTai";
            SqlCommand cmd = new SqlCommand(sql, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Datagrid.ItemsSource = dt.DefaultView;
        }
    }
}
