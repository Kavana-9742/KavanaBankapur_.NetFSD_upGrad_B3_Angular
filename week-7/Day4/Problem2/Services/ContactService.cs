using System.Collections.Generic;
using System.Linq;
using Contact_Management.Models;
using Contact_Management.Repositories;

namespace Contact_Management.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public List<ContactInfo> GetAllContacts()
        {
            return _contactRepository.GetAllContacts();
        }

        public ContactInfo GetContactById(int id)
        {
            return _contactRepository.GetContactById(id);
        }

        public void AddContact(ContactInfo contact)
        {
            _contactRepository.AddContact(contact);
        }

        public void UpdateContact(ContactInfo contact)
        {
            _contactRepository.UpdateContact(contact);
        }

        public void DeleteContact(int id)
        {
            _contactRepository.DeleteContact(id);
        }

        public bool IsEmailUnique(string email, int? contactId = null)
        {
            var contacts = _contactRepository.GetAllContacts();
            if (contactId.HasValue)
            {
                return !contacts.Any(c => c.EmailId == email && c.ContactId != contactId.Value);
            }
            return !contacts.Any(c => c.EmailId == email);
        }
    }
}
