using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message")]
    public class MessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDAL());
        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("")]
        [Route("ReceiverMessage")]

        public async Task<IActionResult> ReceiverMessage(string filter)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            filter = user.Email;
            var values = writerMessageManager.GetListRecevierMessages(filter);

            return View(values);
        }
        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string filter)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            filter = user.Email;
            var values = writerMessageManager.GetListSenderMessages(filter);
            return View(values);
        }

        
        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage writerMessage)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            writerMessage.SenderMail = user.Email;
            writerMessage.SenderName = user.Name + " " + user.Surname;
            writerMessage.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            Context context = new Context();
            var userNameSurname = context.Users.Where(x => x.Email == writerMessage.ReceiverMail).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            writerMessage.ReceiverName = userNameSurname;
            writerMessageManager.TAdd(writerMessage);
            return RedirectToAction("SenderMessage");
        }

        [Route("MessageDetails/{id}")]
        public IActionResult MessageDetail(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            return View(values);
        }

        [Route("ReceiverMessageDetail/{id}")]
        public IActionResult ReceiverMessageDetail(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            return View(values);
        }
    }
}
