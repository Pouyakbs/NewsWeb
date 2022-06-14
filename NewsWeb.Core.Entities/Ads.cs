using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsWeb.Core.Entities
{
    public class Ads
    {
        public int AdsId { get; set; }
        public string AdsImages { get; set; }
        [NotMapped]
        [Display(Name = "AdsImages")]
        public IFormFile AdsImage { get; set; }
    }
}
