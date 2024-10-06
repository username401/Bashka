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

        public void Initialaze(int baudRate, Parity parity, StopBits stopBits, int dataBits, string portName)
        {
            SerialPort = new SerialPort();
            SerialPort.BaudRate = baudRate;
            SerialPort.Parity = parity;
            SerialPort.StopBits = stopBits;
            SerialPort.DataBits = dataBits;
            SerialPort.PortName = portName;
        }
        public void Open()
        {
            SerialPort.Open();
        }
        public void Close()
        {
            SerialPort.Close();
        }

    }
}
