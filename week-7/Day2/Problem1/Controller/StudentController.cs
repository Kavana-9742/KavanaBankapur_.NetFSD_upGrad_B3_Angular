using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    [Route("Student")]
    public class StudentController : Controller
    {
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public IActionResult Register(string StudentName, int Age, string Course)
        {
            TempData["Name"] = StudentName;
            TempData["Age"] = Age;
            TempData["Course"] = Course;

            return RedirectToAction("Display");
        }

        [HttpGet("Display")]
        public IActionResult Display()
        {
            ViewBag.Name = TempData["Name"];
            ViewBag.Age = TempData["Age"];
            ViewBag.Course = TempData["Course"];

            return View();
        }
    }
}
