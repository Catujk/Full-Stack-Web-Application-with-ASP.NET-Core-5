using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Feature
{
    public class FeatureList : ViewComponent
    {
        FeatureManager _featureManager = new FeatureManager(new EFFeatureDAL());
        public IViewComponentResult Invoke()
        {
            var values = _featureManager.TGetList();
            return View(values);
        }
    }
}
