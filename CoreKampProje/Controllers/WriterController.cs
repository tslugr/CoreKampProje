using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKampProje.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        public PartialViewResult WriterNavbarParital()
        {
            return PartialView();
        }
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
    }
}
