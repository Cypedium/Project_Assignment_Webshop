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
        [MaxLength(5)]
        public string OrderTime { get; set; }
        //public DateTime(int year, int month, int day, int hour, int minute, int second) {  }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Payed, not payed, delivered.")]
        public string Status { get; set; }

        [Required]
        [MaxLength(6)]
        public int Amount { get; set; }


        /*--Lists from other classes--------------------------------*/
        [Required]
        public int CustomerId { get; set; }       
        public List<Customer> Customers { get; set; }

        
        public int OrderRowId { get; set; }
        public List<OrderRow> OrderRows { get; set; }
        /*----------------------------------------------------------*/


        /*---Database connections-----------------------------------*/
        public Cashier Cashier { get; set; }
        public Receipt Receipt { get; set; }
        /*----------------------------------------------------------*/
    }
}
