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
using WpfApp3.DBclass;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            thientai ThienTai= new thientai();
            ThienTai.MaThienTai = Ma.Text.ToString();
            ThienTai.LoaiThienTai = Loai.Text.ToString();
            ThienTai.DiaDiem = Dia.Text.ToString();
            int MucDo = int.Parse(Muc.Text);
            ThienTai.MucDo = MucDo;
            DateTime enteredDate = DateTime.Parse(Thoi.Text.ToString());
            ThienTai.ThoiGian = enteredDate;
            Dbclass db = new Dbclass();
            try
            {
                db.themdulieuthientai(ThienTai);
                MessageBox.Show("Thêm Thành Công");
            }
            catch
            {
                MessageBox.Show("Thêm Không Thành Công");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            thientai ThienTai = new thientai();
            ThienTai.MaThienTai = Ma.Text.ToString();
            Dbclass db = new Dbclass();
            try
            {
                db.xoadulieuthientai(ThienTai);
                MessageBox.Show("Xóa Thành Công");
            }
            catch
            {
                MessageBox.Show("Xóa Không Thành Công");
            }

        }

        private void Sua_Click(object sender, RoutedEventArgs e)
        {
            thientai ThienTai = new thientai();
            ThienTai.MaThienTai = Ma.Text.ToString();
            ThienTai.LoaiThienTai = Loai.Text.ToString();
            ThienTai.DiaDiem = Dia.Text.ToString();
            int MucDo = int.Parse(Muc.Text);
            ThienTai.MucDo = MucDo;
            DateTime enteredDate = DateTime.Parse(Thoi.Text.ToString());
            ThienTai.ThoiGian = enteredDate;
            Dbclass db = new Dbclass();
          
            db.suadulieuthientai(ThienTai);
            MessageBox.Show("Sửa Thành Công");
        }

        private void TimKiem_Click(object sender, RoutedEventArgs e)
        {
            thientai ThienTai = new thientai();
            ThienTai.MaThienTai = Ma.Text.ToString();
            

            Dbclass db = new Dbclass();
            DataTable dt = new DataTable();
            dt = db.timkiemthientai(ThienTai);
            DataRow[] rows = dt.Select("MaThienTai = " + "'" + ThienTai.MaThienTai + "'");
            foreach (DataRow row in rows)
                {
                    string columnValue =
                        row["MaThienTai"].ToString() + " " +
                        row["LoaiThienTai"].ToString() + " " +
                        row["DiaDiem"].ToString() + " " +
                        row["MucDoThietHai"].ToString() + " " +
                        row["ThoiGian"].ToString() + " ";
                   MessageBox.Show(columnValue);
                }




        }
    }
}
