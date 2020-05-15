﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_Assignment_Webshop.Models;
using Project_Assignment_Webshop.Models.IServices;
using Project_Assignment_Webshop.Models.ViewModels;

namespace Project_Assignment_Webshop.Controllers
{
    //[Authorize]
    public class OrdersController : Controller
    {
        readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View(_orderService.All());
        }

        //Create-----------------------------------------------------------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                _orderService.Create(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }
        //-----------------------------------------------------------------------------

        //-----------------------------------------------------------------------------
        [HttpGet]
        public IActionResult Details(int id)
        {
            Order order_Details = _orderService.Find(id);
            if (order_Details == null)
            {
                return RedirectToAction("Index");
            }
            return View(order_Details);
        }
        [HttpPost]
        public IActionResult Details() //uses this postaction for back to option
        {
            return View("Index", _orderService.All());
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            Order removeOrder = _orderService.Find(id);
            if (removeOrder == null)
            {
                return RedirectToAction("Index");
            }
            return View(removeOrder);
        }

        [HttpPost]
        public IActionResult Remove(Order order)
        {
            bool result = _orderService.Remove(order.Id);

            if (result)
            {
                ViewBag.msg = "Your Order has been succesfully removed from the database.";
            }
            else
            {
                ViewBag.msg = "Unable to remove Order from database.";
            }

            return View("Index", _orderService.All());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Order order = _orderService.Find(id);
            if (order == null)
            {
                ViewBag.msg = "The Order was not found";
                return View(_orderService.All());
            }
            return View(order);
        }
        [HttpPost]
        public IActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                _orderService.Update(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }
    }
}