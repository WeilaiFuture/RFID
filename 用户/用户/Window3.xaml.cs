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
    /// Window3.xaml 的交互逻辑
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            initList(select_sql);
        }
        private static string select_sql = "select* from Order_table where Id='" + MainWindow.user.Id+"'";

        private void initList(string s)
        {
            Program p = new Program();
            p.OpenDB();
            List<Order> U = p.SearchOrder(s);
            p.CloseDB();
            listView.ItemsSource = U;

        }

        private void Regist(object sender, RoutedEventArgs e)
        {
            Window5 a5 = new Window5();
            a5.ShowDialog();
            initList(select_sql);
        }

        private void Del(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem == null)
                MessageBox.Show("请选中一行", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                Order u = listView.SelectedItem as Order;
                MessageBoxResult result = MessageBox.Show("确认是否删除编号为 " + u.IdOfOrder + " 的预约", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    string sql = "delete from Order_table where IdOfOrder='" + u.IdOfOrder + "'";
                    Program p = new Program();
                    p.OpenDB();
                    p.Delete(sql);
                    p.CloseDB();
                    initList(select_sql);
                }
            }
        }
        private void List_clear()
        {
            listView.ItemsSource = null;
        }

    }
}
