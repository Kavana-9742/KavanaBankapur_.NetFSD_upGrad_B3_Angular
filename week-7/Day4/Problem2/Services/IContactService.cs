using System.Collections.Generic;
using Contact_Management.Models;

namespace Contact_Management.Services
{
    public interface IContactService
    {
        List<ContactInfo> GetAllContacts();
        ContactInfo GetContactById(int id);
        void AddContact(ContactInfo contact);
        void UpdateContact(ContactInfo contact);
        void DeleteContact(int id);
        bool IsEmailUnique(string email, int? contactId = null);
    }
}
