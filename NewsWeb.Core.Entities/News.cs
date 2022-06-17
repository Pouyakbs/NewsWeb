using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsWeb.Core.Entities
{
    public class News
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Text { get; set; }
        public string NewsImages { get; set; }
        public DateTime PubDate { get; set; }
        [NotMapped]
        [Display(Name = "NewsImages")]
        public IFormFile Images { get; set; }
        public List<Comment> Comments { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        
    }
}
