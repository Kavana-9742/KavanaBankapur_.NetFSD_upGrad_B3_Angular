namespace Repository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStudentRepository repo = new StudentRepository();
            StudentService service = new StudentService(repo);

            service.AddStudent(new Student { StudentId = 1, StudentName = "Kavana", Course = "C#" });
            service.AddStudent(new Student { StudentId = 2, StudentName = "Rahul", Course = "Java" });

            Console.WriteLine("All Students:");
            service.DisplayStudents();

            Console.WriteLine("\nFind Student ID 1:");
            service.FindStudent(1);

            Console.WriteLine("\nDelete Student ID 2:");
            service.DeleteStudent(2);

            Console.WriteLine("\nStudents After Deletion:");
            service.DisplayStudents();

            Console.ReadLine();
        }
    }
}
