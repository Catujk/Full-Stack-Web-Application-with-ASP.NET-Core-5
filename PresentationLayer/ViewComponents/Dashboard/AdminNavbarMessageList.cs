using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PresentationLayer.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList : ViewComponent
    {
        WriterMessageManager _writerMessageManager = new WriterMessageManager(new EFWriterMessageDAL());
        public IViewComponentResult Invoke()
        {
            string mail = "deneme@examle.com";
            var messageList = _writerMessageManager.GetListRecevierMessages(mail).OrderByDescending(x=>x.Id).Take(3).ToList();
            return View(messageList);
        }
    }

}
