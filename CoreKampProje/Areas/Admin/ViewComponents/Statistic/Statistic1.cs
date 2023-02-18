using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = blogManager.TGetList().Count();
            ViewBag.v2 = context.Contacts.Count();
            ViewBag.v3 = context.Comments.Count();
            string api = "81426db2e8d5ead3474bbd21cf4e436e";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.havaDurumu = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            return View();
        }
    }
}