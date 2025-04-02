using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection.Metadata;
using WebAPILayer.DAL.Context;
using WebAPILayer.DAL.Entities;

namespace WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        Context context = new Context();

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = context.Categories.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var value = context.Categories.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }

        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return Ok("Added");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);
            context.Remove(value);
            context.SaveChanges();
            return Ok("Deleted.");
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            var value = context.Categories.Find(category.CategoryId);
            value.CategoryName = category.CategoryName;
            context.Categories.Update(value);
            context.SaveChanges();
            return Ok("Updated.");
        }
    }
}
