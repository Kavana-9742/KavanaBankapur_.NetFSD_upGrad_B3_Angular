using Microsoft.AspNetCore.Mvc;
using WebApplication11.Repositories;

namespace WebApplication11.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repo;

        public StudentController(IStudentRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("")]
        public IActionResult StudentsList()
        {
            var data = _repo.GetStudentsWithCourse();
            return View("StudentsList", data);
        }

        [HttpGet("Courses")]
        public IActionResult CoursesList()
        {
            var data = _repo.GetCoursesWithStudents();
            return View("CoursesList", data);
        }
    }
}
