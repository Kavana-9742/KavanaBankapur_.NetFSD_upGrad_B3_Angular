using Microsoft.EntityFrameworkCore;

namespace week_9_day1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Models.UserInfo> UserInfos { get; set; }
        public DbSet<Models.Contact> Contacts { get; set; }
    }
}
