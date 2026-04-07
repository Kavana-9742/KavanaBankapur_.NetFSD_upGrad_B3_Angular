using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Contact_Management.Models;
using Contact_Management.Services;

namespace Contact_Management.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly ICompanyService _companyService;
        private readonly IDepartmentService _departmentService;

        public ContactController(
            IContactService contactService,
            ICompanyService companyService,
            IDepartmentService departmentService)
        {
            _contactService = contactService;
            _companyService = companyService;
            _departmentService = departmentService;
        }

        // GET: contacts
        [HttpGet("")]
        [HttpGet("index")]
        public IActionResult Index()
        {
            var contacts = _contactService.GetAllContacts();
            return View(contacts);
        }

        // GET: contacts/details/5
        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            var contact = _contactService.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // GET: contacts/create
        [HttpGet("create")]
        public IActionResult Create()
        {
            LoadDropdowns();
            return View();
        }

        // POST: contacts/create
        [HttpPost("create")]
[ValidateAntiForgeryToken]
public IActionResult Create(ContactInfo contact)
{
    if (!ModelState.IsValid)
    {
        LoadDropdowns();
        return View(contact);
    }

    if (!_contactService.IsEmailUnique(contact.EmailId))
    {
        ModelState.AddModelError("EmailId", "Email already exists");
        LoadDropdowns();
        return View(contact);
    }

    _contactService.AddContact(contact);
    TempData["SuccessMessage"] = "Contact added successfully!";
    return RedirectToAction("Index");
}

        // GET: contacts/edit/5
        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var contact = _contactService.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }

            LoadDropdowns();
            return View(contact);
        }

        // POST: contacts/edit/5
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ContactInfo contact)
        {
            if (id != contact.ContactId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                if (!_contactService.IsEmailUnique(contact.EmailId, contact.ContactId))
                {
                    ModelState.AddModelError("EmailId", "Email already exists");
                    LoadDropdowns();
                    return View(contact);
                }

                _contactService.UpdateContact(contact);
                TempData["SuccessMessage"] = "Contact updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            LoadDropdowns();
            return View(contact);
        }

        // GET: contacts/delete/5
        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var contact = _contactService.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // POST: contacts/delete/5
        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _contactService.DeleteContact(id);
            TempData["SuccessMessage"] = "Contact deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

        private void LoadDropdowns()
        {
            ViewBag.Companies = new SelectList(_companyService.GetAllCompanies(), "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(_departmentService.GetAllDepartments(), "DepartmentId", "DepartmentName");
        }
    }
}
