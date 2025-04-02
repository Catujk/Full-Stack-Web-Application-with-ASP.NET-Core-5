using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class SocialMediaController : Controller
    {
        SocialMediaManager _socialMediaManager = new SocialMediaManager(new EFSocialMediaDAL());
        public IActionResult Index()
        {
            var values = _socialMediaManager.TGetList();
            return View(values);
        }

        // add new social media
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(SocialMedia p)
        {
            _socialMediaManager.TAdd(p);
            return RedirectToAction("Index");
        }

        // update social media
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _socialMediaManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(SocialMedia p)
        {
            _socialMediaManager.TUpdate(p);
            return RedirectToAction("Index");
        }

        // delete social media
        public IActionResult Delete(int id)
        {
            var value = _socialMediaManager.TGetByID(id);
            _socialMediaManager.TDelete(value);
            return RedirectToAction("Index");
        }

    }
}
