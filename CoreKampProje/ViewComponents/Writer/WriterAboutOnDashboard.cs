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
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = writerManager.GetWriterByID(writerID);        
            ViewBag.veri = userName;
            return View(values);
        }
    }
}
