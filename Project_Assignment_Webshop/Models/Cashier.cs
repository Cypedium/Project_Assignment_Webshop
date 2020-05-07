using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models
{
    public class Cashier
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string OrderDate { get; set; }

        /*---Database connections-----------------------------------*/
        public List<OrderRow> OrderRows { get; set; } // This list will be in the cache on browser but saved to simulate the database connections
        public List<Receipt> Receipts { get; set; } // This list will be saved in the database with the orderrows.
        /*----------------------------------------------------------*/
    }
}
