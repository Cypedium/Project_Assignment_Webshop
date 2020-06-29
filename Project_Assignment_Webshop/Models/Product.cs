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
        [MaxLength(3)]
        public int Number { get; set; }

        [Required]
        [Display(Name = "Name of Product")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price")]
        [MaxLength(6)]
        public int Price { get; set; }

        public bool Out_of_Order { get; set; }

        //public byte Picture { get; set; }

        /*---Database connections-----------------------------------*/
        
        /*----------------------------------------------------------*/
    }
}
