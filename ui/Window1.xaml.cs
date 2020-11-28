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
            Window2 a2 = new Window2();
            a2.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window3 a3 = new Window3();
            a3.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window4 a4 = new Window4();
            a4.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window5 a5 = new Window5();
            a5.Show();
        }
    }
}
