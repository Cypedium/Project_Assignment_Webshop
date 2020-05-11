using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_Assignment_Webshop.Models;
using Project_Assignment_Webshop.Models.IServices;
using Project_Assignment_Webshop.Models.ViewModels;

namespace Project_Assignment_Webshop.Controllers
{
    public class CustomersController : Controller
    {
        //[Authorize]
        readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View(_customerService.All());
        }

        //Create-----------------------------------------------------------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.Create(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }
        //-----------------------------------------------------------------------------

        //-----------------------------------------------------------------------------
        [HttpGet]
        public IActionResult Details(int id)
        {
            Customer customer_Details = _customerService.Find(id);
            if (customer_Details == null)
            {
                return RedirectToAction("Index");
            }
            return View(customer_Details);
        }
        [HttpPost]
        public IActionResult Details() //uses this postaction for back to option
        {
            return View("Index", _customerService.All());
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            Customer removeCustomer = _customerService.Find(id);
            if (removeCustomer == null)
            {
                return RedirectToAction("Index");
            }
            return View(removeCustomer);
        }

        [HttpPost]
        public IActionResult Remove(Customer customer)
        {
            bool result = _customerService.Remove(customer.Id);

            if (result)
            {
                ViewBag.msg = "Your Customer has been succesfully removed from the database.";
            }
            else
            {
                ViewBag.msg = "Unable to remove Customer from database.";
            }

            return View("Index", _customerService.All());
        }

        [HttpGet]
        public IActionResult Rename(int id)
        {
            Customer rename_Customer = _customerService.Find(id);
            if (rename_Customer == null)
            {
                ViewBag.msg = "The Student was not found";
                return View(_customerService.All());
            }
            return View(rename_Customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.Update(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }
    }
}