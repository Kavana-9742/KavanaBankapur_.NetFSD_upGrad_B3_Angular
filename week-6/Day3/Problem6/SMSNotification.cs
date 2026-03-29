using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    internal class SMSNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("SMS sent: " + message);
        }
    }
    
}
