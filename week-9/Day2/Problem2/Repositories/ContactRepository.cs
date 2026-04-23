using Microsoft.EntityFrameworkCore;
using week_9_Day2_2.Data;
using week_9_Day2_2.Models;

namespace week_9_Day2_2.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetPagedContacts(int skip, int take)
        {
            return await _context.Contacts
                .OrderBy(c => c.ContactId)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<int> GetTotalCount()
        {
            return await _context.Contacts.CountAsync();
        }
    }
}
