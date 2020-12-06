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
using System.Data;
using System.Data.SqlClient;
using DataBase;
namespace 消费中心
{
    /// <summary>
    /// Window3.xaml 的交互逻辑
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        public void test(User u, string s)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                Program p = new Program();
                string sql = "select* from Area_divide_table where Areaname='" + com.Text + "'";
                p.OpenDB();
                Area_d a = p.SearchArea_d(sql);
                p.CloseDB();
                if (u.Role.Equals(a.Role))
                {
                    sql = "INSERT INTO Area_statistic_table VALUES ('" + com.Text + "','" + u.Id + "','"+ DateTime.Now.ToString("yyyy-MM-dd")+"-" + DateTime.Now.ToLongTimeString().ToString() + "')";
                    text.Text += s;
                    p.OpenDB();
                    p.Insert(sql);
                    p.CloseDB();

                }
                else
                    MessageBox.Show("权限不够");
            }));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window7 w = new Window7();
            this.Hide();
            w.ShowDialog();
            this.ShowDialog();
        }
    }
}
