using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="Please enter a username.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a surname.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter a image url.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage ="Please enter a password.")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Please enter a password again.")]
        [Compare("Password",ErrorMessage ="Passwords are not same.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Please enter a mail.")]
        public string Mail { get; set; }
    }
}
