using Dapper;
using WebApplication9.Data;
using System.Data;
using WebApplication9.Models;

namespace WebApplication9.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DapperContext _context;

        public ContactRepository(DapperContext context)
        {
            _context = context;
        }

        public IEnumerable<ContactInfo> GetAllContacts()
        {
            var sql = @"SELECT 
                c.ContactId,
                c.FirstName,
                c.LastName,
                c.EmailId,
                c.MobileNo,
                c.Designation,
                c.CompanyId,
                c.DepartmentId,
                comp.CompanyName,
                dept.DepartmentName
            FROM ContactInfo c
            LEFT JOIN Company comp ON c.CompanyId = comp.CompanyId
            LEFT JOIN Department dept ON c.DepartmentId = dept.DepartmentId";

            using (var db = _context.CreateConnection())
            {
                return db.Query<ContactInfo>(sql);
            }
        }

        public ContactInfo GetContactById(int id)
        {
            var sql = @"SELECT 
                c.ContactId,
                c.FirstName,
                c.LastName,
                c.EmailId,
                c.MobileNo,
                c.Designation,
                c.CompanyId,
                c.DepartmentId,
                comp.CompanyName,
                dept.DepartmentName
            FROM ContactInfo c
            LEFT JOIN Company comp ON c.CompanyId = comp.CompanyId
            LEFT JOIN Department dept ON c.DepartmentId = dept.DepartmentId
            WHERE c.ContactId = @Id";

            using (var db = _context.CreateConnection())
            {
                return db.QueryFirstOrDefault<ContactInfo>(sql, new { Id = id });
            }
        }

        public void AddContact(ContactInfo contact)
        {
            var sql = @"INSERT INTO ContactInfo
        (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
        VALUES (@FirstName, @LastName, @EmailId, @MobileNo, @Designation, @CompanyId, @DepartmentId)";

            using (var db = _context.CreateConnection())
            {
                db.Execute(sql, contact);
            }
        }

        public void UpdateContact(ContactInfo contact)
        {
            var sql = @"UPDATE ContactInfo SET
                FirstName = @FirstName,
                LastName = @LastName,
                EmailId = @EmailId,
                MobileNo = @MobileNo,
                Designation = @Designation,
                CompanyId = @CompanyId,
                DepartmentId = @DepartmentId
            WHERE ContactId = @ContactId";

            using (var db = _context.CreateConnection())
            {
                db.Execute(sql, contact);
            }
        }

        public void DeleteContact(int id)
        {
            var sql = "DELETE FROM ContactInfo WHERE ContactId=@Id";

            using (var db = _context.CreateConnection())
            {
                db.Execute(sql, new { Id = id });
            }
        }

        public IEnumerable<Company> GetCompanies()
        {
            using (var db = _context.CreateConnection())
            {
                return db.Query<Company>("SELECT * FROM Company").ToList();
            }
        }

        public IEnumerable<Department> GetDepartments()
        {

            using (var db = _context.CreateConnection())
            {
                return db.Query<Department>("SELECT * FROM Department").ToList();
            }
        }
    }
}
