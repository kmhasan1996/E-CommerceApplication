using E_Commerce.Database;
using E_Commerce.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class ProductService
    {
        #region Singleton
        public static ProductService Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductService();

                return instance;
            }

        }
        private static ProductService instance { get; set; }
        private ProductService()
        {

        }
        #endregion

        public Product GetProduct(int id)
        {
            using (var context = new EAContext())
            {
                return context.Products.Where(x => x.ID == id).Include(x => x.Category).FirstOrDefault();
            }

        }
        public List<Product> GetCartProducts(List<int> ids)
        {
            using (var context = new EAContext())
            {
                return context.Products.Where(x => ids.Contains(x.ID)).ToList();
            }

        }
        public List<Product> GetProducts()//int pageNo
        {
            using (var context = new EAContext())
            {
                return context.Products.OrderByDescending(x => x.ID).Where(x => x.Category.isFeatured == true).Include(x => x.Category).ToList();
                
            }

        }

        public List<Product> GetEightProducts(int numberOfProducts)
        {

            using (var context = new EAContext())
            {
                return context.Products.OrderByDescending(x => x.ID).Take(numberOfProducts).Where(x => x.Category.isFeatured == true).Include(x => x.Category).ToList();
            }

        }

        public List<Product> GetLatestProducts(int numberOfProducts)
        {

            using (var context = new EAContext())
            {
                return context.Products.OrderByDescending(x => x.ID).Take(numberOfProducts).Where(x => x.Category.isFeatured == true).Include(x => x.Category).ToList();

            }

        }
        public List<Product> GetProductsByCategory(int categoryID, int numberOfProducts)
        {

            using (var context = new EAContext())
            {
                return context.Products.OrderByDescending(x => x.ID).Take(numberOfProducts).Where(x => (x.Category.ID == categoryID) && (x.Category.isFeatured == true)).Include(x => x.Category).ToList();

            }

        }

        public void CreateProduct(Product product)
        {
            using (var context = new EAContext())
            {
                context.Entry(product.Category).State = EntityState.Unchanged;

                context.Products.Add(product);
                context.SaveChanges();
            }

        }
        public void UpdateProduct(Product product)
        {
            using (var context = new EAContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }

        }
        public void DeleteProduct(int id)
        {
            using (var context = new EAContext())
            {
                //context.Entry(Product).State = System.Data.Entity.EntityState.Deleted;

                var product = context.Products.Find(id);
                context.Products.Remove(product);
                context.SaveChanges();
            }

        }

    }
}
