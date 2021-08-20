using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Models.Domain;

namespace Webshop.Data.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int id);

        //User GetByUserName(string username);
        List<User> GetAll();
        User GetByEmail(string email);
        //to save all the changes made in the context to the db
        void SaveChanges();
        void Update(User user);
        void Delete(User user);
        void Add(User user);
       
    }
}
