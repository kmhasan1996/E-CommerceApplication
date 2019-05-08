using E_Commerce.Entities;
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
        public ActionResult Index(string searchTxt, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy,int? pageNo)
        {
            int pageSize = 9;
	        ShopViewmodel model = new ShopViewmodel();
            model.FeaturedCategories = CategoryService.Instance.GetFeaturedNotNullItemCategory();
            model.MaximumPrice = ProductService.Instance.GetMaximumPrice();
            model.MinimumPrice = ProductService.Instance.GetMinimumPrice();

            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.SortBy = sortBy;
            model.CategoryID = categoryID;

            int totalCount = ProductService.Instance.SearchProductCount(searchTxt, minimumPrice, maximumPrice, categoryID, sortBy);
            model.Products = ProductService.Instance.SearchProduct(searchTxt, minimumPrice, maximumPrice, categoryID, sortBy, pageNo.Value, pageSize);

            model.Pager = new Pager(totalCount,pageNo, pageSize);

            return View(model);
            
        }
        public ActionResult FilterProduct(string searchTxt, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int? pageNo)
        {
            int pageSize = 9;
            FilterProductsViewModel model = new FilterProductsViewModel();

            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.SortBy = sortBy;
            model.CategoryID = categoryID;

            int totalCount = ProductService.Instance.SearchProductCount(searchTxt, minimumPrice, maximumPrice, categoryID, sortBy);
            model.Products = ProductService.Instance.SearchProduct(searchTxt, minimumPrice, maximumPrice, categoryID, sortBy, pageNo.Value, pageSize);

            model.Pager = new Pager(totalCount, pageNo, pageSize);
            return PartialView(model);
            
        }
        
        [Authorize]
        public ActionResult Checkout()
        {
		CheckoutViewmodel model = new CheckoutViewmodel();

            var CartproductsCookie = Request.Cookies["CartProducts"];

            if (CartproductsCookie != null && !string.IsNullOrEmpty(CartproductsCookie.Value))
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

        //productIDs should beformatted like = "7-7-9-1"
        public JsonResult PlaceOrder(string productIDs)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            if (!string.IsNullOrEmpty(productIDs))
            {
                var productQuantities = productIDs.Split('-').Select(x => int.Parse(x)).ToList();

                var boughtProducts = ProductService.Instance.GetCartProducts(productQuantities.Distinct().ToList());

                Order newOrder = new Order();
                newOrder.UserName = User.Identity.GetUserName();
                newOrder.UserID = User.Identity.GetUserId();
                newOrder.OrderedAt = DateTime.Now;
                newOrder.Status = "Pending";
                newOrder.TotalAmount = boughtProducts.Sum(x => x.Price * productQuantities.Where(productID => productID == x.ID).Count());

                newOrder.OrderItems = new List<OrderItem>();
                newOrder.OrderItems.AddRange(boughtProducts.Select(x => new OrderItem() { ProductID = x.ID, Quantity = productQuantities.Where(productID => productID == x.ID).Count() }));

                var rowsEffected = ShopService.Instance.SaveOrder(newOrder);

                result.Data = new { Success = true, Rows = rowsEffected };
            }
            else
            {
                result.Data = new { Success = false };
            }

            return result;
        }
    }
}