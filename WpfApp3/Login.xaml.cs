using System;
using System.Collections.Generic;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Dbclass db = new Dbclass();
        public Login()
        {
            InitializeComponent();
        }
        user us = new user();
        private void dangnhap_click(object sender, RoutedEventArgs e)
        {
            if (db.ketquadangnhap(txttendangnhap.Text, txtmatkhau.Password).Rows.Count > 0)
            {
                MainWindow main = new MainWindow();
                us.username = txttendangnhap.Text;
                main.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại");
            }
        }

        private void btthoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
