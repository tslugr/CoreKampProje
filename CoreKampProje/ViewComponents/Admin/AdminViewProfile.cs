using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKampProje.ViewComponents.Admin
{
    public class AdminViewProfile : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
        }
}
