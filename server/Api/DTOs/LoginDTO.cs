using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.DTOs
{
    public class LoginDTO
    {
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        //used for the token
        [Required]
        public string PassWord { get; set; }

    }
}
