using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_Assignment_Webshop.Models;

namespace Project_Assignment_Webshop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class APIController : ControllerBase
    {
        private readonly IProductService _productService;

        public APIController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/API
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string productListAPI = JsonConvert.SerializeObject(_productService.All());
            yield return productListAPI; 
        }
    }        
}
