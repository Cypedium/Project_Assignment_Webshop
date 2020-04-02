using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Type of Product")]
        public int ProductType { get; set; }

        [Required]
        [Display(Name = "Number")]
        //[StringLength(255)]
        public int Number { get; set; }

        [Required]
        [Display(Name = "Name of Product")]
        //[StringLength(63)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        //[StringLength(127)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price")]
        //[StringLength(511)]
        public int Price { get; set; }

        //public string Picture { get; set; }

    }
}
