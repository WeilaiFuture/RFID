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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataBase;
namespace 用户
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textbox1.Text.Trim().Length == 0 || textbox2.Password.Trim().Length == 0)
            {
                MessageBox.Show("账号或密码不能为空", "警告", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string sql = "select* from User_table where Id='" + textbox1.Text + "' and Password='" + textbox2.Password + "'";
                Program p = new Program();
                p.OpenDB();
                List<User> U = p.Searchlogin(sql);
                p.CloseDB();
                if (U.Count == 0)
                {
                    MessageBox.Show("登录失败，用户不存在或密码错误", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    textbox1.Text = "";
                    textbox2.Password = "";
                }
                else
                {
                    user = U[0];
                    Window a1;
                    MessageBox.Show("欢迎" + user.Name + "进入", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                    a1 = new Window1();
                    this.Hide();
                    if (a1.ShowDialog() == true)
                    {
                        this.ShowDialog();
                    }
                    else
                    {
                        this.Close();
                        Environment.Exit(0);
                    }
                }
            }
        }
        public static User user;
    }
}
