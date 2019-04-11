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
    public class CategoryService
    {
        #region Singleton
        public static CategoryService Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoryService();

                return instance;
            }

        }
        private static CategoryService instance { get; set; }
        private CategoryService()
        {

        }
        #endregion
        public Category GetCategory(int id)
        {
            using (var context = new EAContext())
            {
                return context.Categories.Find(id);
            }

        }
        public List<Category> GetCategories()
        {
            using (var context = new EAContext())
            {
                //return context.Categories.ToList();
                return context.Categories
                       .OrderBy(x => x.ID)

                       .Include(x => x.Products)
                       .ToList();
            }

        }
        public List<Category> GetFeaturedCategory()
        {
            using (var context = new EAContext())
            {
                return context.Categories.Where(x => x.isFeatured && x.ImageURL != null).ToList();
            }

        }
        public List<Category> GetCategoriesFood()
        {
            using (var context = new EAContext())
            {
                //return context.Categories.ToList();
                return context.Categories
                       .OrderBy(x => x.ID)

                       .Include(x => x.FoodandMedicines)
                       .ToList();
            }

        }

        public void CreateCategory(Category category)
        {
            using (var context = new EAContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }

        }
        public void UpdateCategory(Category category)
        {
            using (var context = new EAContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }

        }
        public void DeleteCategory(int id)
        {
            using (var context = new EAContext())
            {
                //context.Entry(category).State = System.Data.Entity.EntityState.Deleted;

                var category = context.Categories.Find(id);
                context.Categories.Remove(category);
                context.SaveChanges();
            }

        }
    }
}
