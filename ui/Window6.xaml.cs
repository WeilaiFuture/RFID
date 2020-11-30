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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;
using System.Threading;
using WinForm = System.Windows.Forms;
using System.IO;

namespace 消费中心
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class Window6 : Window
    {
        private SerialPort RFID=new SerialPort();
        public Window6()
        {
            InitializeComponent();
        }

        private void RFIDReader_Load(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (RFID.IsOpen)
            {
                b.Content="打开串口";
                RFID.Close();
                
            }
            else
            {
                b.Content="关闭串口";
                RFID.PortName=comboBox1.Text;
                RFID.BaudRate=int.Parse(comboBox2.Text);
                RFID.DataBits=5+comboBox4.SelectedIndex;
                RFID.Parity=(Parity)comboBox3.SelectedIndex;
                RFID.StopBits=(StopBits)(comboBox5.SelectedIndex+1);
                RFID.Encoding = Encoding.BigEndianUnicode;
                //RFID.RtsEnable = true;
                //RFID.Handshake = Handshake.None; 
                RFID.Open();
                //RFID.ReadTimeout = 200;
                // string[] ports = SerialPort.GetPortNames();
                RFID.DataReceived += new SerialDataReceivedEventHandler(RFID_DataReceivedHandler);
                // RFID.Close();
            }
        }
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2")+" ";
                }
            }
            return returnStr;
        }


        private void RFID_DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string str1="";
            SerialPort sp = (SerialPort)sender;
            DateTime dt = DateTime.Now;
            Dispatcher.BeginInvoke(new Action(delegate
            {
                if (T.IsChecked==true)
                {
                    str1 += dt.ToString() + " ";
                }
            }));
            int buffersize = sp.BytesToRead;   //十六进制数的大小（假设为6byte）
            byte[] buffer = new byte[buffersize];   //创建缓冲区
            sp.Read(buffer, 0, buffersize);
            Dispatcher.BeginInvoke(new Action(delegate
            {
                if (Show_A.IsChecked == true)
                {
                    str1 += byteToHexStr(buffer); //用到函数byteToHexStr
                }
                else
                {
                    str1 += System.Text.Encoding.Default.GetString(buffer);
                }
            }));
            string s = dt.ToString() + " "+ System.Text.Encoding.Default.GetString(buffer);
            StreamWriter sw = new StreamWriter("log", true, Encoding.GetEncoding("UTF-8"));
            sw.WriteLine(s);
            sw.Close();
            Dispatcher.BeginInvoke(new Action(delegate
            {
                RFIDTagInputBox.Text +=  str1 ;
            }));
        }
        private void SaveFile(object sender, EventArgs e)
        {
            string path;
            WinForm.SaveFileDialog dlg = new WinForm.SaveFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".text";
            dlg.Filter = "Text documents (.txt)|*.txt";
            if (dlg.ShowDialog() == WinForm.DialogResult.OK)//若确认为另存为，则状态栏相关数据改变
            {
                path = System.IO.Path.GetFullPath(dlg.FileName);
                StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("UTF-8"));
                sw.WriteLine(RFIDTagInputBox.Text);
                sw.Close();
                MessageBox.Show("保存成功");
            }
        }

    }
}
