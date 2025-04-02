using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PresentationLayer.Controllers
{
    public class WriterUserController : Controller
    {
        WriterUserManager writerUserManager = new WriterUserManager(new EFWriterUserDAL());
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult GetWriterUserList()
        {
            var values = JsonConvert.SerializeObject(writerUserManager.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddUser(WriterUser writerUser)
        {
            writerUserManager.TAdd(writerUser);
            var values = JsonConvert.SerializeObject(writerUserManager.TGetList());
            return Json(values);
        }

    }
}
