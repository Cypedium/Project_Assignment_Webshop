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
        [StringLength(999, MinimumLength = 1)]
        public int Number { get; set; } 

        [Required]
        [StringLength(63, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(127, MinimumLength = 6)]
        public string Description { get; set; }

        [Required]
        [StringLength(511, MinimumLength = 5)]
        public int Price { get; set; }

        public bool GlutenFree { get; set; }

        public string Picture { get; set; }

    }
}
