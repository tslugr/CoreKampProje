using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKampProje.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public IViewComponentResult Invoke()
        {

            var values = categoryManager.TGetList();
            return View(values);
        }
    }
}
