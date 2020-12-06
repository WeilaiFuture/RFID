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
namespace WpfApp1
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            initList();
        }
        private static string select_sql = "select* from User_table";

        private void initList()
        {
            Program p = new Program();
            p.OpenDB();
            List<User> U = p.Searchlogin(select_sql);
            p.CloseDB();
            listView.ItemsSource = U;

        }

        private void Recharge(object sender, RoutedEventArgs e)
        {
            if(listView.SelectedItem==null)
                MessageBox.Show("请选中一行", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
            else 
            {
                if (Text1.Text == string.Empty)
                {
                    MessageBox.Show("请输入金额", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    User u = listView.SelectedItem as User;
                    string sql = "UPDATE User_table SET Money = " + "'" + (u.Money + int.Parse(Text1.Text)).ToString() + "'" + "WHERE Id = " + "'" + u.Id + "'";
                    Program p = new Program();
                    p.OpenDB();
                    p.Change(sql);
                    p.CloseDB();
                    initList();
                    Text1.Text = "";
                }
            }
        }

        private void Regist(object sender, RoutedEventArgs e)
        {
            Window2 a2 = new Window2();
            a2.ShowDialog();
            a2.RFID.Close();
            
            initList();
        }

        private void Del(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem == null)
                MessageBox.Show("请选中一行", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                User u = listView.SelectedItem as User;
                MessageBoxResult result = MessageBox.Show("确认是否删除账号为 " + u.Id+" 的用户","警告",MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    string sql = "delete from User_table where Id='" + u.Id+"'";
                    Program p = new Program();
                    p.OpenDB();
                    p.Delete(sql);
                    p.CloseDB();
                    initList();
                }
            }
        }

        private void Find(object sender, RoutedEventArgs e)
        {
            if (Text2.Text == string.Empty)
            {
                MessageBoxResult result = MessageBox.Show("账号栏无账号是否查询所有用户", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    select_sql = "select* from User_table";
                    initList();
                }
            }
            else
            {
                List_clear();
                select_sql = "select* from User_table where Id='" + Text2.Text+"'";
                initList();
            }
        }
        private void List_clear()
        {
            listView.ItemsSource = null;
        }

    }
}
