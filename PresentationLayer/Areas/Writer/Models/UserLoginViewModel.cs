using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace PresentationLayer.Areas.Writer.Models
{
    public class UserLoginViewModel
    {
        [Display(Name ="Username")]
        [Required(ErrorMessage = "Please enter a username.")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter a password.")]
        public string Password { get; set; }
    }
}
