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
        private SerialPort RFID;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RFIDReader_Load(object sender, EventArgs e)
        {

            RFID = new SerialPort();
            RFID.PortName = "COM5";
            RFID.BaudRate = 9600;
            RFID.DataBits = 8;
            RFID.Parity = Parity.None;
            RFID.StopBits = StopBits.One;
            RFID.Encoding = Encoding.BigEndianUnicode;
            //RFID.RtsEnable = true;

            //RFID.Handshake = Handshake.None; 

            RFID.Open();
            // RFID.ReadTimeout = 200;

            string[] ports = SerialPort.GetPortNames();
            RFID.DataReceived += new SerialDataReceivedEventHandler(RFID_DataReceivedHandler);
            // RFID.Close();
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

    }
}
