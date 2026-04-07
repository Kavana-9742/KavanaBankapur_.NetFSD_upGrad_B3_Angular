using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication7.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Students()
        {
            var students = _context.Students.Include(s => s.Course).ToList();
            return View(students);
        }

        public IActionResult Courses()
        {
            var courses = _context.Courses.Include(c => c.Students).ToList();
            return View(courses);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
