using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(31, MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string F_Name { get; set; }

        [Required]
        [StringLength(31, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string L_Name { get; set; }

        [Required]
        [StringLength(63, MinimumLength = 6)]
        [Display(Name = "E-mail")]
        public string E_mail { get; set; }

        [Required]
        [StringLength(16)]
        [Display(Name = "Credit Card")]
        public string CreditCard { get; set; }

        /*---Database connections-----------------------------------*/
        public Order Order { get; set; }
        //public int OrderId { get; set; }
        //public List<Order> Orders { get; set; } //init for database one to many User to Order
        /*----------------------------------------------------------*/
    }
}
