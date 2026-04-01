using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    [Route("Calculator")]
    public class CalculatorController : Controller
    {
        [HttpGet("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("Add")]
        public IActionResult Add(int num1, int num2)
        {
            int result = num1 + num2;
            ViewData["Result"] = result;
            return View();
        }
    }
}
