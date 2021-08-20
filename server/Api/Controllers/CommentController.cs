using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webshop.Data.Interfaces;
using Webshop.DTOs;
using Webshop.Models.Domain;

namespace Webshop.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CommentController : ControllerBase
    {
       
            private readonly ICommentRepository _commentRepo;
            private readonly IUserRepository _userRepo;
            public CommentController(ICommentRepository context,IUserRepository userRepo)
            {
                _commentRepo = context;
                _userRepo = userRepo;
            }

            // GET: api/comments
            /// <summary>
            /// Get all the comments by giving PostingDate,userId or ProductId 
            /// </summary>
            /// <returns>Array of comments</returns>
            [HttpGet]
            public IEnumerable<Comment> GetComments(DateTime postingdate, int userid = -1,int productid = -1)
            {
                //when nothing is given as a parameter, all products are returned
                if (postingdate == null && userid ==-1 && productid == -1)
                {
                    return _commentRepo.GetAll();
                }
                return _commentRepo.GetBy(postingdate, userid, productid);
            }

            //Get: Api/comments/id
            /// <summary>
            /// Get comments by id
            /// </summary>
            /// <param name="id">The id of the comment</param>
            /// <returns>The Comment</returns>
            [HttpGet("{id}")]
            public ActionResult<Comment> GetComment(int id)
            {
                Comment comment = _commentRepo.GetById(id);
                if (comment == null) return NotFound();
                return comment;
            }


            //Post: api/comment
            /// <summary>
            /// Add a new Comment
            /// </summary>
            /// <param name="comment">New Comment</param>
            [HttpPost]
            public ActionResult<Comment> PostComment(AddCommentDTO comment)
            {
                //string userid = comment.UserId.ToString();
                Comment newComment = new Comment() {  Content= comment.Content, ProductId = comment.ProductId, Title = comment.Title,User= _userRepo.GetByEmail(User.Identity.Name) };
               
                _commentRepo.Add(newComment);
                _commentRepo.SaveChanges();
                //creates a response
                return CreatedAtAction
                    //string actionname
                    (nameof(GetComment), new { id = newComment.CommentId }, newComment);
            }
            //Put: api/Comment/id
            /// <summary>
            /// Modifying a comment
            /// </summary>
            /// <param name="comment">The comment we want to modify</param>
            /// <param name="id">Id of the comment</param>
            [HttpPut("{id}")]
            public ActionResult PutComment(int id, Comment comment)
            {
                if (comment.CommentId !=id)
                {
                    return BadRequest();
                }
                _commentRepo.Update(comment);
                _commentRepo.SaveChanges();
                //the server has succesfully forfilled the request and no additional content needs to be given
                return NoContent();
            }

        //Put: api/Comment/id
        /// <summary>
        /// Upvoting a comment
        /// </summary> 
        /// <param name="id">Id of the comment</param>
        [HttpPut("{id}/upvoteComment")]
        public ActionResult UpvoteComment(int id)
        {
         /*   if (comment.CommentId != id)
            {
                return BadRequest();
            }*/
            Comment commentToBeUpvoted = _commentRepo.GetById(id);
            if(commentToBeUpvoted==null)
            {
                return BadRequest();
            }
            commentToBeUpvoted.UpVotes++;
            _commentRepo.Update(commentToBeUpvoted);
            _commentRepo.SaveChanges();
            //the server has succesfully forfilled the request and no additional content needs to be given
            return NoContent();
        }


        //Delete: api/comment/id
        /// <summary>
        /// Deleting a comment
        /// </summary>
        /// <param name="id">The commentid of the comment that needs to be deleted</param>
        [HttpDelete("{id}")]
            public ActionResult DeleteComment(int id)
            {
                Comment commentThatNeedsDeleting = _commentRepo.GetById(id);
                if (commentThatNeedsDeleting == null)
                {
                    return BadRequest();
                }
                _commentRepo.Delete(commentThatNeedsDeleting);
                _commentRepo.SaveChanges();
                return NoContent();
            }


        }
    }

   
