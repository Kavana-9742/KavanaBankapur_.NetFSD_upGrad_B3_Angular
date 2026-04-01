using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    [Route("Feedback")]
    public class FeedbackController : Controller
    {
        [HttpGet("Form")]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost("Submit")]
        public IActionResult Submit(string name, string cooments, int rating)
        {
            if (rating >= 4)
            {
                ViewData["Message"] = "Thank you for your positive feedback!";
            }
            else
            {
                ViewData["Message"] = "We will improve based on your feedback.";
            }
            ViewData["UserName"] = name;

            return View("Form");
        }
    }
}
