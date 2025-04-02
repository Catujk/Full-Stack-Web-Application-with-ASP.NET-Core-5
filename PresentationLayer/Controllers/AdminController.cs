using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class AdminController : Controller
    {
        public PartialViewResult PartielSideBar()
        {
            return PartialView();
        }

        public PartialViewResult PartielFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartielNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartielHead()
        {
            return PartialView();
        }

        public PartialViewResult PartielScripts()
        {
            return PartialView();
        }

        public PartialViewResult NewPartielSideBar()
        {
            return PartialView();
        }
    }
}
