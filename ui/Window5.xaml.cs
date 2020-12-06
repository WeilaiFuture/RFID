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
using System.IO;
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
            init();
        }
        private string date;
        private static int index;
        private DateTime dt = DateTime.Now;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textbox1.Text.Trim().Length == 0|| textbox2.Text.Trim().Length==0)
            {
                MessageBox.Show("消费金额或卡号不能为空", "警告", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Program p = new Program();
                string sql = "select* from User_table Where Id='"+ textbox2.Text+"'";
                p.OpenDB();
                List<User>u=p.Searchlogin(sql);
                p.CloseDB();
                if (u.Count != 0)
                {
                    user = u[0];
                    sql = "INSERT INTO Payment_statistic_table VALUES ('P" + date + index.ToString().PadLeft(6, '0') + "','" + textbox2.Text + "','";
                    sql += DateTime.Now.ToString("yyyy-MM-dd") + "-" + DateTime.Now.ToString("hh-mm-ss") + "','";
                    sql += "所有区域'," + int.Parse(textbox1.Text) + ")";
                    if (user.Money - int.Parse(textbox1.Text) >= 0)
                    {
                        index++;
                        StreamWriter sw = new StreamWriter("date1", false, Encoding.GetEncoding("UTF-8"));
                        sw.WriteLine(DateTime.Now.ToString("yyyyMMdd"));
                        sw.WriteLine(index.ToString());
                        sw.Close();
                        p = new Program();
                        p.OpenDB();
                        p.Insert(sql);
                        p.CloseDB();
                        MessageBox.Show("消费成功");
                    }
                    else
                    {
                        MessageBox.Show("余额不足");
                    }
                }
                else
                    MessageBox.Show("用户不存在");
            }
        }
        public void test(User u)
        {
            user = u;
            this.Dispatcher.Invoke(new Action(() =>
            {
                textbox2.Text = u.Id;
            }));
        }
        private static User user;
        private void init()
        {
            string s = DateTime.Now.ToString("yyyyMMdd");
            StreamReader sr = new StreamReader("date1", Encoding.GetEncoding("UTF-8"));
            date = sr.ReadLine();
            index = int.Parse(sr.ReadLine());
            sr.Close();
            if (!date.Equals(s))
            {
                index = 0;
                date = s;
                StreamWriter sw = new StreamWriter("date1", false, Encoding.GetEncoding("UTF-8"));
                sw.WriteLine(s);
                sw.WriteLine(index.ToString());
                sw.Close();
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window8 w = new Window8();
            this.Hide();
            w.ShowDialog();
            this.ShowDialog();
        }
    }
}
