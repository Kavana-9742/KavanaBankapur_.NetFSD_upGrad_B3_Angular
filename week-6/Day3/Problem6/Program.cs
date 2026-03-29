namespace Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NotificationFactory factory = new NotificationFactory();

            INotification notification1 = factory.CreateNotification("email");
            notification1.Send("Welcome to our service!");

            INotification notification2 = factory.CreateNotification("sms");
            notification2.Send("Your OTP is 1234");

            INotification notification3 = factory.CreateNotification("push");
            notification3.Send("You have a new alert");

            Console.ReadLine();
        }
    }
}
