using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICU.Net;
using System.Text.RegularExpressions;

namespace ICU.Com
{
    class ComPacketParsing
    {
        private UdpSend udpSend;

        public ComPacketParsing()
        {
            this.udpSend = UdpSend.Instance;
        }

        public void parse(string data)
        {

            // Split the message to get only the visual part.
            if ((data.IndexOf("IRIDA") ==-1)) return;
            
            string[] parts = Regex.Split(data, "IRIDA");


            // Send the message to all ivus.
            UdpSend.Instance.broadcastMessage(parts[1]);
            
            return;
        }

    }
}
