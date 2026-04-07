using Microsoft.AspNetCore.Mvc;
using WebApplication9.Models;
using WebApplication9.Repositories;

namespace WebApplication9.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _repo;

        public ContactController(IContactRepository repo)
        {
            _repo = repo;
        }

        public IActionResult ShowContacts()
        {
            var data = _repo.GetAllContacts();
            return View(data);
        }

        public IActionResult GetContactById(int id)
        {
            var data = _repo.GetContactById(id);
            return View("Details", data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Companies = _repo.GetCompanies();
            ViewBag.Departments = _repo.GetDepartments();
            return View("AddContact");
        }

        [HttpPost]
        public IActionResult Create(ContactInfo contact)
        {
            _repo.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

        public IActionResult EditContact(int id)
        {
            var data = _repo.GetContactById(id);
            ViewBag.Companies = _repo.GetCompanies();
            ViewBag.Departments = _repo.GetDepartments();
            return View(data);
        }

        [HttpPost]
        public IActionResult EditContact(ContactInfo contact)
        {
            _repo.UpdateContact(contact);
            return RedirectToAction("ShowContacts");
        }

        [HttpGet]
        public IActionResult DeleteContact(int id)
        {
            var data = _repo.GetContactById(id);
            return View(data);
        }

        [HttpPost("Delete")]
        public IActionResult DeleteConfirm(int ContactId)
        {
            _repo.DeleteContact(ContactId);
            return RedirectToAction("ShowContacts");
        }
    }
}
