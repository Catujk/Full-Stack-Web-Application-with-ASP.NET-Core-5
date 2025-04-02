using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Dashboard
{
    public class MapVisitor : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
