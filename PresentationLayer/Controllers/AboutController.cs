using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace PresentationLayer.Controllers
{
    public class AboutController : Controller
    {
        AboutManager _aboutManager = new AboutManager(new EFAboutDAL());
        [HttpGet]
        public IActionResult Index()
        {
            var value = _aboutManager.TGetByID(1);
            return View(value);
        }

        // About sayfasında title ve description güncellemek için
        [HttpPost]
        public IActionResult Index(About about, IFormFile imageFile)
        {
            var existingAbout = _aboutManager.TGetByID(about.AboutId);

            if (existingAbout != null)
            {
                existingAbout.Title = about.Title;
                existingAbout.Description = about.Description;
                existingAbout.Age = about.Age;
                existingAbout.Name = about.Name;
                existingAbout.Phone = about.Phone;
                existingAbout.Address = about.Address;

                if (imageFile != null && imageFile.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageFile.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }
                    existingAbout.ImageUrl = "/images/" + imageFile.FileName;
                }

                _aboutManager.TUpdate(existingAbout);
            }

            return RedirectToAction("Index");
        }
    }
}
