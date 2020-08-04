using System;
using System.IO.Ports;
using System.Threading;
namespace ConsoleApp1
{
    class Program
    {
        static SerialPort _serialPort;
        public static void Main()
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM1";
            _serialPort.BaudRate = 9600;
            _serialPort.Open();
            
        }
    }
}