using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Models.Domain;

namespace Webshop.DTOs
{
    public class ProductDTO
    {
        [Required]
        public string ProductClass { get; set; }

        [Required]
        public string ProductName { get; set; }


        [Required]
        public double UnitPrice { get; set; }


        [Required]
        public int Availability { get; set; }



        public string Description { get; set; }
    



    } 
}
