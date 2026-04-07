using WebApplication9.Models;

namespace WebApplication9.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<ContactInfo> GetAllContacts();
        ContactInfo GetContactById(int id);
        void AddContact(ContactInfo contact);
        void UpdateContact(ContactInfo contact);
        void DeleteContact(int id);

        // Dropdown
        IEnumerable<Company> GetCompanies();
        IEnumerable<Department> GetDepartments();
    }
}
