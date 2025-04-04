﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.SocialMedia
{
    public class SocialMediaList : ViewComponent
    {
        SocialMediaManager _socialMediaManager = new SocialMediaManager(new EFSocialMediaDAL());
        public IViewComponentResult Invoke()
        {
            var values = _socialMediaManager.TGetList();
            return View(values);
        }
    }
}
