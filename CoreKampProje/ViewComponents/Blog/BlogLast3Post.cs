﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKampProje.ViewComponents.Blog
{
    public class BlogLast3Post : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogDal());
        public IViewComponentResult Invoke()
        {
            var values = bm.GetLast3Blog();
            return View(values);
        }
    }
}