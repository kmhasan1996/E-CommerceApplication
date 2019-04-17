using E_Commerce.Services;
using E_Commerce.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Web.Controllers
{
    public class ShopController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult Index(string searchTxt, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy)
        {
	    ShopViewmodel model = new ShopViewmodel();
            model.FeaturedCategories = CategoryService.Instance.GetFeaturedNotNullItemCategory();
            model.MaximumPrice = ProductService.Instance.GetMaximumPrice();
            model.Products = ProductService.Instance.SearchProduct(searchTxt, minimumPrice, maximumPrice, categoryID, sortBy);
            model.SortBy = sortBy;
            return View(model);
            
        }
        public ActionResult FilterProduct(string searchTxt, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy)
        {
	     FilterProductsViewModel model = new FilterProductsViewModel();

            model.Products = ProductService.Instance.SearchProduct(searchTxt, minimumPrice, maximumPrice, categoryID, sortBy);
            return PartialView(model);
            
        }
        
        [Authorize]
        public ActionResult Checkout()
        {
		CheckoutViewmodel model = new CheckoutViewmodel();

            var CartproductsCookie = Request.Cookies["CartProducts"];

            if (CartproductsCookie != null)
            {
                //var productIDs = CartproductsCookie.Value;
                //var ids = productIDs.Split('-');
                //List<int> ProductIDs = ids.Select(x => int.Parse(x)).ToList();

                model.CartProductIDs = CartproductsCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();
                model.CartProducts = ProductService.Instance.GetCartProducts(model.CartProductIDs);
                model.User = UserManager.FindById(User.Identity.GetUserId());
            }
            return View(model);
            
        }
    }
}