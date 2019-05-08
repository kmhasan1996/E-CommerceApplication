using E_Commerce.Entities;
using E_Commerce.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Web.ViewModels
{
    public class OrderViewModel
    {
        public List<Order> AllOrders { get; set; }
        public List<Order> PendingOrders { get; set; }
        public List<Order> InProgressOrders { get; set; }
        public List<Order> DeliveredOrders { get; set; }
        
       
    }

    public class OrderDetailsViewModel
    {
        public List<string> AvailableStatuses { get; set; }
        public Order Order { get; set; }
        public ApplicationUser OrderBy { get; set; }
    }
    public class UserOrderItemDetailsViewModel
    {
        
        public Order Order { get; set; }
        public ApplicationUser OrderBy { get; set; }
    }
}