using week_9_Day2_3.Models;
using week_9_Day2_3.Repository;

namespace week_9_Day2_3.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;
        public ContactService(IContactRepository repo)
        {
            _repo = repo;
        }

        public List<Contact> GetContacts()
        {
            return _repo.GetAll();
        }
    }
}
