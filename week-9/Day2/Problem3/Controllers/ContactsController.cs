using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using week_9_Day2_3.Services;

namespace week_9_Day2_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        // Apply rate limit to this endpoint
        [HttpGet]
        public IActionResult Get()
        {
            var data = _service.GetContacts();
            return Ok(data);
        }
    }
}
