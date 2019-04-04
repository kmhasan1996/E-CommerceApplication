using E_Commerce.Services;
using E_Commerce.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Web.Controllers
{
    public class WidgetsController : Controller
    {
        // GET: Widgets
         public ActionResult Products(Boolean isLatestProducts, int? CategoryID = 0)
            {
                ProductWidgetViewmodel model = new ProductWidgetViewmodel();
                model.IsLatestProduct = isLatestProducts;
                if (CategoryID.HasValue && CategoryID.Value > 0)
                {
                    model.ByCategory = true;


                }


                if (isLatestProducts)
                {
                    model.Products = ProductService.Instance.GetLatestProducts(4);
                }
                else if (CategoryID.HasValue && CategoryID.Value > 0)
                {
                    model.Products = ProductService.Instance.GetProductsByCategory(CategoryID.Value, 4);
                }
                else
                {
                    model.Products = ProductService.Instance.GetEightProducts(8);
                }

                return PartialView(model);
            }
        
    }
}