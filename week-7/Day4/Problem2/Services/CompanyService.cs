using System.Collections.Generic;
using System.Linq;
using Contact_Management.Models;

namespace Contact_Management.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDbContext _context;
        public CompanyService(AppDbContext context)
        {
            _context = context;
        }
        public List<Company> GetAllCompanies()
        {
            return _context.Companies.ToList();
        }
    }
}
