using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication13.Models;
using WebApplication13.Repository;

namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repository;

        public ContactsController(IContactRepository repository)
        {
            _repository = repository;

            if (_repository.GetAllContactsAsync().Result.Count == 0)
            {
                _repository.AddContactAsync(new ContactInfo
                {
                    FirstName = "Kavana",
                    LastName = "B",
                    EmailId = "user@example.com",
                    MobileNo = 9876543210,
                    Designation = "Developer",
                    CompanyId = 1,
                    DepartmentId = 1
                }).Wait();
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactInfo>>> GetAll()
        {
            var contacts = await _repository.GetAllContactsAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactInfo>> GetById(int id)
        {
            var contact = await _repository.GetContactByIdAsync(id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult<ContactInfo>> Create(ContactInfo contact)
        {
            if (string.IsNullOrWhiteSpace(contact.FirstName) || string.IsNullOrWhiteSpace(contact.EmailId))
                return BadRequest("FirstName and EmailId are required");

            var createdContact = await _repository.AddContactAsync(contact);
            return CreatedAtAction(nameof(GetById), new { id = createdContact.ContactId }, createdContact);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ContactInfo contact)
        {
            var updated = await _repository.UpdateContactAsync(id, contact);
            if (!updated) return NotFound();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteContactAsync(id);
            if (!deleted) return NotFound();
            return Ok();
        }
    }
}
