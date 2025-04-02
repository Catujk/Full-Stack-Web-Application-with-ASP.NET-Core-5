using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Contact
{
    public class SendMessage : ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EFMessageDAL());

        [HttpGet]
        public IViewComponentResult Invoke()
        {

            return View();
        }

        //[HttpPost]
        //public IViewComponentResult Invoke(Message message)
        //{
        //    message.Date = System.DateTime.Parse(System.DateTime.Now.ToShortDateString());
        //    message.Status = true;
        //    messageManager.TAdd(message);    

        //    return View();
        //}

    }
}
