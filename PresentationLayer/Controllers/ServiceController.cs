using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace PresentationLayer.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager _serviceManager = new ServiceManager(new EFServiceDAL());
        public IActionResult Index()
        {
            var values = _serviceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Service service)
        {
            _serviceManager.TAdd(service);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var value = _serviceManager.TGetByID(id);
            _serviceManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _serviceManager.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult Update(Service service, IFormFile Image)
        {
            var existingService = _serviceManager.TGetByID(service.ServiceId);

            if (Image != null && Image.Length > 0)
            {
                // Yeni resim yüklendiğinde, resmi kaydedin ve yolunu service.ImageUrl'ye atayın
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", Image.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }
                service.ImageUrl = "/images/" + Image.FileName;
            }
            else
            {
                // Yeni resim yüklenmediyse, mevcut resim yolunu koruyun
                service.ImageUrl = existingService.ImageUrl;
            }

            // Güncelleme işlemini gerçekleştirin
            _serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }

    }
}
