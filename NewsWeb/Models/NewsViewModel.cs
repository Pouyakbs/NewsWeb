using NewsWeb.Core.Entities;
using System.Collections.Generic;

namespace NewsWeb.Models
{
    public class NewsViewModel
    {
        public IEnumerable<News> News { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
        public IEnumerable<Ads> Ads { get; set; }
    }
}
