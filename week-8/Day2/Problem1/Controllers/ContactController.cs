using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication10.Models;
using WebApplication10.Repository;

namespace WebApplication10.Controllers
{
    [Route("Contacts")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _repo;

        public ContactController(IContactRepository repo)
        {
            _repo = repo;
        }

        // 🔹 LIST
        [HttpGet("")]
        public IActionResult ShowContacts()
        {
            var data = _repo.GetAllContacts();
            return View(data);
        }

        // 🔹 DETAILS
        [HttpGet("Details/{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _repo.GetContactById(id);
            return View("Details", contact);
        }

        // 🔹 ADD GET
        [HttpGet("Add")]
        public IActionResult AddContact()
        {
            ViewBag.Companies = new SelectList(_repo.GetCompanies(), "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(_repo.GetDepartments(), "DepartmentId", "DepartmentName");

            return View();
        }

        // 🔹 ADD POST
        [HttpPost("Add")]
        public IActionResult AddContact(ContactInfo contact)
        {
            _repo.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

        // 🔹 EDIT GET
        [HttpGet("Edit/{id}")]
        public IActionResult EditContact(int id)
        {
            var contact = _repo.GetContactById(id);

            ViewBag.Companies = new SelectList(_repo.GetCompanies(), "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(_repo.GetDepartments(), "DepartmentId", "DepartmentName");

            return View(contact);
        }

        // 🔹 EDIT POST
        [HttpPost("Edit")]
        public IActionResult EditContact(ContactInfo contact)
        {
            _repo.UpdateContact(contact);
            return RedirectToAction("ShowContacts");
        }

        // 🔹 DELETE
        [HttpGet("Delete/{id}")]
        public IActionResult DeleteContact(int id)
        {
            _repo.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }
    }
}
