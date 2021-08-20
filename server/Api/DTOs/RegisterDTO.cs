 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Models.Domain;

namespace Webshop.DTOs
{
    public class RegisterDTO : LoginDTO
    {
        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(250)]
        public string LastName { get; set; }
       
        [Required]
        [Compare("Email")]
        public string EmailConfirmation { get; set; }
        [Required]
        [Compare("PassWord")]
        public string PassWordConfirmation { get; set; }
      
    }
    }

