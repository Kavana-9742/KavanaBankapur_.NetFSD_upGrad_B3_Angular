using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using week_9_Day2.Services;

namespace week_9_Day2.Controllers
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

        [HttpGet]
        public IActionResult GetAll()
        {
            var contacts = _service.GetAllContacts();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _service.GetContactById(id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }
    }
}
