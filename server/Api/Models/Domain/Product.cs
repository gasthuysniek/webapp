using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Models.Domain
{
    public class Product
    {
        #region properties
        public int ProductId { get; set;}
        public string ProductClass { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        //public int AantalOpOrder { get; set; } 
      //  public int? Amount { get; set; }
        public int Availability { get; set; }
        public string Description { get; set; }
        #endregion
        //public ICollection<User> Users { get; set; }
        //public User User { get; set; }
       // public ICollection<Order> ListOfOrder { get; set; }
       // public ICollection<Order> OrderListTotWieDitProductBehoord { get; set; }
       //public ICollection<OrderLine> OrderLines { get; set; }

        public bool InStock { get; set; }
        #region ctors
       
        public Product(string productname,string productclass,double unitPrice,string description
           // , int? amount=null
            ):this()
        {

            ProductClass = productclass;
            ProductName = productname;
            UnitPrice = unitPrice;            
            Description = description;
          //  Amount = amount;

        }
        public Product()
        {
            InStock = false;
            Availability = 0;
        }

        #endregion

        public void AddProductsAvailable (int amount)
        {
            //if the availabilty passed in the dto is less or equal to 0, it is nog longer in stock or available
            if (amount <= 0)
            {
                InStock = false;
                Availability = amount;
            }
            else
            {
                InStock = true;
                Availability += amount;
            }
        }
    }
}
