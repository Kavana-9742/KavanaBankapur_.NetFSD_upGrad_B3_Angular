using System.Collections;
using System.Collections.Generic;
using Contact_Management.Models;

namespace Contact_Management.Services
{
    public interface ICompanyService
    {
        List<Company> GetAllCompanies();
    }
}
