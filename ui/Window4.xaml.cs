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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(Date.SelectedDate);
            if (textbox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("预约日期或姓名或身份证号不能为空", "警告", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int n = 0;
                string sql = "select * from Order_table where Id=";//+and Orderdate='" + Date.SelectedDate + "'";//kahao
                Program p = new Program();
                p.OpenDB();
                n = p.Searchlogin(sql);
                if (n == 0)
                {
                    MessageBox.Show("预约失败，您在当天已有预约", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string sql1 = "insert into Order_table(Id Orderdate Name Idnumber) values(";
                    p.Insert(sql1);
                    MessageBox.Show("预约成功", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                p.CloseDB();
            }
        }
        private void textbox1_TextChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
