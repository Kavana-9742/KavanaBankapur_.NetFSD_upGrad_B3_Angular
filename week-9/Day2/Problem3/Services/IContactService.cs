using week_9_Day2_3.Models;
using week_9_Day2_3.Repository;

namespace week_9_Day2_3.Services
{
    public interface IContactService
    {
        List<Contact> GetContacts();
    }
}
