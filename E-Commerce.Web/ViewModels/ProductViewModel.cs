using E_Commerce.Entities;
using E_Commerce.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Web.ViewModels
{
    
        public class NewProductViewModels
        {
            public String Name { get; set; }
            public String Description { get; set; }
            public decimal Price { get; set; }
            public decimal Unit { get; set; }
            public decimal Weight { get; set; }
            public int CategoryID { get; set; }
            public string ImageURL { get; set; }
            public DateTime CreatedTime { get; set; }
            //public string latitude { get; set; }
            //public string longitude { get; set; }
    }
        public class EditProductViewModel
        {
            public int ID { get; set; }

            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public decimal Weight { get; set; }
            public decimal Unit { get; set; }
            public int CategoryID { get; set; }
            public string ImageURL { get; set; }
            //public string latitude { get; set; }
            //public string longitude { get; set; }
    }

    public class ProductDetailModel
    {
        public Product Product { get; set; }
        public ApplicationUser User { get; set; }
        public List<Review> Reviews { get; set; }
    }

    public class CreateReview
    {
        public string UserName { get; set; }
        public decimal RatingPoint { get; set; }
        public string ReviewMessage { get; set; }
        public int ProductID { get; set; }
    }
}