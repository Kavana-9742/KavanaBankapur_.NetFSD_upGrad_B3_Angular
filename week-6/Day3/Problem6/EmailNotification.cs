using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    internal class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Email sent: " + message);
        }
    }
    
}
