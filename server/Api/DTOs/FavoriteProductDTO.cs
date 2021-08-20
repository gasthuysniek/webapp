using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.DTOs
{
    public class FavoriteProductDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductID { get; set; }
    }
}
