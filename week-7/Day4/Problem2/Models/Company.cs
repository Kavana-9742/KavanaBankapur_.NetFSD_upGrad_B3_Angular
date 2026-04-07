using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contact_Management.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        public ICollection<ContactInfo> Contacts { get; set; }
    }
}
