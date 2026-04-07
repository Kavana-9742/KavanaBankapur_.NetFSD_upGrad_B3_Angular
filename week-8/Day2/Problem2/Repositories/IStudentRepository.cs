using WebApplication11.Models;

namespace WebApplication11.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudentsWithCourse();
        IEnumerable<Course> GetCoursesWithStudents();
    }
}
