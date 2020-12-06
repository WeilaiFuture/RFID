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
using System.IO;
using DataBase;
namespace 用户
{
    /// <summary>
    /// Window5.xaml 的交互逻辑
    /// </summary>
    public partial class Window5 : Window
    {
        private string date;
        private static int index;
        private DateTime dt = DateTime.Now;
        public Window5()
        {
            InitializeComponent();
            init();
        }
        private void init()
        {
            string s = DateTime.Now.ToString("yyyyMMdd");
            StreamReader sr = new StreamReader("date2", Encoding.GetEncoding("UTF-8"));
            date = sr.ReadLine();
            index = int.Parse(sr.ReadLine());
            sr.Close();
            if (!date.Equals(s))
            {
                index = 0;
                date = s;
                StreamWriter sw = new StreamWriter("date2", false, Encoding.GetEncoding("UTF-8"));
                sw.WriteLine(s);
                sw.WriteLine(index.ToString());
                sw.Close();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textbox1.Text.Trim().Length == 0 || textbox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("姓名和身份证号都不能为空", "警告", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DateTime d = (DateTime)date1.SelectedDate;
                string s = d.ToString("yyyy-MM-dd");
                string sql = "select* from Order_table where Id='" + MainWindow.user.Id + "' AND Orderdate='" + s + "'";
                Program p = new Program();
                p.OpenDB();
                List<Order> U = p.SearchOrder(sql);
                p.CloseDB();
                if (U.Count == 0)
                {
                    sql = "INSERT INTO Order_table VALUES ('Y" + date + index.ToString().PadLeft(4, '0') + "','" + s + "','" + MainWindow.user.Id + "','";
                    sql += DateTime.Now.ToString("yyyy-MM-dd") + "-" + DateTime.Now.ToLongTimeString().ToString() + "')";
                    index++;
                    StreamWriter sw = new StreamWriter("date2", false, Encoding.GetEncoding("UTF-8"));
                    sw.WriteLine(DateTime.Now.ToString("yyyyMMdd"));
                    sw.WriteLine(index.ToString());
                    sw.Close();
                    p = new Program();
                    p.OpenDB();
                    p.Insert(sql);
                    p.CloseDB();
                    MessageBox.Show("预约成功");
                }
                else
                {
                    MessageBox.Show("当天已经预约", "警告", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
