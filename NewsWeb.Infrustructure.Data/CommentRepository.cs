using NewsWeb.Core.Contracts;
using NewsWeb.Core.Entities;
using NewsWeb.Infraustraucture.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsWeb.Infrustructure.Data
{
    public class CommentRepository: ICommentRepository
    {
        private readonly MyContext Context;
        public CommentRepository(MyContext Context)
        {
            this.Context = Context;
        }
        public List<Comment> GetComments()
        {
            return Context.Comments.ToList();
        }
        public void AddComment(Comment comment)
        {
            Context.Comments.Add(comment);
            Context.SaveChanges();
        }
        public void DeleteComment(int id)
        {
            Context.Comments.Remove(new Comment() { CommentId = id });
            Context.SaveChanges();
        }
    }
}
