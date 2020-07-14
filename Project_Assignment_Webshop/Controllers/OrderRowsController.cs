using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project_Assignment_Webshop.Models;
using Project_Assignment_Webshop.Models.IServices;
using Project_Assignment_Webshop.Models.ViewModels;

namespace Project_Assignment_Webshop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderRowsController : Controller
    {
        readonly IOrderRowService _orderRowService;
        readonly IProductService _productService;
        readonly IOrderService _orderService;

        public OrderRowsController(IOrderRowService orderRowService, IProductService productService, IOrderService orderService)
        {
            _orderRowService = orderRowService;
            _productService = productService; //to acess ProductList in view
            _orderService = orderService;     //to acess OrderList in view
        }

        public IActionResult Index()
        {
            return View(_orderRowService.All());
        }

        //Create-----------------------------------------------------------------------
        [HttpGet]
        public IActionResult Create()
        {
            OrderRowViewModel vm = new OrderRowViewModel();
            
            vm.Orders = _orderService.All();        
            vm.Products = _productService.All_Current();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(OrderRowViewModel orderRow)
        {
            if (ModelState.IsValid)
            {
                _orderRowService.Create(orderRow);
                return RedirectToAction("Index");
            }
            return View(orderRow);
        }
        //-----------------------------------------------------------------------------

        //-----------------------------------------------------------------------------
        [HttpGet]
        public IActionResult Details(int id)
        {
            OrderRow orderRow_Details = _orderRowService.Find(id);
            if (orderRow_Details == null)
            {
                return RedirectToAction("Index");
            }
            return View(orderRow_Details);
        }
        [HttpPost]
        public IActionResult Details() //uses this postaction for back to option
        {
            return View("Index", _orderRowService.All());
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            OrderRow removeOrderRow = _orderRowService.Find(id);
            if (removeOrderRow == null)
            {
                return RedirectToAction("Index");
            }
            return View(removeOrderRow);
        }

        [HttpPost]
        public IActionResult Remove(Order orderRow)
        {
            bool result = _orderRowService.Remove(orderRow.Id);

            if (result)
            {
                ViewBag.msg = "Your Order has been succesfully removed from the database.";
            }
            else
            {
                ViewBag.msg = "Unable to remove Order from database.";
            }

            return View("Index", _orderRowService.All());
        }

        [HttpGet]
        public IActionResult Rename(int id)
        {
            OrderRow orderRow = _orderRowService.Find(id);
            if (orderRow == null)
            {
                ViewBag.msg = "The Order was not found";
                return View(_orderRowService.All());
            }
            return View(orderRow);
        }
        [HttpPost]
        public IActionResult Rename(OrderRow orderRow)
        {
            if (ModelState.IsValid)
            {
                _orderRowService.Update(orderRow);
                return RedirectToAction("Index");
            }
            return View(orderRow);
        }
    }
}