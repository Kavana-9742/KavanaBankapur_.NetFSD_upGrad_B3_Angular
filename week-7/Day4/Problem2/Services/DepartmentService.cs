using System.Collections.Generic;
using System.Linq;
using Contact_Management.Models;

namespace Contact_Management.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;
        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }
        public List<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }
    }
}
