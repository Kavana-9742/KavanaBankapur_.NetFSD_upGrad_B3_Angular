using System.Collections.Generic;
using Contact_Management.Models;

namespace Contact_Management.Repositories
{
    public interface IContactRepository 
    {
        List<ContactInfo> GetAllContacts();
        ContactInfo GetContactById(int id);
        void AddContact(ContactInfo contact);
        void UpdateContact(ContactInfo contact);
        void DeleteContact(int id);
    }
}
