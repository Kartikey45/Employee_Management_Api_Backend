using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Experimental.System.Messaging;

namespace EmployeeManagementAPIProject
{
    public class Sender
    {
        // Method For Message 
        public void Message(string SendMessage)
        {

            MessageQueue MyQueue;
            if (MessageQueue.Exists(@".\Private$\myQueue"))
            {
                MyQueue = new MessageQueue(@".\Private$\myQueue");
            }
            else
            {
                MyQueue = MessageQueue.Create(@".\Private$\myQueue");
            }
            Message MyMessage = new Message();
            MyMessage.Formatter = new BinaryMessageFormatter();
            MyMessage.Body = SendMessage;
            MyMessage.Label = "UserRegistration";
            MyMessage.Priority = MessagePriority.Normal;
            MyQueue.Send(MyMessage);
        }
    }
}
