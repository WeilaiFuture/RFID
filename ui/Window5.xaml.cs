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
using Database;

namespace 消费中心
{
    /// <summary>
    /// Window5.xaml 的交互逻辑
    /// </summary>
    public partial class Window5 : Window
    {
        public Window5()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int n;
            if (textbox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("消费金额不能为空", "警告", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string sql = "select* from User_table where Id=";
                Program p = new Program();
                p.OpenDB();
                n = p.Searchlogin(sql);
                if (n == 0)
                {
                    MessageBox.Show("消费失败，用户不存在", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string sql1 = "select Money from User_table where Id=";
                    int m;
                    m = p.SearchMoney(sql1, textbox1.Text);
                    if (m == 1)
                    {
                        MessageBox.Show("消费成功", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("消费失败，余额不足", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                p.CloseDB();
            }
        }
    }
}
