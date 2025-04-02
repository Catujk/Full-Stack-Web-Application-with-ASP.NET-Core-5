using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.WriterFullName = values.Name + " " + values.Surname;

            Context context = new Context();
            ViewBag.v1 = context.WriterMessages.Where(x => x.ReceiverMail == values.Email).Count();
            ViewBag.v2 = context.Announcements.Count();
            ViewBag.v3 = context.Users.Count();
            ViewBag.v4 = context.Skills.Count();


            ViewBag.Weather = null;
            ViewBag.City= null;
            ViewBag.Country = null;


            //string weatherApi = "---";
            //string weatherApiUrl = "http://api.openweathermap.org/data/2.5/forecast?id=323776&appid=" + weatherApi;

            //XDocument document = XDocument.Load(weatherApiUrl);
            //ViewBag.Weather = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            return View();
        }
    }
}
