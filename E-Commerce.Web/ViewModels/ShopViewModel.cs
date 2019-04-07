using E_Commerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Web.ViewModels
{
    public class CheckoutViewmodel
    {
        public List<Product> CartProducts { get; set; }
        public List<int> CartProductIDs { get; set; }

    }

    public class ShopViewmodel
    {
        public int? SortBy { get; set; }
        public List<Category> FeaturedCategories { get; set; }
        public List<Product> Products { get; set; }
        public int MaximumPrice { get; set; }

    }
    public class FilterProductsViewModel
    {
        public List<Product> Products { get; set; }

    }

    public class LayoutViewModel
    {
      
        public List<Category> FeaturedCategories { get; set; }
       

    }
}