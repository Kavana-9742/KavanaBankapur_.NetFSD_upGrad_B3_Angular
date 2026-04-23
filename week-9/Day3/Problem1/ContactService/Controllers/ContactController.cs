using ContactService.Models;
using ContactService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) =>
            Ok(await _service.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Post(Contact contact) =>
            Ok(await _service.Add(contact));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Contact contact)
        {
            contact.ContactId = id;
            await _service.Update(contact);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
