using week_9_Day2_3.Models;

namespace week_9_Day2_3.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts = new()
        {
            new Contact { ContactId = 1, Name = "John", Email = "john@test.com", Phone = "9999999999" },
            new Contact { ContactId = 2, Name = "Sara", Email = "sara@test.com", Phone = "8888888888" },
            new Contact { ContactId = 3, Name = "Alex", Email = "alex@test.com", Phone = "7777777777" },
            new Contact { ContactId = 4, Name = "Maya", Email = "maya@test.com", Phone = "6666666666" },
            new Contact { ContactId = 5, Name = "Ravi", Email = "ravi@test.com", Phone = "5555555555" }
        };

        public List<Contact> GetAll() => _contacts;
    }
}
