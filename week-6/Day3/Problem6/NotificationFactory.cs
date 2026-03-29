using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    internal class NotificationFactory
    {
        public INotification CreateNotification(string type)
        {
            if (type.ToLower() == "email")
                return new EmailNotification();

            else if (type.ToLower() == "sms")
                return new SMSNotification();

            else if (type.ToLower() == "push")
                return new PushNotification();

            else
                throw new Exception("Invalid notification type");
        }
    }
}
