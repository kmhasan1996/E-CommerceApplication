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
        }
    
}