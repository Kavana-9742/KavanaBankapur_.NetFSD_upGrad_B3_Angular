using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Contact_Management.Models
{
    public class ContactInfo
    {
        [Key]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100)]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        public long MobileNo { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Company is required")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public int DepartmentId { get; set; }

        public Company Company { get; set; }
        public Department Department { get; set; }
    }
}
