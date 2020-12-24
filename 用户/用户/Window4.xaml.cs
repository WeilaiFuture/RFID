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
using DataBase;
namespace 用户
{
    /// <summary>
    /// Window4.xaml 的交互逻辑
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
            string sql = "select* from Payment_statistic_table where Id='"+MainWindow.user.Id+"'";
            Program p = new Program();
            p.OpenDB();
            List<Payment> U = p.SearchPayment(sql);
            p.CloseDB();
            listView.ItemsSource = U;
        }
    }
}
