using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class TestimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EFTestimonialDAL());
        public IActionResult Index()
        {
            var testimonialValues = testimonialManager.TGetList();
            return View(testimonialValues);
        }

        //add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Testimonial testimonial)
        {
            testimonialManager.TAdd(testimonial);
            return RedirectToAction("Index");
        }

        //update

        [HttpGet]
        public IActionResult Update(int id)
        {
            var testimonialValue = testimonialManager.TGetByID(id);
            return View(testimonialValue);
        }
        [HttpPost]
        public IActionResult Update(Testimonial testimonial)
        {
            testimonialManager.TUpdate(testimonial);
            return RedirectToAction("Index");
        }

        //delete
        public IActionResult Delete(int id)
        {
            var testimonialValue = testimonialManager.TGetByID(id);
            testimonialManager.TDelete(testimonialValue);
            return RedirectToAction("Index");
        }

        // view comment details
        public IActionResult View(int id)
        {
            var testimonialValue = testimonialManager.TGetByID(id);
            return View(testimonialValue);
        }

    }
}
