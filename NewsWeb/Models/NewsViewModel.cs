using NewsWeb.Core.Entities;
using System.Collections.Generic;

namespace NewsWeb.Models
{
    public class NewsViewModel
    {
        public List<News> News { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
        public List<Ads> Ads { get; set; }
    }
}
