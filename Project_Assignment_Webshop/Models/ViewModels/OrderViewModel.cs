using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        public string OrderTime { get; set; }

        [Required]
        [Display(Name = "Payed, not payed, delivered.")]
        public string Status { get; set; }

        [Required]
        public int Amount { get; set; }
        
        public int OrderRowId {get; set; }

        public List<OrderRow> OrderRows { get; set; }

        public int CustomerId { get; set; }

        public List<Customer> Customers { get; set; }

        
    }
}
