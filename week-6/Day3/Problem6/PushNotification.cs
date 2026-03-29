using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    internal class PushNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Push notification sent: " + message);
        }
    }
    
}
