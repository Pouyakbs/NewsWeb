using System.Collections.Generic;

namespace NewsWeb.Core.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public List<News> News { get; set; }
    }
}
