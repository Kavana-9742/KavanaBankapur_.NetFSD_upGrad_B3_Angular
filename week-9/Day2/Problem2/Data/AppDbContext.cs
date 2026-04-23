using Microsoft.EntityFrameworkCore;
using week_9_Day2_2.Models;

namespace week_9_Day2_2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}

