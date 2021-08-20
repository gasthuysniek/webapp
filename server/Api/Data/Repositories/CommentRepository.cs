using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Data.Interfaces;
using Webshop.Models.Domain;

namespace Webshop.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Comment> _comments;
        public CommentRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _comments = dbContext.Comment;
        }
        public void Add(Comment comment)
        {
             _comments.Add(comment);
        }

        public void Delete(Comment comment)
        {
            _comments.Remove(comment);
        }

        public List<Comment> GetAll()
        {
            return _comments.ToList();
        }

        public List<Comment> GetByUser(int userid)
        {
            return _comments.Where(c => c.User.UserId == userid).ToList();
            
        }

        /*public List<Comment> GetById(User user, )
        {
            return context.Comments.FirstOrDefault(c =>c.c)
        }*/

        public IEnumerable<Comment> GetBy( DateTime postingdate,int userid = -1, int productid = -1
            )
        {
            //BECAUSE DATETIME CANNOT BE KNOW IF NOTHING IS ASSIGNED, CREATE FAR IN PAST
            DateTime longAgo = DateTime.Now.AddYears(-200);
            var comments = _comments
                //.Include(r => r.PostingDateComment)
                .AsQueryable();
            if(postingdate >longAgo)
                comments = comments.Where(r => r.PostingDateComment==postingdate);
            if (userid != -1)
            {
                //string userid = int.Parse(userid);
                comments = comments.Where(r => r.User.UserId == userid);
            }
            if (productid !=-1)
                comments = comments.Where(r => r.ProductId == productid);
            return comments;//.OrderBy(r => r.PostingDateComment).ThenBy(r => r.User.UserId).ToList();
        } 
       /* public IEnumerable<Comment> GetByUserId(Guid userid)
        {
            var comments = _comments.Include(r => r.PostingDateComment).AsQueryable();
            comments = comments
        }*/
        public Comment GetById(int id)
        {
            return _comments.FirstOrDefault(c => c.CommentId == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Comment comment)
        {
            _context.Update(comment);
        }

    
    }
}
