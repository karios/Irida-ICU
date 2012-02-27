using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICU
{
    /// <summary>
    /// An IVU is a visualisation Unit that communicates with the server 
    /// Using UDP. The server (Control Unit), receives messages from the 
    /// Wireless Sensors and send them to the registered Ivus.
    /// </summary>

    public class IvuInfo
    {
        private string ip;
        private int port;

        public IvuInfo(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }


        public string toString(){
            return string.Format("Ivu {0}, Socket {1}:{2}.", this.ip, this.port);
        }

        public string getIp(){
            return this.ip;
        }

        public int getPort()
        {
            return this.port;
        }


        public Boolean Equals(IvuInfo ivu)
        {
            if (ivu.getIp().Equals(this.getIp()) && ivu.getPort().Equals(ivu.getPort())) return true;
            return false;
        }


    }
}
