using Microsoft.EntityFrameworkCore;
using Contact_Management.Models;

namespace Contact_Management.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContactInfo> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactInfo>()
                .HasOne(c => c.Company)
                .WithMany(co => co.Contacts)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ContactInfo>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Contacts)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>().HasData(
                new Company { CompanyId = 1, CompanyName = "ABC Infotech" },
                new Company { CompanyId = 2, CompanyName = "XYZ Solutions" },
                new Company { CompanyId = 3, CompanyName = "Tech Innovators" },
                new Company { CompanyId = 4, CompanyName = "Global Systems" }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" },
                new Department { DepartmentId = 2, DepartmentName = "HR" },
                new Department { DepartmentId = 3, DepartmentName = "Finance" },
                new Department { DepartmentId = 4, DepartmentName = "Marketing" },
                new Department { DepartmentId = 5, DepartmentName = "Operations" }
            );
        }
    }
}
