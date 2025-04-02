using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Dashboard
{
    public class ToDoList : ViewComponent
    {
        ToDoManager toDoManager = new ToDoManager(new EFToDoDAL());
        public IViewComponentResult Invoke()
        {
            var values = toDoManager.TGetList();
            return View(values);
        }
    }
}
