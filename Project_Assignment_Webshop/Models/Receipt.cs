using System;
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

        [Required]
        [MaxLength(100)]
        public string Customer { get; set; }

        [Required]
        [MaxLength(10)]
        public string OrderDate { get; set; }

     /*---Database connections-----------------------------------*/
        public List<OrderRow> OrderRows { get; set; }
     /*----------------------------------------------------------*/
    }
}
