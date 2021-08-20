using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Data.Interfaces;
using Webshop.Models.Domain;

namespace Webshop.Data.Repositories
{
    public class OrderlineRepository : IOrderlineRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<OrderLine> _orderlines;

        public OrderlineRepository(ApplicationDbContext dbcontext)
        {
            _context = dbcontext;
            _orderlines = dbcontext.Orderlines;


        }

        public void Add(OrderLine orderline)
        {
            _orderlines.Add(orderline);
        }

        public void Delete(OrderLine orderline)
        {
            _orderlines.Remove(orderline);
        }

        public List<OrderLine> GetAll()
        {
            return _orderlines.ToList();
        }

        public OrderLine GetById(int orderid, int productid)
        {
            //single or default want returnt maar 1 element dat voldoet aan de voorwaarde
            return _orderlines.SingleOrDefault(ol => ol.OrderId == orderid && ol.ProductId == productid);
        }

        /*public IEnumerable<P> GetByProductName(string name)
        {
            return _products.Where(p => p.ProductName == name);
        }*/
        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        /* public bool TryGetProduct(int productid, out Product product)
         {
             product = _context.Products.FirstOrDefault(p => p.ProductId == productid);
             return product != null;
         }*/

        public void Update(OrderLine orderline)
        {
            _context.Update(orderline);
        }
    }
}
