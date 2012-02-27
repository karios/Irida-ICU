using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using ICU.Com;

namespace ICU
{   
    /// <summary>
    /// Read from the COM port the information sent by the sensors
    /// </summary>
    public class ComReader
    {
        
        private SerialPort serialPort;
        private ComPacketParsing comPacketParsing;
        private string portName;

        public ComReader()
        {
            //Get first available COM port (and hope it is the one we need)
            string[] theSerialPortNames = System.IO.Ports.SerialPort.GetPortNames();
            this.portName = theSerialPortNames[0];
            this.portName = "COM4";

            // Instanciate the parser (For messages incoming)
            this.comPacketParsing = new ComPacketParsing();

            // Create the serial port using a portName like COM1?
            this.serialPort = new SerialPort(portName);

            //Get the correct informations 
            serialPort.BaudRate = 38400;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.DataBits = 8;
            serialPort.Handshake = Handshake.None;
            

            // Define the what's handling the event.
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            serialPort.Open();

            Notifier.info(String.Format("(COM) Listening from {0}.",this.portName));
        }


        /// <summary>
        /// This methods runs when data is received form the serialport.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string indata = this.serialPort.ReadLine();
            Notifier.dataFromCom(this.portName, indata);
            this.comPacketParsing.parse(indata);
        }


        private void close()
        {
            this.serialPort.Close();
        }
    }
}
