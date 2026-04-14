using WebApplication13.Models;
using WebApplication13.Repository;

namespace WebApplication13.DataAccess
{
    public class ContactRepository : IContactRepository
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>();
        private static int nextId = 1;

        public async Task<List<ContactInfo>> GetAllContactsAsync()
        {
            return await Task.FromResult(contacts);
        }

        public async Task<ContactInfo?> GetContactByIdAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            return await Task.FromResult(contact);
        }

        public async Task<ContactInfo> AddContactAsync(ContactInfo contact)
        {
            contact.ContactId = nextId++;
            contacts.Add(contact);
            return await Task.FromResult(contact);
        }

        public async Task<bool> UpdateContactAsync(int id, ContactInfo contact)
        {
            var existingContact = contacts.FirstOrDefault(c => c.ContactId == id);
            if (existingContact == null)
                return await Task.FromResult(false);

            existingContact.FirstName = contact.FirstName;
            existingContact.LastName = contact.LastName;
            existingContact.EmailId = contact.EmailId;
            existingContact.MobileNo = contact.MobileNo;
            existingContact.Designation = contact.Designation;
            existingContact.CompanyId = contact.CompanyId;
            existingContact.DepartmentId = contact.DepartmentId;

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteContactAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            if (contact == null)
                return await Task.FromResult(false);

            contacts.Remove(contact);
            return await Task.FromResult(true);
        }
    }
}
