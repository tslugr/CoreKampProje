using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKampProje.Controllers
{

    public class BlogController : Controller
    {
        private CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        Context context = new Context();

        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = blogManager.GetBlogByID(id);
            var commentNumber = context.Comments.Where(x => x.BlogID == id).Count();
            var blogScore = context.Comments.Where(x => x.BlogID == id).Select(y => y.BlogScore).FirstOrDefault();
            ViewBag.commentNumber = commentNumber;
            ViewBag.blogScore = blogScore;
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            //Identity ile writer tablosunda eşleşen kullanıcılara aynı maili verdim
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = blogManager.GetBlogListWithCategoryByWriter(writerId);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> categoryValues = (from x in categoryManager.TGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(blog);
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            if (results.IsValid)
            {

                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = writerId;
                blogManager.TAdd(blog);
                return RedirectToAction("BlogListByWriter", "Blog");



            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
        public IActionResult BlogDelete(int id)
        {
            var blogValue = blogManager.TGetByID(id);
            blogManager.TDelete(blogValue);
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> categoryValues = (from x in categoryManager.TGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            var blogValue = blogManager.TGetByID(id);
            return View(blogValue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {

            blogManager.TUpdate(blog);
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        public void GetCategoryList()
        {
            List<SelectListItem> categories = (from c in _categoryManager.TGetList()
                                               select new SelectListItem
                                               {
                                                   Text = c.CategoryName,
                                                   Value = c.CategoryID.ToString()
                                               }).ToList();
            ViewBag.categoriesList = categories;
        }

    }
}
