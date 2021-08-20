using System.Collections.Generic;
using Webshop.Models.Domain;

namespace Webshop.Data.Repositories
{
    public interface IOrderlineRepository
    {


        void Add(OrderLine orderline);


        void Delete(OrderLine orderline);

        List<OrderLine> GetAll();


        OrderLine GetById(int orderid, int productid);


        /*public IEnumerable<P> GetByProductName(string name)
        {
            return _products.Where(p => p.ProductName == name);
        }*/

        void SaveChanges();

        /* public bool TryGetProduct(int productid, out Product product)
         {
             product = _context.Products.FirstOrDefault(p => p.ProductId == productid);
             return product != null;
         }*/

        void Update(OrderLine orderline);
        
    }
}