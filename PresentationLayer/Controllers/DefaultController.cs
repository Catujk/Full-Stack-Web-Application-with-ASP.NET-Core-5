using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class DefaultController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeaderPartial()
        {

            return PartialView();
        }
        public PartialViewResult NavBarPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SendMessage(Message message)
        {
            MessageManager messageManager = new MessageManager(new EFMessageDAL());
            message.Date = System.DateTime.Parse(System.DateTime.Now.ToShortDateString());
            message.Status = true;
            messageManager.TAdd(message);
            return PartialView("Index", "Default");
        }
    }
}
