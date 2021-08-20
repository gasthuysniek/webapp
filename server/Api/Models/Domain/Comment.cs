using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Models.Domain
{
    public class Comment
    {     
        
        //public string UserId { get; set; }
        //public Product Product { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int CommentId { get; set; }
        //[ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime PostingDateComment { get; set; }
        //public int? Rating { get; set; }
        //upvotes are likes left on a Comment
        public int UpVotes { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Comment(Product product, //int userid,
            string title, string content
            //leaving a rating is option to be later added
            //int Rating
            )
            :this()
        {
           
            Product = product;
            ProductId = product.ProductId;
            Title = title;
            Content = content;
            UserId = User.UserId;
            

        }
        public Comment()
        {
            PostingDateComment = DateTime.Now;
            UpVotes = 0;
        }
    }
}
