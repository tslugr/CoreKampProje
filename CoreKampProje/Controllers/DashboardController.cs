using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKampProje.Controllers
{
    //[AllowAnonymous]//sen authorize dışında ol

    public class DashboardController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        public IActionResult Index()
        {
            Context context = new Context();
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            ViewBag.v1 = context.Blogs.Count().ToString();
            ViewBag.v2 = context.Blogs.Where(x => x.WriterID == writerId).Count();
            ViewBag.v3 = context.Categories.Count().ToString();
            return View();
        }
    }
}
