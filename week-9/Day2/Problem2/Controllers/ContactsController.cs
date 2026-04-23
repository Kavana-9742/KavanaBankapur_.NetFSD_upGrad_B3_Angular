using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using week_9_Day2_2.Services;

namespace week_9_Day2_2.Controllers
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
        public async Task<IActionResult> GetContacts(int pageNumber = 1, int pageSize = 5)
        {
            var result = await _service.GetContacts(pageNumber, pageSize);
            return Ok(result);
        }
    }
}
