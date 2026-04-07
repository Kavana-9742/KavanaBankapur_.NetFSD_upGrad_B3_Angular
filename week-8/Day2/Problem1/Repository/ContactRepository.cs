using Dapper;
using WebApplication10.Models;

namespace WebApplication10.Repository
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
            using (var db = _context.CreateConnection())
            {
                string sql = @"SELECT c.*, comp.CompanyId, comp.CompanyName,
                                        d.DepartmentId, d.DepartmentName
                                FROM ContactInfo c
                                INNER JOIN Company comp ON c.CompanyId = comp.CompanyId
                                LEFT JOIN Department d ON c.DepartmentId = d.DepartmentId";

                return db.Query<ContactInfo, Company, Department, ContactInfo>(
                    sql,
                    (contact, company, dept) =>
                    {
                        contact.Company = company;
                        contact.Department = dept;
                        return contact;
                    },
                    splitOn: "CompanyId,DepartmentId"
                );
            }
        }
        public ContactInfo GetContactById(int id)
        {
            using (var db = _context.CreateConnection())
            {
                string sql = @"SELECT c.*, comp.CompanyId, comp.CompanyName,
                              d.DepartmentId, d.DepartmentName
                       FROM ContactInfo c
                       INNER JOIN Company comp ON c.CompanyId = comp.CompanyId
                       LEFT JOIN Department d ON c.DepartmentId = d.DepartmentId
                       WHERE c.ContactId = @Id";

                return db.Query<ContactInfo, Company, Department, ContactInfo>(
                    sql,
                    (contact, company, dept) =>
                    {
                        contact.Company = company;
                        contact.Department = dept;
                        return contact;
                    },
                    new { Id = id },
                    splitOn: "CompanyId,DepartmentId"
                ).FirstOrDefault();
            }
        }

        public void AddContact(ContactInfo contact)
        {
            using (var db = _context.CreateConnection())
            {
                string sql = @"INSERT INTO ContactInfo 
                (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
                VALUES (@FirstName, @LastName, @EmailId, @MobileNo, @Designation, @CompanyId, @DepartmentId)";

                db.Execute(sql, contact);
            }
        }

        public void UpdateContact(ContactInfo contact)
        {
            using (var db = _context.CreateConnection())
            {
                string sql = @"UPDATE ContactInfo SET 
                            FirstName=@FirstName,
                            LastName=@LastName,
                            EmailId=@EmailId,
                            MobileNo=@MobileNo,
                            Designation=@Designation,
                            CompanyId=@CompanyId,
                            DepartmentId=@DepartmentId
                           WHERE ContactId=@ContactId";

                db.Execute(sql, contact);
            }
        }

        public void DeleteContact(int id)
        {
            using (var db = _context.CreateConnection())
            {
                db.Execute("DELETE FROM ContactInfo WHERE ContactId=@Id", new { Id = id });
            }
        }

        public IEnumerable<Company> GetCompanies()
        {
            using (var db = _context.CreateConnection())
            {
                return db.Query<Company>("SELECT * FROM Company");
            }
        }

        public IEnumerable<Department> GetDepartments()
        {
            using (var db = _context.CreateConnection())
            {
                return db.Query<Department>("SELECT * FROM Department");
            }
        }
    }
}
