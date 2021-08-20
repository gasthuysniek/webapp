using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Data.Interfaces;
using Webshop.Models.Domain;

namespace Webshop.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<User> _users;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _users = dbContext.User;

        }
        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Delete(User user)
        {
            _users.Remove(user);
        }

        public List<User> GetAll()
        {
            return _users.ToList();
        }

        public User GetByEmail(string email)
        {
            /* return _users.Include(u=>u.OrderListOfUser)
                 .Include(c => c.Favorites)
                 //then include call for product object only possible cause it is a list !
                 .ThenInclude(fp => fp.Product)

                 .SingleOrDefault(u => u.Email == email);*/
            return _users//.Include(c => c.Favorites).ThenInclude(f => f.Product)
                //.Include(u => u.FavoriteProducts)
                .Include(u => u.OrderListOfUser)
                .SingleOrDefault(c => c.Email == email);
        }

    
        
        public User GetById(int id)
        {
            return _users.Include(u=>u.OrderListOfUser).FirstOrDefault(u => u.UserId == id);
        }
        /*public User GetByEmail(string email)
        {
            return _users.FirstOrDefault(u => u. == username);
        }*/

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Update(user);
        }
    }
}
