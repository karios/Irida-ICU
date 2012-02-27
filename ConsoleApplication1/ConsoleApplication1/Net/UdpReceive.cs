using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace ICU.Net
{
    class UdpReceive
    {

        private int listenPort = 5000;
        private UdpClient udpClient;
        private int state;
        private IPEndPoint listeningAddress;
        private UdpPacketParsing packetParsing = new UdpPacketParsing();

        public UdpReceive()
        {
            this.state = 1;
            this.listeningAddress = new IPEndPoint(IPAddress.Any, listenPort);
            this.udpClient = new UdpClient(listeningAddress);
            
            // Begin to receive messages
            ReceiveMessages();
            Console.WriteLine("UDPRecv Initialized");



        }

        /// <summary>
        /// Method to run when a message is received (Asynchronous).
        /// </summary>
        /// <param name="ar"></param>
        /// 
        public void ReceiveCallback(IAsyncResult ar)
        {

            IPEndPoint address = null;
            
            Byte[] receiveBytes = udpClient.EndReceive(ar, ref address);

            string receiveString = Encoding.ASCII.GetString(receiveBytes);



            // Parse the message
            this.packetParsing.parse(receiveString, address);
           
            if (this.state == 1)
            {
                // Continue to wait for data.
                udpClient.BeginReceive(new AsyncCallback(ReceiveCallback), null);

            }

        }

        /// <summary>
        /// Wait for messages in an asynchronous way.
        /// </summary>
        public void ReceiveMessages()
        {
            // Receive a message and write it to the console.

            udpClient.BeginReceive(new AsyncCallback(ReceiveCallback), null);

        }


    }


}
