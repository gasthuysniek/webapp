using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Models.Domain;

namespace Webshop.Data.Interfaces
{
    public interface ICommentRepository
    {
        void SaveChanges();
        void Delete(Comment comment);
        void Add(Comment comment);
        void Update(Comment comment);
        List<Comment> GetAll();
        List<Comment> GetByUser(int userid);
        //  Comment GetById();
        IEnumerable<Comment> GetBy(DateTime postingDate, int userid =-1, int productid = -1);
        Comment GetById(int id);
    }
}
