using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Models.Domain;

namespace Webshop.Data.Interfaces
{
    public interface IFavoriteProductRepository
    {
        FavoriteProduct GetById(int id);
        IEnumerable<FavoriteProduct> GetByProductName(string name = null);
        //to save all the changes made in the context to the db
        void SaveChanges();
        void Delete(FavoriteProduct product);
        void Add(FavoriteProduct product);
        List<FavoriteProduct> GetAll();
        void Update(FavoriteProduct product);
        //  bool TryGetProduct(int productid, out Product product);
    }
}
