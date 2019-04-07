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
    public class ProductController : Controller
    {
        // GET: Shared
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductTable()
        {
            var Products = ProductService.Instance.GetProducts();

            return PartialView(Products);
        }
		
		[HttpGet]
        public ActionResult Create()
        {
            var categories = CategoryService.Instance.GetCategories();
            return PartialView(categories);
        }
        [HttpPost]
        public ActionResult Create(NewProductViewModels model)
        {
            var newProduct = new Product();
            newProduct.Name = model.Name;
            newProduct.Description = model.Description;
            newProduct.Price = model.Price;
            newProduct.Weight = model.Weight;
            newProduct.Unit = model.Unit;
            newProduct.Category = CategoryService.Instance.GetCategory(model.CategoryID);
            newProduct.ImageURL = model.ImageURL;

            ProductService.Instance.CreateProduct(newProduct);
            return RedirectToAction("ProductTable");
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditProductViewModel model = new EditProductViewModel();
            var product = ProductService.Instance.GetProduct(ID);
            model.ID = product.ID;
            model.Name = product.Name;
            model.Description = product.Description;
            model.Price = product.Price;
            model.Weight = product.Weight;
            model.Unit = product.Unit;
            model.ImageURL = product.ImageURL;
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(EditProductViewModel model)
        {
            var existingProduct = ProductService.Instance.GetProduct(model.ID);
            existingProduct.Name = model.Name;
            existingProduct.Price = model.Price;
            existingProduct.Weight = model.Weight;
            existingProduct.Unit = model.Unit;
            existingProduct.Description = model.Description;
            existingProduct.ImageURL = model.ImageURL;
            ProductService.Instance.UpdateProduct(existingProduct);
            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            ProductService.Instance.DeleteProduct(ID);
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult ProductDetails(int ID)

        {
            ProductDetailModel model = new ProductDetailModel();
            model.Product = ProductService.Instance.GetProduct(ID);

            return View(model);
        }
    }
}