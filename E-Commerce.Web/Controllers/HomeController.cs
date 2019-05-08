using E_Commerce.Services;
using E_Commerce.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Category");
            }
            HomeViewModel model = new HomeViewModel();

            //model.FeaturedCategories = CategoryService.Instance.GetFeaturedNotNullItemCategory();//GetFeaturedCategory();
            model.FeaturedCategories = CategoryService.Instance.GetFeaturedCategory();//GetFeaturedCategory();
            //model.FeaturedProducts = ProductService.Instance.GetProducts(1);

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Faq()
        {
            return View();
        }

        public ActionResult Navbar()
        {
            NavbarViewModel model = new NavbarViewModel();
            model.FeaturedCategories= CategoryService.Instance.GetFeaturedCategory();
            return PartialView("Navbar",model);
        }



    }
}