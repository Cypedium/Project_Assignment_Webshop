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
    public class CashiersController : Controller
    {
            //[Authorize]
        readonly ICashierService _cashierService;

        public CashiersController(ICashierService cashierService)
        {
            _cashierService = cashierService;
        }

        public IActionResult Index()
        {
            return View(_cashierService.All());
        }

        //Create-----------------------------------------------------------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CashierViewModel cashier)
        {
            if (ModelState.IsValid)
            {
                _cashierService.Create(cashier);
                return RedirectToAction("Index");
            }
            return View(cashier);
        }

        //Details----------------------------------------------------------------------
        [HttpGet]
        public IActionResult Details(int id)
        {
            Cashier cashier_Details = _cashierService.Find(id);
            if (cashier_Details == null)
            {
                return RedirectToAction("Index");
            }
            return View(cashier_Details);
        }
        [HttpPost]
        public IActionResult Details() //uses this postaction for back to option
        {
            return View("Index", _cashierService.All());
        }

        //Remove----------------------------------------------------------------------
        [HttpGet]
        public IActionResult Remove(int id)
        {
            Cashier removeCashier = _cashierService.Find(id);
            if (removeCashier == null)
            {
                return RedirectToAction("Index");
            }
            return View(removeCashier);
        }

        [HttpPost]
        public IActionResult Remove(Cashier cashier)
        {
            bool result = _cashierService.Remove(cashier.Id);

            if (result)
            {
                ViewBag.msg = "Your Cashier has been succesfully removed from the database.";
            }
            else
            {
                ViewBag.msg = "Unable to remove Cashier from database.";
            }

            return View("Index", _cashierService.All());
        }

        //Remove----------------------------------------------------------------------
        [HttpGet]
        public IActionResult Rename(int id)
        {
            Cashier rename_Cashier = _cashierService.Find(id);
            if (rename_Cashier == null)
            {
                ViewBag.msg = "The Student was not found";
                return View(_cashierService.All());
            }
            return View(rename_Cashier);
        }
        [HttpPost]
        public IActionResult Rename(Cashier cashier)
        {
            if (ModelState.IsValid)
            {
                _cashierService.Update(cashier);
                return RedirectToAction("Index");
            }
            return View(cashier);
        }

    }
}