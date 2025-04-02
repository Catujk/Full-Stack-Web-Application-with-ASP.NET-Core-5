using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PresentationLayer.Controllers
{
    public class ContactController : Controller
    {
        MessageManager messageManager = new MessageManager(new EFMessageDAL());
        public IActionResult Index()
        {
            var messageValues = messageManager.TGetList();
            return View(messageValues);
        }

        public IActionResult GetInboxMessageDetails(int id)
        {
            // change status to read
            var messageValue = messageManager.TGetByID(id);
            messageValue.Status = true;
            messageManager.TUpdate(messageValue);
            return View(messageValue);
        }

        //Change Status
        public IActionResult ChangeStatus(int id)
        {
            var messageValue = messageManager.TGetByID(id);
            if (messageValue.Status == true)
            {
                messageValue.Status = false;
            }
            else
            {
                messageValue.Status = true;
            }
            messageManager.TUpdate(messageValue);
            return RedirectToAction("Index");
        }

        //Delete Message
        public IActionResult DeleteMessage(int id)
        {
            var messageValue = messageManager.TGetByID(id);
            messageManager.TDelete(messageValue);
            return RedirectToAction("Index");
        }

        //Send Message
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            message.Date = System.DateTime.Parse(DateTime.Now.ToShortDateString());
            message.Status = true;
            messageManager.TAdd(message);
            return RedirectToAction("Index");
        }


    }
}
