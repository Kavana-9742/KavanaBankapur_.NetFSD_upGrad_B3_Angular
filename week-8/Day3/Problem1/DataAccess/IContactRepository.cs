using WebApplication13.Models;

namespace WebApplication13.Repository
{
    public interface IContactRepository
    {
        Task<List<ContactInfo>> GetAllContactsAsync();
        Task<ContactInfo?> GetContactByIdAsync(int id);
        Task<ContactInfo> AddContactAsync(ContactInfo contact);
        Task<bool> UpdateContactAsync(int id, ContactInfo contact);
        Task<bool> DeleteContactAsync(int id);
    }
}
