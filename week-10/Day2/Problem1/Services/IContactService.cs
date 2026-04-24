using week_10_day2.Models;

namespace week_10_day2.Services
{
    public interface IContactService
    {
        List<Contact> GetAllContacts();
        Contact? GetContactById(int id);
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(int id);
    }
}
