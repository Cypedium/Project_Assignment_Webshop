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
        public int Amount { get; set; }

        [Display(Name = "If you want GlutenFree bread.")]
        public bool GlutenFree { get; set; }

        public Product Product { get; set; }
    }
}
