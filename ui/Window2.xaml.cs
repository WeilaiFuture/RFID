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
using System.Data;
using System.Data.SqlClient;

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

        public void readId()
        {
            string sql = "select * from User_table where Id=";//kahao
            Program p = new Program();
            p.OpenDB();
            SqlDataReader read = p.Search(sql);
            while (read.Read())
            {
                //向窗口输出用户信息
                //示例：int number = Convert.ToInt32(read["列名1"]);          //查询列名1的数据,方法为: read(变量名)["列名"]; 该方法返回的是object类型
                //string name = read["列名2"].ToString();
                //Console.WriteLine("{0}\t{1}\t{2}\t\t{3}\t\t{4}", number, name, revise, Email, day);
            }
            p.CloseDB();
            //显示至窗口
            //能够选择区域
            //无权限的红色高亮
            MessageBox.Show("该游客没有进入该区域的权限", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
