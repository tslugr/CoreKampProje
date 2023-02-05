using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreKampProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public IActionResult Index(int page = 1)
        {
            var values = categoryManager.TGetList().ToPagedList(page, 5);
            return View(values);
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                category.CategoryStatus = true;
                categoryManager.TAdd(category);
                return RedirectToAction("Index", "Category");



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

        [HttpGet]
        public IActionResult CategoryUpdate(int id)
        {
            var categoryValue = categoryManager.TGetByID(id);
            return View(categoryValue);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                categoryManager.TUpdate(category);
                return RedirectToAction("Index", "Category");



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

        public IActionResult CategoryStatusChange(int id)
        {
            var isExities = categoryManager.TGetByID(id);

            if (isExities == null)
                return RedirectToAction("Index", "Category");

            if (isExities.CategoryStatus == true)
                categoryManager.UpdateRecordState(isExities.CategoryID, false);
            else
                categoryManager.UpdateRecordState(isExities.CategoryID, true);

            return RedirectToAction("Index", "Category");
        }
    }
}
