using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Models.Domain;

namespace Webshop.DTOs
{
    public class AddCommentDTO
    {
       /* [Required]
        public User User { get; set; }*
        [Required]
        public Product Product { get; set; }
        [Required]
        public DateTime PostingDateComment { get; set; }*/
        //public int? Rating { get; set; }
        //upvotes are likes left on a Comment
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
