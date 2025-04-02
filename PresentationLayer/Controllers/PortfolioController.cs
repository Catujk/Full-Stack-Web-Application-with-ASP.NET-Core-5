using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EFPortfolioDAL());
        public IActionResult Index()
        {
            var values = portfolioManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Portfolio portfolio)
        {
            PortfolioValidator validationRules = new PortfolioValidator();
            var result = validationRules.Validate(portfolio);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View("Add");
            }
            portfolioManager.TAdd(portfolio);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var value = portfolioManager.TGetByID(id);
            portfolioManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = portfolioManager.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult Update(Portfolio portfolio)
        {
            portfolioManager.TUpdate(portfolio);
            return RedirectToAction("Index");
        }

    }
}
