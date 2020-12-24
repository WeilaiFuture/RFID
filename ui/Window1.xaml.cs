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
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            a = new Window2();
            flag = a.ToString();
            this.Hide();
            a.ShowDialog();
            this.ShowDialog();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            a = new Window3();
            flag = a.ToString();
            this.Hide();
            a.ShowDialog();
            this.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            a= new Window4();
            flag = a.ToString();
            this.Hide();
            a.ShowDialog();
            this.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            a = new Window5();
            flag = a.ToString();
            this.Hide();
            a.ShowDialog();
            this.ShowDialog();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.DialogResult =true;
            this.Close();
        }
        public static Window a = new Window();
        public static string flag = "";
    }
}
