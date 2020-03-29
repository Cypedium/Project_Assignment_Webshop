using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Assignment_Webshop.Models;

namespace Project_Assignment_Webshop.Controllers
{
    public class ProductsController : Controller
    {
       readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_productService.All());
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
            return View("Index", _productService.All());
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
                ViewBag.msg = "Your Student has been succesfully removed";
            }
            else
            {
                ViewBag.msg = "Unable to remove Student";
            }

            return View("Index", _productService.All());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product = _productService.Find(id);
            if (product == null)
            {
                ViewBag.msg = "The Student was not found";
                return View(_productService.All());
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}