using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Data.Interfaces;
using Webshop.Models.Domain;

namespace Webshop.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Product> _products;
   
        public ProductRepository(ApplicationDbContext dbcontext)
        {
            _context = dbcontext;
            _products = dbcontext.Product;
       

        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            _products.Remove(product);
        }

        public List<Product> GetAll()
        {
            return _products.ToList();
        }

        public Product GetById(int id)
        {
            //single or default want returnt maar 1 element dat voldoet aan de voorwaarde
            return _products.SingleOrDefault(p => p.ProductId== id);
        }

        public IEnumerable<Product> GetByProductName(string name)
        {
            return _products.Where(p => p.ProductName == name);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

       /* public bool TryGetProduct(int productid, out Product product)
        {
            product = _context.Products.FirstOrDefault(p => p.ProductId == productid);
            return product != null;
        }*/

        public void Update(Product product)
        {
            _context.Update(product);
        }
    }
}
