using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using week_10_day2.Models;
using week_10_day2.Services;

namespace week_10_day2.Controllers
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
            return Ok(_service.GetAllContacts());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _service.GetContactById(id);
            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            _service.AddContact(contact);
            return Created("", contact);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact contact)
        {
            contact.Id = id;
            _service.UpdateContact(contact);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteContact(id);
            return Ok();
        }
    }
}
