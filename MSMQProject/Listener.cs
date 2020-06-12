using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSMQProject
{
    public class Listener
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Message");

            MessageQueue MyQueue;
            MyQueue = new MessageQueue(@".\Private$\MyQueue");

            Message MyMessage = MyQueue.Receive();
            MyMessage.Formatter = new BinaryMessageFormatter();

            Console.WriteLine(MyMessage.Body.ToString());
            Console.ReadLine();
        }
    }
}
