using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICU
{

    /// <summary>
    /// Used to display in a correct way received messages
    /// </summary>
    class Notifier
    {

        static public void dataFromCom(string portName, string message){

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("(COM) Received from {0}: [{1}]", portName, message);

        }

        static public void dataFromUdp(string ip, int port, string message)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("(UDP) Received from {0}/{1}: [{1}]", ip, port, message);

        }

        static public void dataToUdp(string ip, int port, string message)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("(UDP) Send to {0}/{1}: [{2}]", ip, port, message);

        }

        static public void info(string message)
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Info : {0}", message);

        }

        static public void error(string message)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error : {0}", message);

        }

        static public void header(string message)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Error : {0}", message);

        }


    }
}
