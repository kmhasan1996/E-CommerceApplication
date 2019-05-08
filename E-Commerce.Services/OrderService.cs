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

    public class OrderService
    {
        #region Singleton
        public static OrderService Instance
        {
            get
            {
                if (instance == null) instance = new OrderService();

                return instance;
            }
        }
        private static OrderService instance { get; set; }

        private OrderService()
        {
        }

        #endregion


        public List<Order> AllOrders()
        {
            using (var context = new EAContext())
            {

                return context.Orders.ToList();
            }
        }

        public List<Order> PendingOrders()
        {
            using (var context = new EAContext())
            {

                return context.Orders.Where(x => x.Status == "Pending").ToList();
            }
        }

        public List<Order> InProgressOrders()
        {
            using (var context = new EAContext())
            {

                return context.Orders.Where(x => x.Status == "In Progress").ToList();
            }
        }

        public List<Order> DeliveredOrders()
        {
            using (var context = new EAContext())
            {

                return context.Orders.Where(x => x.Status == "Delivered").ToList();
            }
        }



        public Order GetOrderByID(int ID)
        {
            using (var context = new EAContext())
            {
                return context.Orders.Where(x => x.ID == ID).Include(x => x.OrderItems).Include("OrderItems.Product").FirstOrDefault();
            }
        }
        public List<Order> GetOrdersByID(string ID)
        {
            using (var context = new EAContext())
            {
                return context.Orders.Where(x => x.UserID == ID).Include(x => x.OrderItems).Include("OrderItems.Product").ToList();
            }
        }
        public bool UpdateOrderStatus(int ID, string status)
        {
            using (var context = new EAContext())
            {
                var order = context.Orders.Find(ID);

                order.Status = status;

                context.Entry(order).State = EntityState.Modified;

                return context.SaveChanges() > 0;
            }
        }

    }
}
