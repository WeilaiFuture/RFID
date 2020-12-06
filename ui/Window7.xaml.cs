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
    /// Window7.xaml 的交互逻辑
    /// </summary>
    public partial class Window7 : Window
    {
        public Window7()
        {
            InitializeComponent();
            string sql = "select* from Area_statistic_table";
            Program p = new Program();
            p.OpenDB();
            List<Area_s> U = p.SearchArea_s(sql);
            p.CloseDB();
            listView.ItemsSource = U;
        }
    }
}
