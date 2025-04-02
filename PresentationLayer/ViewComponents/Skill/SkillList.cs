using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Skill
{
    public class SkillList : ViewComponent
    {
        SkillManager _skillManager = new SkillManager(new EFSkillDAL());
        public IViewComponentResult Invoke()
        {
            var values = _skillManager.TGetList();
            return View(values);
        }
    }
}
