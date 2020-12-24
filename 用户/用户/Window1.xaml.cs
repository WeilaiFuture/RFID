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

namespace 用户
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 a = new Window2();
            this.Hide();
            a.ShowDialog();
            this.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window3 a = new Window3();
            this.Hide();
            a.ShowDialog();
            this.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window4 a = new Window4();
            this.Hide();
            a.ShowDialog();
            this.ShowDialog();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
