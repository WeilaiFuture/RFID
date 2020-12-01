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
using System.Threading;
using DataBase;

namespace 消费中心
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Thread newWindowThread = new Thread(new ThreadStart(ThreadStartingPoint));
            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start();
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int n;
            if (textbox1.Text.Trim().Length == 0 || textbox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("账号或密码不能为空", "警告", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string sql = "select* from User_table where Id=" + textbox1.Text + " and Password='" + textbox2.Text + "'";
                Program p = new Program();
                p.OpenDB();
                n = p.Searchlogin(sql);
                if (n == 0)
                {
                    MessageBox.Show("登录失败，用户不存在", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("登录成功", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                    Window1 a1 = new Window1();
                    this.Hide();
                    a1.ShowDialog();
                    this.Close();
                }
                p.CloseDB();
            }
        }
        private void ThreadStartingPoint()
        {
            Window6 tempWindow = new Window6();
            tempWindow.Show();
            System.Windows.Threading.Dispatcher.Run();
        }
    }
}
