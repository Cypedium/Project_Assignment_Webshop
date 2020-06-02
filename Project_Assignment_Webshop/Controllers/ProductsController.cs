using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Assignment_Webshop.Models;

namespace Project_Assignment_Webshop.Controllers    
{
    [Authorize]
    public class ProductsController : Controller
    {
        readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_productService.All_Current());
        }

        public IActionResult Out_of_Order()
        {
            return View(_productService.All_Out_of_Order());
        }

        //Create-----------------------------------------------------------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _productService.Create(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        //-----------------------------------------------------------------------------

        //-----------------------------------------------------------------------------
        [HttpGet]
        public IActionResult Details(int id)
        {
            Product product_Details = _productService.Find(id);
            if (product_Details == null)
            {
                return RedirectToAction("Index");
            }
            return View(product_Details);
        }
        [HttpPost]
        public IActionResult Details() //uses this postaction for back to option
        {
            return View("Index", _productService.All_Current());
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            Product aProduct = _productService.Find(id);
            if (aProduct == null)
            {
                return RedirectToAction("Index");
            }
            return View(aProduct);
        }

        [HttpPost]
        public IActionResult Remove(Product product)
        {
            bool result = _productService.Remove(product.Id);

            if (result)
            {
                ViewBag.msg = "Your Product has been succesfully removed from the database.";
            }
            else
            {
                ViewBag.msg = "Unable to remove Student from database.";
            }

            return View("Index", _productService.All_Current());
        }

        [HttpGet]
        public IActionResult Rename(int id)
        {
            Product product = _productService.Find(id);
            if (product == null)
            {
                ViewBag.msg = "The Student was not found";
                return View(_productService.All_Current());
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Rename(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //[HttpPost]
        //public IActionResult ChangeProductView(int productType)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (productType == 1)
        //        {
        //            return RedirectToAction("Order_Pizza_Klass_1");
        //        }
        //        else if (productType == 2)
        //       {
        //           return RedirectToAction("Order_Pizza_Klass_2");
        //        }
        //        else if (productType == 3)
        //       {
        //           return RedirectToAction("Order_Pizza_Klass_3");
        //        }
        //        else if (productType == 4)
        //       {
        //           return RedirectToAction("Order_Pizza_Special");
        //        }
        //        else if (productType == 5)
        //        {
        //            return RedirectToAction("Order_Sallad");
        //        }
        //        else if (productType == 6)
        //        {
        //            return RedirectToAction("Order_Hamburgare");
        //        }
        //         else if (productType == 7)
        //        {
        //            return RedirectToAction("Order_Korv");
        //        }
        //        else if (productType == 8)
        //        {
        //            return RedirectToAction("Order_A_La_Carte");
        //        }
        //        else if (productType == 10)
        //        {
        //            return RedirectToAction("Order_Kebab");
        //        }
        //         else if (productType == 11)
        //        {
        //            return RedirectToAction("Order_Gyros");
        //        }
        //         else if (productType == 12)
        //        {
        //            return RedirectToAction("Order_Kyckling");
        //        }
        //         else if (productType == 13)
        //        {
        //            return RedirectToAction("Order_Falafel");
        //        }
        //        else if (productType == 20)
        //        {
        //            return RedirectToAction("Order_Tillbehör");
        //        }
        //        else if (productType == 21)
        //        {
        //            return RedirectToAction("Order_Såser");
        //        }
        //        else if (productType == 22)
        //        {
        //            return RedirectToAction("Order_Drycker");
        //        }
        //        else if ((productType < 1 && productType > 13) && !(productType > 19 && productType < 23))
        //        {
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    return View(productType);
        //}
    }
}