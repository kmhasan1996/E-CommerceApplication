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


        public List<Product> SearchProduct(string searchTxt, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int pageNo,int pageSize)
        {
            using (var context = new EAContext())
            {
                var products = context.Products.Where(x => x.Category.isFeatured == true).ToList();

                if (categoryID.HasValue)
                {
                    products = products.Where(x => x.Category.ID == categoryID.Value).ToList();
                }

                if (!string.IsNullOrEmpty(searchTxt))
                {
                    products = products.Where(x => x.Name.ToLower().Contains(searchTxt.ToLower())).ToList();
                }

                if (minimumPrice.HasValue)
                {
                    products = products.Where(x => x.Price >= minimumPrice.Value).ToList();
                }

                if (maximumPrice.HasValue)
                {
                    products = products.Where(x => x.Price <= maximumPrice.Value).ToList();
                }



                if (sortBy.HasValue)
                {
                    switch (sortBy.Value)
                    {
                        case 2:
                            products = products.OrderBy(x => x.Price).ToList();
                            break;
                        case 3:
                            products = products.OrderByDescending(x => x.Price).ToList();
                            break;
                        case 4:
                            products = products.OrderByDescending(x => x.CreatedTime).ToList();
                            break;
                        case 5:
                            products = products.OrderBy(x => x.CreatedTime).ToList();
                            break;
                        default:
                            products = products.OrderByDescending(x => x.ID).ToList();
                            break;
                    }
                }

                return products.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public int SearchProductCount(string searchTxt, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy)
        {
            using (var context = new EAContext())
            {
                var products = context.Products.Where(x => x.Category.isFeatured == true).ToList();

                if (categoryID.HasValue)
                {
                    products = products.Where(x => x.Category.ID == categoryID.Value).ToList();
                }

                if (!string.IsNullOrEmpty(searchTxt))
                {
                    products = products.Where(x => x.Name.ToLower().Contains(searchTxt.ToLower())).ToList();
                }

                if (minimumPrice.HasValue)
                {
                    products = products.Where(x => x.Price >= minimumPrice.Value).ToList();
                }

                if (maximumPrice.HasValue) 
                {
                    products = products.Where(x => x.Price <= maximumPrice.Value).ToList();
                }



                if (sortBy.HasValue)
                {
                    switch (sortBy.Value)
                    {
                        case 2:
                            products = products.OrderBy(x => x.Price).ToList();
                            break;
                        case 3:
                            products = products.OrderByDescending(x => x.Price).ToList();
                            break;
                        case 4:
                            products = products.OrderByDescending(x => x.CreatedTime).ToList();
                            break;
                        case 5:
                            products = products.OrderBy(x => x.CreatedTime).ToList();
                            break;
                        default:
                            products = products.OrderByDescending(x => x.ID).ToList();
                            break;
                    }
                }

                return products.Count;
            }
        }

        public int GetMaximumPrice()
        {
            using (var context = new EAContext())
            {
                return (int)(context.Products.Max(x => x.Price));
            }
        }

        public int GetMinimumPrice()
        {
            using (var context = new EAContext())
            {
                return (int)(context.Products.Min(x => x.Price));
            }
        }

        public Product GetProduct(int id)
        {
            using (var context = new EAContext())
            {
                return context.Products.Where(x => x.ID == id).Include(x => x.Category).FirstOrDefault();
            }

        }

        //getReview for productDetails view
        public List<Review> GetReview(int id)
        {
            using (var context = new EAContext())
            {
                return context.Reviews.Where(x => x.Product.ID == id).ToList();
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
                context.Configuration.ProxyCreationEnabled = false;
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


        public void CreateReview(Review review)
        {
            using (var context = new EAContext())
            {
                context.Entry(review.Product).State = EntityState.Unchanged;
                context.Reviews.Add(review);
                context.SaveChanges();
            }

        }

    }
}
