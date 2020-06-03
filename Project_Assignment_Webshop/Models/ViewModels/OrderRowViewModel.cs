using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.ViewModels
{
    public class OrderRowViewModel
    {
        [Required]
        [Display(Name = "Amount is sum of all Products.")]
        public int Price { get; set; }

        [Display(Name = "If you want GlutenFree bread.")]
        public bool GlutenFree { get; set; }

        /*--Lists from other classes--------------------------------*/
        public int ProductId { get; set; }
        public List <Product> Products { get; set; }
        public int OrderId { get; set; }
        public List<Order> Orders { get; set; }
        /*----------------------------------------------------------*/
    }
}
