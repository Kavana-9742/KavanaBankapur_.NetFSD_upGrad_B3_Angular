using week_9_Day2_2.Models;

namespace week_9_Day2_2.Repositories
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetPagedContacts(int skip, int take);
        Task<int> GetTotalCount();
    }
}
