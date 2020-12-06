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

namespace 消费中心
{
    /// <summary>
    /// Window4.xaml 的交互逻辑
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
            initList();
        }
        private string sql = "select* from Order_table";
        private void initList()
        {
            Program p = new Program();
            p.OpenDB();
            List<Order> U = p.SearchOrder(sql);
            p.CloseDB();
            listView.ItemsSource = U;

        }
        private void Find(object sender, RoutedEventArgs e)
        {
            if (Text2.Text == string.Empty)
            {
                MessageBoxResult result = MessageBox.Show("账号栏无账号是否查询所有用户", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    sql = "select* from Order_table";
                    initList();
                }
            }
            else
            {
                List_clear();
                sql = "select* from Order_table where Id='" + Text2.Text + "'";
                initList();
            }
        }
        private void List_clear()
        {
            listView.ItemsSource = null;
        }
    }
}
