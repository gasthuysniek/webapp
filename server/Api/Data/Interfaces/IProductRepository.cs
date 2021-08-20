using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Models.Domain;

namespace Webshop.Data.Interfaces
{
    public interface IProductRepository
    {
        Product GetById(int id);
        IEnumerable<Product> GetByProductName(string name = null);
        //to save all the changes made in the context to the db
        void SaveChanges();
        void Delete(Product product);
        void Add(Product product);
        List<Product> GetAll();
        void Update(Product product);
      //  bool TryGetProduct(int productid, out Product product);
    }
}
