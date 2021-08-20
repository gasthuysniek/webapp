using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.DTOs
{
    public class AddProductDTO
    {       
            [Required]
             public int OrderId { get; set; }
            //[Required]
            /* public Product Product { get; set; }
             [Required]
             public DateTime PostingDateComment { get; set; }*/
            //public int? Rating { get; set; }
            //upvotes are likes left on a Comment
            [Required]
            public int ProductId { get; set; }
            [Required]
            public int Amount { get; set; }          
        }
    }

