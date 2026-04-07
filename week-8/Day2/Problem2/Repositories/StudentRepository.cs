using Dapper;
using WebApplication11.Models;

namespace WebApplication11.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DapperContext _context;

        public StudentRepository(DapperContext context)
        {
            _context = context;
        }

        // 🔹 Students with Course
        public IEnumerable<Student> GetStudentsWithCourse()
        {
            using (var db = _context.CreateConnection())
            {
                string sql = @"SELECT s.StudentId, s.StudentName, s.CourseId,
                                      c.CourseId, c.CourseName
                               FROM Students s
                               INNER JOIN Courses c ON s.CourseId = c.CourseId";

                return db.Query<Student, Course, Student>(
                    sql,
                    (student, course) =>
                    {
                        student.Course = course;
                        return student;
                    },
                    splitOn: "CourseId"
                );
            }
        }

        // 🔹 Courses with Students
        public IEnumerable<Course> GetCoursesWithStudents()
        {
            using (var db = _context.CreateConnection())
            {
                string sql = @"SELECT c.CourseId, c.CourseName,
                                      s.StudentId, s.StudentName, s.CourseId
                               FROM Courses c
                               LEFT JOIN Students s ON c.CourseId = s.CourseId";

                var dict = new Dictionary<int, Course>();

                db.Query<Course, Student, Course>(
                    sql,
                    (course, student) =>
                    {
                        if (!dict.TryGetValue(course.CourseId, out var currentCourse))
                        {
                            currentCourse = course;
                            currentCourse.Students = new List<Student>();
                            dict.Add(currentCourse.CourseId, currentCourse);
                        }

                        if (student != null)
                        {
                            currentCourse.Students.Add(student);
                        }

                        return course;
                    },
                    splitOn: "StudentId"
                );

                return dict.Values;
            }
        }
    }
}
