using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PresentationLayer.Controllers
{
    public class AdminMessageController : Controller
    {
        WriterMessageManager _writerMessageManager = new WriterMessageManager(new EFWriterMessageDAL());
        public IActionResult InBox()
        {
            string p = "admin@example.com";
            var values = _writerMessageManager.GetListRecevierMessages(p);
            return View(values);
        }

        public IActionResult SendBox()
        {
            string p = "admin@example.com";
            var values = _writerMessageManager.GetListSenderMessages(p);
            return View(values);
        }

        // GetInboxMessageDetails
        public IActionResult GetInboxMessageDetails(int id)
        {
            var messageValue = _writerMessageManager.TGetByID(id);
            return View(messageValue);
        }


        //GetSendboxMessageDetails
        public IActionResult GetSendboxMessageDetails(int id)
        {
            var messageValue = _writerMessageManager.TGetByID(id);
            return View(messageValue);
        }

        //Delete
        public IActionResult DeleteInBox(int id)
        {
            var messageValue = _writerMessageManager.TGetByID(id);
            _writerMessageManager.TDelete(messageValue);
            return RedirectToAction("InBox");
        }

        public IActionResult DeleteSendBox(int id)
        {
            var messageValue = _writerMessageManager.TGetByID(id);
            _writerMessageManager.TDelete(messageValue);
            return RedirectToAction("SendBox");
        }

        // New Message
        public IActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewMessage(WriterMessage p)
        {
            // sender mail
            string mail = "admin@example.com";
            p.SenderMail = mail;
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _writerMessageManager.TAdd(p);
            return RedirectToAction("SendBox");
        }
    }
}
