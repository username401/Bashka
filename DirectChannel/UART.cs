using ChannelDefinitions;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace UART
{
    public class UART : AbstractChannel
    {
        private SerialPort _serialPort = new SerialPort();

        public SerialPort SerialPort
        {
            get
            {
                return _serialPort;
            }
            private set { _serialPort = value; }
        }

        private int _baudRate;
        public int BaudRate
        {
            get { return _baudRate; }
            set { _baudRate = value; }
        }

        private Parity _parity;
        public Parity Parity 
        { 
            get { return _parity; } 
            set { _parity = value; } 
        }

        private StopBits _stopBits;
        public StopBits StopBits
        {
            get { return _stopBits; }
            set { _stopBits = value; }
        }

        private int _dataBits;
        public int DataBits
        {
            get { return _dataBits; }
            set { _dataBits = value; }
        }

        private string _portName;
        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }


        public override void Initialize()
        {
            SerialPort = new SerialPort();
            SerialPort.BaudRate = BaudRate;
            SerialPort.Parity = Parity;
            SerialPort.StopBits = StopBits;
            SerialPort.DataBits = DataBits;
            SerialPort.PortName = PortName;

        }
        public override void Open()
        {
            SerialPort.Open();
        }
        public override void Close()
        {
            SerialPort.Close();
        }

        public void CheckState()
        {

        }
    }
}
