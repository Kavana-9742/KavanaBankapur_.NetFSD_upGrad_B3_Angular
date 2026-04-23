using week_9_Day2_2.DTOs;
using week_9_Day2_2.Models;

namespace week_9_Day2_2.Services
{
    public interface IContactService
    {
        Task<PagedResponse<Contact>> GetContacts(int pageNumber, int pageSize);
    }
}
