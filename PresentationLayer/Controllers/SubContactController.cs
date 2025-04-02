using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class SubContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EFContactDAL());
        [HttpGet]
        public IActionResult Index()
        {
            var contactValue = contactManager.TGetByID(1); // Örnek olarak ID 1 olan veriyi alıyoruz
            return View(contactValue);
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            var existingContact = contactManager.TGetByID(contact.ContactId);

            if (existingContact != null)
            {
                existingContact.Title = contact.Title;
                existingContact.Description = contact.Description;
                existingContact.Mail = contact.Mail;
                existingContact.Phone = contact.Phone;

                contactManager.TUpdate(existingContact);
            }

            return RedirectToAction("Index");
        }

    }
}
