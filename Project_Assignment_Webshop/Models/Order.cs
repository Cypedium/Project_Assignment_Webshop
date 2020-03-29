using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        public string OrderDate { get; set; }

        [Required]
        public string OrderTime { get; set; }

        public Product GlutenFree { get; set; }




        //public DateTime(int year, int month, int day, int hour, int minute, int second) {  }

        //[Required]
        //public List<Product> Products { get; set; }

        //[Required]
        //public User User { get; set; }

    }
}
