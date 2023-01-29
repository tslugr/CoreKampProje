using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKampProje.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());


        Context context = new Context();


        public IViewComponentResult Invoke()
        {


            //var userName = User.Identity.Name;
            //var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            //var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            //var values = writerManager.GetBlogWriterById(writerID);
            //////var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //ViewBag.veri = userName;

            var values = writerManager.GetWriterByID(1);
            return View(values);
        }
    }
}
