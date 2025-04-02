using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class FeatureController : Controller
    {
        FeatureManager _featureManager = new FeatureManager(new EFFeatureDAL());
        [HttpGet]
        public IActionResult Index()
        {
            var value = _featureManager.TGetByID(1);
            return View(value);
        }


        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            var existingFeature = _featureManager.TGetByID(feature.FeatureId); // Mevcut veriyi alır

            if (existingFeature != null)
            {
                existingFeature.Header = feature.Header;
                existingFeature.Name = feature.Name;
                existingFeature.Title = feature.Title;

                _featureManager.TUpdate(existingFeature); // Mevcut veriyi günceller
            }

            return RedirectToAction("Index");
        }
    }
}
