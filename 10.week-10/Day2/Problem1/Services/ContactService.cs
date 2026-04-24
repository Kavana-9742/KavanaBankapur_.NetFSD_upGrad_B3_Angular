using week_10_day2.Models;
using week_10_day2.Repositories;

namespace week_10_day2.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }
        public List<Contact> GetAllContacts()
        { 
            return _repository.GetAll();
        }
        public Contact? GetContactById(int id)
        {
            return _repository.GetById(id);
        }
        public void AddContact(Contact contact)
        {
            Validate(contact);
            _repository.Add(contact);
        }

        public void UpdateContact(Contact contact)
        {
            Validate(contact);
            _repository.Update(contact);
        }

        public void DeleteContact(int id)
        {
            _repository.Delete(id);
        }
        private void Validate(Contact contact)
        {
            if (string.IsNullOrWhiteSpace(contact.Name))
                throw new ArgumentException("Name required");

            if (string.IsNullOrWhiteSpace(contact.Email))
                throw new ArgumentException("Email required");

            if (string.IsNullOrWhiteSpace(contact.Phone))
                throw new ArgumentException("Phone required");
        }
    }
}
