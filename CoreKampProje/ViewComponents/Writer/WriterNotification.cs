using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKampProje.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        NotificationManager notificationManager = new NotificationManager(new EfNotificationDal());
        public IViewComponentResult Invoke()
        {
            var values = notificationManager.TGetList();
            return View(values);
        }
    }
}
