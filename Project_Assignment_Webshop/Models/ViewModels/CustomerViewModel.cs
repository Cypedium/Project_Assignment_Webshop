using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.ViewModels
{
    public class CustomerViewModel
    {
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
    }
}
