using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using ICU.Net;

namespace ICU
{
    class Program
    {
        static void Main(string[] args)
        {
            Notifier.header("############################################################");
            Notifier.header("###########  ~°~   Welcome to the ICU 0.0   ~°~  ###########");
            Notifier.header("############################################################");
            Notifier.header("");

            // Listen from UDP for incoming requests
            UdpReceive recv = new UdpReceive();


            // Read from the COMPORT
            ComReader comReader = new ComReader();
            
            //UdpSend.Instance.SendMessage("127.0.0.1", 5000, "HELLOOO");
            
            // And that's it !
            Console.ReadLine();
            
        }
    }
}
