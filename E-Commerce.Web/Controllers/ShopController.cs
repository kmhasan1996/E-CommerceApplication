using E_Commerce.Services;
using E_Commerce.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Web.Controllers
{
    public class ShopController : Controller
    {
        public ActionResult Index(string searchTxt, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy)
        {
            
        }
        public ActionResult FilterProduct(string searchTxt, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy)
        {
            
        }

        public ActionResult Checkout()
        {
            
        }
    }
}