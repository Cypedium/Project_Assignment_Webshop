﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models
{
    public class Receipt
    {
        [Key]
        public int Id { get; set; }

     /*---Database connections-----------------------------------*/
        public List<OrderRow> OrderRows { get; set; }
     /*----------------------------------------------------------*/
    }
}
