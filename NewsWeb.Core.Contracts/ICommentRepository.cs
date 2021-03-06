using NewsWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWeb.Core.Contracts
{
    public interface ICommentRepository
    {
        public List<Comment> GetComments();
        public void AddComment(Comment comment);
        public void DeleteComment(int id);
    }
}
