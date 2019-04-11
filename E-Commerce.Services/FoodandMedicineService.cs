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
    public class FoodandMedicineService
    {
       
            public List<FoodandMedicine> GetFoodandMedicines()
            {
                using (var context = new EAContext())
                {
                    return context.FoodandMedicines.OrderByDescending(x => x.ID).Include(x => x.Category).ToList();

                }

            }

            public void CreateFoodandMedicine(FoodandMedicine foodandMedicine)
            {
                using (var context = new EAContext())
                {
                    context.Entry(foodandMedicine.Category).State = EntityState.Unchanged;

                    context.FoodandMedicines.Add(foodandMedicine);
                    context.SaveChanges();
                }

            }
            public void UpdateFoodandMedicine(FoodandMedicine foodandMedicine)
            {
                using (var context = new EAContext())
                {
                    context.Entry(foodandMedicine).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }

            }
            public FoodandMedicine GetFoodandMedicine(int? id)
            {
                using (var context = new EAContext())
                {
                    return context.FoodandMedicines.Where(x => x.ID == id).Include(x => x.Category).FirstOrDefault();
                }

            }

        public void DeleteFoodandMedicine(int id)
        {
            using (var context = new EAContext())
            {
                //context.Entry(Product).State = System.Data.Entity.EntityState.Deleted;

                var foodandMedicine = context.FoodandMedicines.Find(id);
                context.FoodandMedicines.Remove(foodandMedicine);
                context.SaveChanges();
            }

        }

    }
}
