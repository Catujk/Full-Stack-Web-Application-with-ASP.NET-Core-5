using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PresentationLayer.ViewComponents.Dashboard
{
    public class FeatureStatistic : ViewComponent
    {
        MessageManager _messageManager = new MessageManager(new EFMessageDAL());
        ExperienceManager _experienceManager = new ExperienceManager(new EFExperienceDAL());
        SkillManager _skillManager = new SkillManager(new EFSkillDAL());
        public IViewComponentResult Invoke()
        {
            var values = _skillManager.TGetList().Count;
            // Status = 1
            var values2 = _messageManager.TGetList().Where(x => x.Status==true).Count();
            // Status = 0
            var values3 = _messageManager.TGetList().Where(x => x.Status == false).Count();
            var values4 = _experienceManager.TGetList().Count;
            ViewBag.d1 = values;
            ViewBag.d2 = values2;
            ViewBag.d3 = values3;
            ViewBag.d4 = values4;
            return View();
        }
    }
}
