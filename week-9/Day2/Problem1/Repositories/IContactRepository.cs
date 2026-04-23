using week_9_Day2.Models;

namespace week_9_Day2.Repositories
{
    public interface IContactRepository
    {
        List<Contact> GetAll();
        Contact GetById(int id);
    }
}
