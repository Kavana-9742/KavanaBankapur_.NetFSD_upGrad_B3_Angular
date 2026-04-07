using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contact_Management.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        public ICollection<ContactInfo> Contacts { get; set; }
    }
}
