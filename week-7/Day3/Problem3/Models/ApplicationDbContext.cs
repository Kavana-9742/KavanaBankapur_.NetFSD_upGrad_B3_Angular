using Microsoft.EntityFrameworkCore;

namespace Movie_Catalog.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
    }
}
