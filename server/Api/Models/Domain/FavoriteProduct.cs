using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Models.Domain
{
    public class FavoriteProduct
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        //public string ProductName { get; set; }
        public Product Product { get; set; }
        public int Userid { get; set; }
        //public string UserName { get; set; }
        //public string UserID { get; set; }
        //[ForeignKey(nameof(UserID))]
        public User User { get; set; }
        public FavoriteProduct(User user, Product product)
        {
            User = user;
            Userid = user.UserId;
            Product = product;
            ProductID = product.ProductId;
        }
        public FavoriteProduct()
        {

        }
    }
}
