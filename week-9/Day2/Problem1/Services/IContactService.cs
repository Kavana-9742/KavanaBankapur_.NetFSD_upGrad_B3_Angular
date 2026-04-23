using week_9_Day2.Models;
using week_9_Day2.Repositories;

namespace week_9_Day2.Services
{
    public interface IContactService
    {
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
    }
}
