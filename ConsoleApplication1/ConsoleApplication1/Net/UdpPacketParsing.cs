using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace ICU.Net
{
    /// <summary>
    /// Parse the incoming messages from the network.
    /// </summary>
    class UdpPacketParsing
    {

        public void parse(string message, IPEndPoint ipEndPoint)
        {

            // cut the message in parts
            string[] parts = message.Split(' ');
            string ip = ipEndPoint.Address.ToString();
            
            // get the function name
            string funcName = parts[0];

                        
            Notifier.dataFromUdp(ip, ipEndPoint.Port, message);

            switch (funcName)
            {

                case "register":
                    // Register the new IVU
                    this.register(ip, Convert.ToInt32(parts[1]));
                    break;


                case "unregister":
                    // Unregister an IVU
                    break;

            }

        }

        public void register(string ip, int port)
        {
            // Prepare the ivu.
            IvuInfo ivu = new IvuInfo(ip, port);

            // Add the ivu only if it doesn't exist already
            if (!IvuDB.Instance.exists(ivu))
            {
                IvuDB.Instance.addIvu(ivu);
                Notifier.dataFromUdp(ip, port, "IVU registered.");
            }

            

            // Send back to the ivu the welcome message.
            //UdpSend.Instance.SendMessage(ip, port, "heartBeat Laetitia 0.5 0.5");


        }

    }
}
