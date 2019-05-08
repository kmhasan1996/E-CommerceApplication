using E_Commerce.Entities;
using E_Commerce.Services;
using E_Commerce.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Web.Controllers
{
    public class CategoryController : Controller
    {
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Index()
        {
            var categories = CategoryService.Instance.GetCategories();
            return View(categories);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CategoryTable()
        {
            var categories = CategoryService.Instance.GetCategories();
            //categories = categories.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            return PartialView(categories);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            NewCategoryViewModels model = new NewCategoryViewModels();

            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Create(NewCategoryViewModels model)
        {
            var newCategory = new Category();
            newCategory.Name = model.Name;
            newCategory.ImageURL = model.ImageURL;
            newCategory.isFeatured = model.isFeatured;

            CategoryService.Instance.CreateCategory(newCategory);

            return RedirectToAction("CategoryTable");
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditCategoryViewModel model = new EditCategoryViewModel();

            var category = CategoryService.Instance.GetCategory(ID);

            model.ID = category.ID;
            model.Name = category.Name;
            model.ImageURL = category.ImageURL;
            model.isFeatured = category.isFeatured;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditCategoryViewModel model)
        {
            var existingCategory = CategoryService.Instance.GetCategory(model.ID);
            existingCategory.Name = model.Name;
            existingCategory.ImageURL = model.ImageURL;
            existingCategory.isFeatured = model.isFeatured;

            CategoryService.Instance.UpdateCategory(existingCategory);

            return RedirectToAction("CategoryTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            CategoryService.Instance.DeleteCategory(ID);

            return RedirectToAction("CategoryTable");
        }
    }
}