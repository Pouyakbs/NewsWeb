using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWeb.Core.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }
        public DateTime PubTime { get; set; }
        public News News { get; set; }
        public int NewsId { get; set; }
    }
}
