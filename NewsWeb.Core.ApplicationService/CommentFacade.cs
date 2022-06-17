using NewsWeb.Core.Contracts;
using NewsWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWeb.Core.ApplicationService
{
    public class CommentFacade: ICommentFacade
    {
        ICommentRepository commentRepository;
        public CommentFacade(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }
        public IEnumerable<Comment> GetComments()
        {
            return commentRepository.GetComments();
        }
        public void AddComment(Comment comment)
        {
            commentRepository.AddComment(comment);
        }
        public void DeleteComment(int id)
        {
            commentRepository.DeleteComment(id);
        }
    }
}
