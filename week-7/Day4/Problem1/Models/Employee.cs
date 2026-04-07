using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication7.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public double Salary { get; set; }

        [ForeignKey("DeptId")]
        public int DeptId { get; set; }
        public Dept Dept { get; set; }
    }
}
