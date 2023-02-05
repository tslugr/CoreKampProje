using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKampProje.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager message2Manager = new Message2Manager(new EfMessage2Dal());
        public IActionResult InBox()
        {
            int id = 3;
            var values = message2Manager.GetInboxListWriter(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var messageValue = message2Manager.TGetByID(id);
            return View(messageValue);
        }
    }
}
