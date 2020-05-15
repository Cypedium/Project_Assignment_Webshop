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
        public string OrderTime { get; set; }
        //public DateTime(int year, int month, int day, int hour, int minute, int second) {  }

        [Required]
        [Display(Name = "Payed, not payed, delivered.")]
        public string Status { get; set; }

        /*---Database connections-----------------------------------*/
        public Cashier Cashier { get; set; }

        public Receipt Receipt { get; set; }

        public Customer Customer { get; set; }

        public List<OrderRow> OrderRows { get; set; }
        /*----------------------------------------------------------*/
       
    }
}
