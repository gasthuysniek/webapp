//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Webshop.DTOs;

namespace Webshop.Models.Domain
{

    public class User//, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        #region Properties

        public int UserId { get; set; }
        private string _firstName;
        public string FirstName
        {
            get => _firstName; set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 50)
                    throw new ArgumentException("FirstName is invalid");
                _firstName = value;
            }
        }
        private string _lastName;
        public string LastName
        {
            get => _lastName; set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 60)
                    throw new ArgumentException("FirstName is invalid");
                _lastName = value;
            }
        }

        public string Email { get; set; }

        //  public string Role { get; set; }
        //  public Dictionary<Product, int> Order { get; set; }//hashmap or dubbel list
        public ICollection<FavoriteProduct> Favorites { get; private set; }
       // public ICollection<Product> FavoriteProducts { get; set; }// => get; set;}// Favorites.Select(f => f.Product);
        public ICollection<Order> OrderListOfUser { get; set; }
        public ICollection<Comment> CommentList { get; set; }
        public ICollection<Product> OrderedProductList { get; set; }
        #endregion
        #region ctors
        public User()
        {
            //Order = new Dictionary<Product, int>();
            OrderListOfUser = new List<Order>();
            Favorites = new List<FavoriteProduct>();
            //FavoriteProducts = new List<Product>(); 
            CommentList = new List<Comment>();
            OrderedProductList = new List<Product>();
            //FavoriteProducts = new List<Product>();
        }




        #endregion

        public void AddFavoriteProduct(FavoriteProduct favoriteProduct)
        {
            
            if (Favorites.ToList().Contains(favoriteProduct) || favoriteProduct == null)
                throw new ArgumentException("the product is already added to favorites");
            else
            {
                //Favorites.Add(new FavoriteProduct(this, product));
                   Favorites.Add(favoriteProduct);
                   
            }
        }
        public void CreateOrder(//Product product, int aantal
            )
        {

            Order order = new Order() { User = this, Active = true}// { Active=true} //{ User = this }
                ;
            OrderListOfUser.Add(order);
            //OrderListOfUser.Last().VoegContentToe(product, aantal);
        }
        /*  public void AddProductToOrder(Product product, int aantal,int orderid)//,int orderid = 1)
          {

              OrderListOfUser.Where(o => o.Id == orderid).First().VoegContentToe(product, aantal);

          }*/
    }
}





