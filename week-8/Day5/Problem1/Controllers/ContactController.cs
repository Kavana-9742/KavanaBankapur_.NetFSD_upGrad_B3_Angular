using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using week_8_Day5.Exceptions;

namespace week_8_Day5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Invalid contact ID");
            }

            if (id == 100)
            {
                throw new NotFoundException("Contact not found");
            }

            _logger.LogInformation("Contact fetched successfully");

            return Ok(new { Id = id, Name = "John Doe" });
        }

        [HttpPost]
        public IActionResult CreateContact()
        {
            _logger.LogInformation("Contact created");

            return Ok("Contact created successfully");
        }

        [HttpPut]
        public IActionResult UpdateContact()
        {
            _logger.LogInformation("Contact updated");

            return Ok("Contact updated successfully");
        }

        [HttpDelete]
        public IActionResult DeleteContact()
        {
            _logger.LogWarning("Contact deleted");

            return Ok("Contact deleted successfully");
        }
    }
}
