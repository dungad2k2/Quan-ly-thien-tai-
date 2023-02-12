using System;
using System.Collections.Generic;
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
    /// Interaction logic for ThienTai.xaml
    /// </summary>
    public partial class ThienTai : Window
    {
        SqlConnection conn;
        public ThienTai()
        {
            InitializeComponent();
            string constring = "Data Source = DESKTOP-0633V5C; Initial Catalog=thientaiDB; Integrated Security = false; User ID = sa; Password = dung";
            conn = new SqlConnection(constring);
            conn.Open();
        }

        private void xem_click(object sender, RoutedEventArgs e)
        {
            DuLieuThienTai dulieu = new DuLieuThienTai();
            dulieu.Show();
        }
    }
}
