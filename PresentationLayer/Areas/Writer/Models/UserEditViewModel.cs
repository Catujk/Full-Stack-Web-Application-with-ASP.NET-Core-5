﻿using Microsoft.AspNetCore.Http;

namespace PresentationLayer.Areas.Writer.Models
{
    public class UserEditViewModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PictureUrl{ get; set; }
        public IFormFile Picture{ get; set; }
}
}
