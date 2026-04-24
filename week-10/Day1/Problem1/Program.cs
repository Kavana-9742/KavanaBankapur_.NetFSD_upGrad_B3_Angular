using week_10_day1.Models;
using week_10_day1.Services;

namespace week_10_day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IContactService service = new ContactService();

            service.AddContact(new Contact
            {
                Name = "Kavana",
                Email = "kavana@email.com",
                Phone = "9876543210"
            });

            service.AddContact(new Contact
            {
                Name = "Rahul",
                Email = "rahul@email.com",
                Phone = "9123456780"
            });

            Console.WriteLine("All Contacts:");
            foreach (var contact in service.GetAllContacts())
            {
                Console.WriteLine($"{contact.Id} - {contact.Name} - {contact.Email} - {contact.Phone}");
            }
        }
    }
}
