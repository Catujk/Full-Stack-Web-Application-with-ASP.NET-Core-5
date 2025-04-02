using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
