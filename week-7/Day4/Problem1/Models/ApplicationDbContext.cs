using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                        .HasOne(e => e.Course)
                        .WithMany(d => d.Students)
                        .HasForeignKey(e => e.CourseId);
        }
    }
}
