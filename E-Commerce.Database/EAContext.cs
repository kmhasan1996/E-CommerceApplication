using E_Commerce.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Database
{
    public class EAContext:DbContext,IDisposable
    {
        public EAContext() : base("EcommerceConnection")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<FoodandMedicine> FoodandMedicines { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
	public DbSet<Review> Reviews { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
