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
using System.IO.Ports;
namespace WpfApp1
{
    /// <summary>
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        public  SerialPort RFID = new SerialPort();
        public Window2()
        {

            init();
            InitializeComponent();
        }
        private string date;
        private static int index;
        private string Card;
        private DateTime dt = DateTime.Now;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Text1.Text!=string.Empty&& Text2.Text != string.Empty && password1.Password != string.Empty
                && password2.Password != string.Empty && combobox1.Text != string.Empty && combobox2.Text != string.Empty&& Text7.Text != string.Empty)
            {
                if (password1.Password.Equals(password2.Password))
                {
                    string sql = "INSERT INTO User_table VALUES ('" + Text1.Text + "',0,'" + password1.Password + "',";
                    if (combobox1.Text.Equals("男"))
                        sql += "0,'";
                    else
                        sql += "1,'";
                    if (combobox2.Text.Equals("游客"))
                    {
                        sql += "1'";
                    }
                    else
                    {
                        sql += "0'";
                    }
                    sql += "," + Text7.Text + ",'" + Text2.Text + "','" + Text8.Text + "','" + Card + "')";

                    Program p = new Program();
                    p.OpenDB();
                    p.Insert(sql);
                    p.CloseDB();
                    index++;
                    StreamWriter sw = new StreamWriter("date", false, Encoding.GetEncoding("UTF-8"));
                    sw.WriteLine(DateTime.Now.ToString("yyyyMMdd"));
                    sw.WriteLine(index.ToString());
                    sw.Close();
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
        private void init()
        {
            string s = DateTime.Now.ToString("yyyyMMdd");
            StreamReader sr = new StreamReader("date", Encoding.GetEncoding("UTF-8"));
            date = sr.ReadLine();
            index = int.Parse(sr.ReadLine());
            sr.Close();
            if (!date.Equals(s))
            {
                index = 0;
                date = s;
                StreamWriter sw = new StreamWriter("date", false, Encoding.GetEncoding("UTF-8"));
                sw.WriteLine(s);
                sw.WriteLine(index.ToString());
                sw.Close();
            }
            RFID.PortName = "COM5";
            RFID.BaudRate = 9600;
            RFID.DataBits = 8;
            RFID.Parity = Parity.None;
            RFID.StopBits = StopBits.One;
            RFID.Encoding = Encoding.BigEndianUnicode;
            RFID.Open();
            RFID.DataReceived += new SerialDataReceivedEventHandler(RFID_DataReceivedHandler);
        }
        public void RFID_DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            DateTime dt = DateTime.Now;
            int buffersize = sp.BytesToRead;   //十六进制数的大小（假设为6byte）
            byte[] buffer = new byte[buffersize];   //创建缓冲区
            sp.Read(buffer, 0, buffersize);
            string s =  System.Text.Encoding.Default.GetString(buffer);
            string str = s.Substring(3, 10);
            string select_sql = "select* from User_table where Card='" + str + "'";
            Program p = new Program();
            p.OpenDB();
            List<User> U = p.Searchlogin(select_sql);
            p.CloseDB();
            if (U.Count == 0)
            {
                MessageBox.Show("卡号 '" + str + "' 已经被注册,请换卡", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Dispatcher.BeginInvoke(new Action(delegate
                {

                    Card = str;
                    Text1.Text = date + index.ToString().PadLeft(4, '0');
                }));
            }
        }

    }
}
