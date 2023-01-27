using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKampProje.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager =new CommentManager(new EfCommentDal());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment p)
        {
            p.CommentStatus = true;
            p.CommentDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            p.BlogID = 2;
            commentManager.TAdd(p);
            Response.Redirect("/Blog/BlogReadAll/" + 1);
            return PartialView();
        }
     
    }
}
