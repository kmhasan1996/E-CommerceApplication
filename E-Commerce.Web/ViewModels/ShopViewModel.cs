using E_Commerce.Entities;
using E_Commerce.Web.Models;
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
        public ApplicationUser User { get; set; }


    }

    public class ShopViewmodel
    {
        public int? SortBy { get; set; }
        public List<Category> FeaturedCategories { get; set; }
        public List<Product> Products { get; set; }
        public int MaximumPrice { get; set; }
        public int? CategoryID { get; set; }
        public Pager Pager { get; set; }

    }
    public class FilterProductsViewModel
    {
        public List<Product> Products { get; set; }
        public Pager Pager { get; set; }
        public int? SortBy { get; set; }
        public int? CategoryID { get; set; }

    }

    public class LayoutViewModel
    {
      
        public List<Category> FeaturedCategories { get; set; }
       

    }
}