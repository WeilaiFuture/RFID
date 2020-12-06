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
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        public void test(User u,string s)
        {
            this.Dispatcher.Invoke(new Action(() => {
                if (u.Flag.Equals("未入园"))
                    text1.Text += s;
                else
                    text2.Text += s;
                string sql1 = "update User_table set Flag=~Flag where Id='" + u.Id+"'";
                Program p = new Program();
                p.OpenDB();
                p.Change(sql1);
                p.CloseDB();
            }));
        }
    }
}
