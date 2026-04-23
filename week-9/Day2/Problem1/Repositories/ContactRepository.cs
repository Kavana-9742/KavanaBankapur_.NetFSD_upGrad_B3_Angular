using week_9_Day2.Models;

namespace week_9_Day2.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts;
        public ContactRepository()
        {
            _contacts = new List<Contact>
        {
            new Contact {Id = 1, Name = "Arya", Email="arya@gmail.com"},
            new Contact {Id = 2, Name = "Shravya", Email="sh123@gmail.com" }
        };
        }
        public List<Contact> GetAll()
        {
            Console.WriteLine("Fetching from DATABASE...");
            return _contacts;
        }

        public Contact GetById(int id)
        {
            Console.WriteLine($"Fetching Contact {id} from DATABASE...");
            return _contacts.FirstOrDefault(c => c.Id == id);
        }
    }
}
