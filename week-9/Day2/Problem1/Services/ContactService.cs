using week_9_Day2.Models;
using week_9_Day2.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace week_9_Day2.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        private readonly IMemoryCache _cache;

        public ContactService(IContactRepository repository, IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public List<Contact> GetAllContacts()
        {
            string cacheKey = "contactList";

            if (!_cache.TryGetValue(cacheKey, out List<Contact> contacts))
            {
                // Fetch from DB
                contacts = _repository.GetAll();

                // Set cache (60 seconds)
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(60));

                _cache.Set(cacheKey, contacts, cacheOptions);
            }
            else
            {
                Console.WriteLine("Fetching from CACHE...");
            }

            return contacts;
        }

        public Contact GetContactById(int id)
        {
            string cacheKey = $"contact_{id}";

            if (!_cache.TryGetValue(cacheKey, out Contact contact))
            {
                // Fetch from DB
                contact = _repository.GetById(id);

                if (contact != null)
                {
                    var cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(60));

                    _cache.Set(cacheKey, contact, cacheOptions);
                }
            }
            else
            {
                Console.WriteLine($"Fetching Contact {id} from CACHE...");
            }

            return contact;
        }
    }

    public interface IContactRepository
    {
        List<Contact> GetAll();
        Contact GetById(int id);
    }
}
