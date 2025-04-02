using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using PresentationLayer.Areas.Writer.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel
            {
                Name = values.Name,
                SurName = values.Surname,
                PictureUrl = values.ImageUrl
            };
            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (userEditViewModel.Picture != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var path = Path.GetExtension(userEditViewModel.Picture.FileName);
                var randomName = Guid.NewGuid().ToString() + path;
                var savePath = resource + "/wwwroot/userimage/" + randomName;
                var stream = new FileStream(savePath, FileMode.Create);
                await userEditViewModel.Picture.CopyToAsync(stream);
                user.ImageUrl = randomName;
            }
            user.Name = userEditViewModel.Name;
            user.Surname = userEditViewModel.SurName;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user,userEditViewModel.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Login");
            }
            return View();
        }
    }
}
