using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Assignment_Webshop.Models.ViewModels
{
    public class RoleViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Name { get; set; }
    }
}
