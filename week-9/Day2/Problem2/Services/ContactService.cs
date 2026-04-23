using week_9_Day2_2.DTOs;
using week_9_Day2_2.Models;
using week_9_Day2_2.Repositories;

namespace week_9_Day2_2.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResponse<Contact>> GetContacts(int pageNumber, int pageSize)
        {
            // Default values
            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 5;

            int totalRecords = await _repository.GetTotalCount();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            int skip = (pageNumber - 1) * pageSize;

            var data = await _repository.GetPagedContacts(skip, pageSize);

            return new PagedResponse<Contact>
            {
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                Data = data
            };
        }
    }
}
