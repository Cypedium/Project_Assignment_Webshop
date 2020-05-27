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
    public class ReceiptsController : Controller
    {
        //[Authorize]
        readonly IReceiptService _receiptService;

        public ReceiptsController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        public IActionResult Index()
        {
            return View(_receiptService.All());
        }

        //Create-----------------------------------------------------------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ReceiptViewModel receipt)
        {
            if (ModelState.IsValid)
            {
                _receiptService.Create(receipt);
                return RedirectToAction("Index");
            }
            return View(receipt);
        }

        //Details----------------------------------------------------------------------
        [HttpGet]
        public IActionResult Details(int id)
        {
            Receipt receipt_Details = _receiptService.Find(id);
            if (receipt_Details == null)
            {
                return RedirectToAction("Index");
            }
            return View(receipt_Details);
        }
        [HttpPost]
        public IActionResult Details() //uses this postaction for back to option
        {
            return View("Index", _receiptService.All());
        }

        //Remove----------------------------------------------------------------------
        [HttpGet]
        public IActionResult Remove(int id)
        {
            Receipt removeReceipt = _receiptService.Find(id);
            if (removeReceipt == null)
            {
                return RedirectToAction("Index");
            }
            return View(removeReceipt);
        }

        [HttpPost]
        public IActionResult Remove(Receipt receipt)
        {
            bool result = _receiptService.Remove(receipt.Id);

            if (result)
            {
                ViewBag.msg = "Your Receipt has been succesfully removed from the database.";
            }
            else
            {
                ViewBag.msg = "Unable to remove Receipt from database.";
            }

            return View("Index", _receiptService.All());
        }

        //Remove----------------------------------------------------------------------
        [HttpGet]
        public IActionResult Rename(int id)
        {
            Receipt rename_Receipt = _receiptService.Find(id);
            if (rename_Receipt == null)
            {
                ViewBag.msg = "The Student was not found";
                return View(_receiptService.All());
            }
            return View(rename_Receipt);
        }
        [HttpPost]
        public IActionResult Rename(Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                _receiptService.Update(receipt);
                return RedirectToAction("Index");
            }
            return View(receipt);
        }

    }
}