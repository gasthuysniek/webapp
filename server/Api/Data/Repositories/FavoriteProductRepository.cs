using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Data.Interfaces;
using Webshop.Models.Domain;

namespace Webshop.Data.Repositories
{
    public class FavoriteProductRepository : IFavoriteProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<FavoriteProduct> _favoriteProducts;

        public FavoriteProductRepository(ApplicationDbContext dbcontext)
        {
            _context = dbcontext;
            _favoriteProducts = dbcontext.Favorites;


        }

        public void Add(FavoriteProduct favoriteProduct)
        {
            _favoriteProducts.Add(favoriteProduct);
        }

        public void Delete(FavoriteProduct favoriteProduct)
        {
            _favoriteProducts.Remove(favoriteProduct);
        }

        public List<FavoriteProduct> GetAll()
        {
            return _favoriteProducts.ToList();
        }

        public FavoriteProduct GetById(int id)
        {
            //single or default want returnt maar 1 element dat voldoet aan de voorwaarde
            return _favoriteProducts.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<FavoriteProduct> GetByProductName(string name)
        {
            return _favoriteProducts.Where(p => p.Product.ProductName == name);
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

        public void Update(FavoriteProduct product)
        {
            throw new NotImplementedException();
        }

        
    }
}
