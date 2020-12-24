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
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            Text1.Text = MainWindow.user.Id;
            Text2.Text = MainWindow.user.Name;
            Text7.Text = MainWindow.user.Money.ToString();
            Text8.Text = MainWindow.user.Idnumber;
            Text6.Text = MainWindow.user.Role;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Text1.Text != string.Empty && Text2.Text != string.Empty && password1.Password != string.Empty
               && password2.Password != string.Empty && combobox1.Text != string.Empty && Text6.Text != string.Empty && Text7.Text != string.Empty)
            {
                if (password1.Password.Equals(password2.Password))
                {
                    string sq = "delete from User_table WHERE Id = " + "'" + MainWindow.user.Id + "'";
                    string sql = "INSERT INTO User_table VALUES ('" + Text1.Text + "',0,'" + password1.Password + "',";
                    if (combobox1.Text.Equals("男"))
                        sql += "0,'";
                    else
                        sql += "1,'";
                    if (Text6.Text.Equals("游客"))
                    {
                        sql += "1'";
                    }
                    else
                    {
                        sql += "0'";
                    }
                    sql += "," + Text7.Text + ",'" + Text2.Text + "','" + Text8.Text + "','" + MainWindow.user.Card + "')";

                    Program p = new Program();
                    p.OpenDB();
                    p.Delete(sq);
                    p.Insert(sql);
                    p.CloseDB();
                    MessageBox.Show("修改成功", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("两次输入密码不一致", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("还有项目未填", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
