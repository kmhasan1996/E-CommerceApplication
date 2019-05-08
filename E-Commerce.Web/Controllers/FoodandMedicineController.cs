using E_Commerce.Entities;
using E_Commerce.Services;
using E_Commerce.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Web.Controllers
{
    public class FoodandMedicineController : Controller
    {
        FoodandMedicineService foodandMedicineService = new FoodandMedicineService();
        // GET: Food
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserIndex()
        {
            return View();
        }

        public ActionResult UserGetFoodandMedicine(int? Category,string search,int? MinWeight,int? MaxWeight)
        {
            UserFoodandMedicinesViewModel model = new UserFoodandMedicinesViewModel();
            var foods = foodandMedicineService.GetFoodandMedicines();
            model.Categories = foods.Select(x => x.Category).Distinct().ToList();
            if (!string.IsNullOrEmpty(search) && MinWeight != null && MaxWeight !=null)
            {
                model.FoodandMedicines = foods.Where(p =>p.Category.ID==Category && p.Month.StartsWith(search) && MinWeight >= p.MinWeight && MaxWeight <= p.MaxWeight).ToList();
                return PartialView(model);
            }
            if (!string.IsNullOrEmpty(search) && MinWeight != null && MaxWeight==null)
            {
                model.FoodandMedicines = foods.Where(p => p.Category.ID == Category && p.Month.StartsWith(search) && MinWeight >= p.MinWeight).ToList();
                return PartialView(model);
            }
            if (!string.IsNullOrEmpty(search) && MinWeight == null && MaxWeight!=null)
            {
                model.FoodandMedicines = foods.Where(p => p.Category.ID == Category && p.Month.StartsWith(search) && MaxWeight <= p.MaxWeight).ToList();
                return PartialView(model);
            }
            if (!string.IsNullOrEmpty(search) && MinWeight==null && MaxWeight==null)
            {
                model.FoodandMedicines = foods.Where(p => p.Category.ID == Category && p.Month.StartsWith(search)).ToList();
                return PartialView(model);
            }
            model.FoodandMedicines = foodandMedicineService.GetFoodandMedicines();
            //var cat= CategoryService.Instance.GetCategories();
           
            return PartialView(model);
        }

        public ActionResult FoodandMedicineTable()
        {
            var foods = foodandMedicineService.GetFoodandMedicines();

            return PartialView(foods);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            var categories = CategoryService.Instance.GetCategoriesFood();
            return PartialView(categories);
        }
        [HttpPost]
        public ActionResult Create(NewFoodandMedicinesViewModel model)
        {
            var newFoodChart = new FoodandMedicine();
            newFoodChart.Month = model.Month;
            newFoodChart.MinWeight = model.MinWeight;
            newFoodChart.MaxWeight = model.MaxWeight;
            newFoodChart.Food = model.Food;
            newFoodChart.Medicine = model.Medicine;
            newFoodChart.Category = CategoryService.Instance.GetCategory(model.CategoryID);


            foodandMedicineService.CreateFoodandMedicine(newFoodChart);
            //return View();
            return RedirectToAction("FoodandMedicineTable");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditFoodandMedicinesViewModel model = new EditFoodandMedicinesViewModel();
            var food = foodandMedicineService.GetFoodandMedicine(ID);
            model.ID = food.ID;
            model.Month = food.Month;
            model.MinWeight = food.MinWeight;
            model.MaxWeight = food.MaxWeight;
            model.Food = food.Food;
            model.Medicine = food.Medicine;
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(EditFoodandMedicinesViewModel model)
        {
            var existingFood = foodandMedicineService.GetFoodandMedicine(model.ID);
            existingFood.Month = model.Month;
            existingFood.MinWeight = model.MinWeight;
            existingFood.MaxWeight = model.MaxWeight;
            existingFood.Food = model.Food;
            existingFood.Medicine = model.Medicine;
            foodandMedicineService.UpdateFoodandMedicine(existingFood);
            return RedirectToAction("FoodandMedicineTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            foodandMedicineService.DeleteFoodandMedicine(ID);
            return RedirectToAction("FoodandMedicineTable");
        }

        
    }
}