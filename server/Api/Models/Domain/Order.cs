using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Models.Domain
{
    public class Order
    {
        public int Id { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public bool Active { get; set; }
        // public virtual ArrayList<Product, int> OrderContent { get; set; }
        //public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }

        public DateTime CreationDate { get; set; }
        public double OrderTotaal { get; set; }
        public Order()
        {
            // Products = new List<Product>();
            OrderLines = new List<OrderLine>();
            OrderTotaal = 0;
            CreationDate = DateTime.Now;
            //propertie to tell if an order is still active or not, if not the user has checked out order
            Active = true;

        }
        /*public Order() : this()
        {
            User = user;
            UserId = user.UserId;


        }*/
        // public OrderLine(Order order, Product product, int amount
            //An order consists of multiple orderlines
            
        public void VoegContentToe(OrderLine orderline)
        {
            //  product.Amount += aantal;
          
            OrderLines.Add(orderline);
            OrderTotaal += orderline.Product.UnitPrice * orderline.Quantity;
        }
       
      
       public OrderLine GetOrderline(int id)
        {
           return OrderLines.SingleOrDefault(ol => ol.OrderId == id);
        }
        //rewrite code so that all orderlines are scanned through to find an orderline with a certain product
       /* public OrderLine GetOrderlineWithCertainProduct (int productId)
        {
            //return OrderLines
       */
    }
}
