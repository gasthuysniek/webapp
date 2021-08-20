using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Models.Domain
{
    public class OrderLine
    {

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        //public int ProductAmount { get; set; }
        public int Quantity { get; set; }

     //   public double Price { get; set; }
        // public Product Product { get; set; }
        public OrderLine(Order order, Product product, int amount
            //An order consists of multiple orderlines
            ):this()
        {
            Order = order;
            OrderId = order.Id;
       //     Price = product.UnitPrice;
            Product = product;
            ProductId = product.ProductId;
            Quantity = amount;
        }
        public OrderLine()
        {

        }

    }
}

