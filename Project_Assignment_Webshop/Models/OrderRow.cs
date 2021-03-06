﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models
{
    public class OrderRow
    {

        [Key]
        public int Id { get; set; }

        public int Price { get; set; }
        
        [Display(Name = "If you want GlutenFree bread.")]
        public bool GlutenFree { get; set; }

        /*--Lists from other classes--------------------------------*/
        [Required]
        public int ProductId { get; set; }
        public List<Product> Products { get; set; }

        [Required]
        public int OrderId { get; set; }
        //public  List<Order> Orders { get; set; }
        /*----------------------------------------------------------*/

        /*---Database connections-----------------------------------*/
        public Product Product { get; set; }
        public Cashier Cashier { get; set; }
        /*----------------------------------------------------------*/
    }
}
