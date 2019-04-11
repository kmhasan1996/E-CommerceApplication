using E_Commerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Web.ViewModels
{
    public class NewFoodandMedicinesViewModel
    {
        public string Month { get; set; }
        public decimal MinWeight { get; set; }
        public decimal MaxWeight { get; set; }
        public string Food { get; set; }
        public string Medicine { get; set; }
        public int CategoryID { get; set; }
    }

    public class EditFoodandMedicinesViewModel
    {
        public int ID { get; set; }
        public string Month { get; set; }
        public decimal MinWeight { get; set; }
        public decimal MaxWeight { get; set; }
        public string Food { get; set; }
        public string Medicine { get; set; }
        public int CategoryID { get; set; }
    }

    public class UserFoodandMedicinesViewModel
    {
        public List<FoodandMedicine> FoodandMedicines { get; set; }
        public List<Category> Categories { get; set; }
        
    }

}