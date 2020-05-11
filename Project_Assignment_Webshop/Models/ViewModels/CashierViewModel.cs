using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.ViewModels
{
    public class CashierViewModel
    {
        [Required]
        public string Costumer { get; set; }

        [Required]
        public string OrderTime { get; set; }

        public List<OrderRow> OrderRows { get; set; }
    }
}
