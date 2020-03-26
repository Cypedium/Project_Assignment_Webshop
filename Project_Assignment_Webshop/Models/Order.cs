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

        //[Required]
        //public List<Product> Products { get; set; }

        //[Required]
        //public User User { get; set; }

    }
}
