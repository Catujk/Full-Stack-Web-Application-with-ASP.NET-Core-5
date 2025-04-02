using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Portfolio
{
    public class SlideList : ViewComponent
    {
        PortfolioManager _portfolioManager = new PortfolioManager(new EFPortfolioDAL());
        public IViewComponentResult Invoke()
        {
            var values = _portfolioManager.TGetList();
            return View(values);
        }
    }
}
