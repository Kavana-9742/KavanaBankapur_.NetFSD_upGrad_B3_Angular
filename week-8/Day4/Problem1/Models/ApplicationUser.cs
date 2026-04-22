using Microsoft.AspNetCore.Identity;

namespace week_8_day4.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; }
    }
}
