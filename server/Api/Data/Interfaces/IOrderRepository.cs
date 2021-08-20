using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.DTOs;
using Webshop.Models.Domain;

namespace Webshop.Data.Interfaces
{
    public interface IOrderRepository
    {
        Order GetById(int id);
        //to save all the changes made in the context to the db
        bool TryGetOrder(int id, out Order order);
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetBy(int userid = -1,string productName = null);
        void SaveChanges();
        void Delete(Order order);
        void Add(Order order);
        void Update(Order order);
    
        /*IEnumerable<OrderDTO> GetByUser(User user
            //int userid
            );*/
       //bool TryGetProductOutOfContent(int productid, out Product product);
    }
}
