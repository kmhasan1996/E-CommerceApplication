using E_Commerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Web.ViewModels
{
    public class ProductWidgetViewmodel
    {
        public List<Product> Products { get; set; }
        public Boolean IsLatestProduct { get; set; }
        public Boolean ByCategory { get; set; }
    }
}