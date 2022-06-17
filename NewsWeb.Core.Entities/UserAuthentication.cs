using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsWeb.Core.Entities
{
    public class UserAuthentication
    {
        [Key]
        public int UsernameId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string ProfileImage { get; set; }
        [NotMapped]
        [Display(Name = "ProfileImages")]
        public IFormFile Images { get; set; }
    }
}
