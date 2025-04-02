using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PresentationLayer.Controllers
{
    public class SecondExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EFExperienceDAL());
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetExperienceList()
        {
            var values = JsonConvert.SerializeObject(experienceManager.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            var values = JsonConvert.SerializeObject(experienceManager.TGetList());
            return Json(values);
        }

        public IActionResult GetById(int id)
        {
            var v = experienceManager.TGetByID(id);
            var values = JsonConvert.SerializeObject(v);
            return Json(values);
        }

        //DELETE
        public IActionResult DeleteById(int id) {
            var v = experienceManager.TGetByID(id);
            experienceManager.TDelete(v);
            var values = JsonConvert.SerializeObject(experienceManager.TGetList());
            return NoContent();
        }
    }
}
