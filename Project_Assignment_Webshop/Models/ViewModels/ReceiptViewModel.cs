using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.ViewModels
{
    public class ReceiptViewModel
    {
        [Required]
        public string Customer { get; set; }

        [Required]
        public string OrderDate { get; set; }

        public List<OrderRow> OrderRows { get; set; }
    }
}
