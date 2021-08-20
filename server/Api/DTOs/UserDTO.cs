using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Models.Domain;

namespace Webshop.DTOs
{
    public class UserDTO
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public IEnumerable<Order> Orders { get; set; }
       // public IEnumerable<FavoriteProduct> FavoriteProducts {get;set;}
        public UserDTO()
        {

        }
        public UserDTO(User user):this()
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Orders = user.OrderListOfUser;
           // FavoriteProducts = user.Favorites;
        }
    }
}
