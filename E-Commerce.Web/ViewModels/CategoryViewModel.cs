using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Web.ViewModels
{
    public class NewCategoryViewModels
    {
        public String Name { get; set; }
        public string ImageURL { get; set; }
        public bool isFeatured { get; set; }
    }
    public class EditCategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public bool isFeatured { get; set; }
    }

}