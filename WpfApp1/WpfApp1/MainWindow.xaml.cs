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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private SerialPort RFID=new SerialPort();
        /// <summary>
        /// /////////////////
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RFIDReader_Load(object sender, EventArgs e)
        {
            if(RFID.IsOpen)
            {
                Button b=(Button)sender;
                b.Content="打开串口";
                RFID.Close();
                
            }
            else
            {
                Button b=(Button)sender;
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
                // RFID.ReadTimeout = 200;
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
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }


        private void RFID_DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            int buffersize = 20;   //十六进制数的大小（假设为6byte）
            byte[] buffer = new byte[buffersize];   //创建缓冲区
            SerialPort sp = (SerialPort)sender;
            sp.Read(buffer, 0, buffersize);
            string ss;
            ss = byteToHexStr(buffer); //用到函数byteToHexStr
            //string indata = sp.ReadExisting();
            //string indata = sp.ReadExisting();
            //serialPort1.Read(buffer, 0, buffersize);
            //string ss = byteToHexStr(indata); //用到函数byteToHexStr
            Dispatcher.BeginInvoke(new Action(delegate
            {

                RFIDTagInputBox.Text += ss;
                //RFIDTagInputBox.Text = indata;
            }));

        }
        private void SaveFile(object sender, EventArgs e)
        {
        }

    }
}
