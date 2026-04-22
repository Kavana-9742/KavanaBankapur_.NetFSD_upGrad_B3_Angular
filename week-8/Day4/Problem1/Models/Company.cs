using Microsoft.EntityFrameworkCore;
using week_8_day4.Models;

namespace week_8_day4.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public ICollection<ContactInfo> Contacts { get; set; }
    }
}
