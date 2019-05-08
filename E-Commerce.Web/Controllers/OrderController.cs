using E_Commerce.Services;
using E_Commerce.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Web.Controllers
{
    public class OrderController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Order
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            OrderViewModel model = new OrderViewModel();
            //model.Status = status;
            model.AllOrders = OrderService.Instance.AllOrders();
            model.PendingOrders = OrderService.Instance.PendingOrders();
            model.InProgressOrders= OrderService.Instance.InProgressOrders();
            model.DeliveredOrders = OrderService.Instance.DeliveredOrders();
            return View(model);
        }

        public ActionResult Details(int ID)
        {
            OrderDetailsViewModel model = new OrderDetailsViewModel();

            model.Order = OrderService.Instance.GetOrderByID(ID);

            if (model.Order != null)
            {
                model.OrderBy = UserManager.FindById(model.Order.UserID);
            }

            model.AvailableStatuses = new List<string>() { "Pending", "In Progress", "Delivered" };

            return View(model);
        }

        //user ordered item details
        public ActionResult UserOrderItemDetails(int ID)
        {
            UserOrderItemDetailsViewModel model = new UserOrderItemDetailsViewModel();

            model.Order = OrderService.Instance.GetOrderByID(ID);

            if (model.Order != null)
            {
                model.OrderBy = UserManager.FindById(model.Order.UserID);
            }

            return View(model);
        }

        public JsonResult ChangeStatus(string status, int ID)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            result.Data = new { Success = OrderService.Instance.UpdateOrderStatus(ID, status) };

            return result;
        }
    }
    
}