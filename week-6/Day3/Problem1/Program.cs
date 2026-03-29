//SRP – Single Responsibility Principle
namespace SRP_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentRepository repo = new StudentRepository();

            repo.AddStudent(new Student { StudentId = 1, StudentName = "Kavana", Marks = 82 });
            repo.AddStudent(new Student { StudentId = 2, StudentName = "Rahul", Marks = 45 });
            repo.AddStudent(new Student { StudentId = 3, StudentName = "Anita", Marks = 30 });

            ReportGenerator report = new ReportGenerator();
            report.GenerateReport(repo.GetAllStudents());

            Console.ReadLine();
        }
    }
}
