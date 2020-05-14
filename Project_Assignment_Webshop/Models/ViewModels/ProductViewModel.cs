using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models
{
    public class ProductViewModel
    {
        [Required]
        [Display(Name = "Type of Product")]
        public int ProductType { get; set; }

        [Required]       
        [Display(Name = "Number")]
        public int Number { get; set; }

        [Required]       
        [Display(Name = "Name of Product")]
        public string Name { get; set; }

        [Required]       
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price")]
        public int Price { get; set; }
    }
}
