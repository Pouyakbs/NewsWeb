using System.ComponentModel.DataAnnotations;

namespace NewsWeb.Core.Entities
{
    public class AdminAuthentication
    {
        [Key]
        public int UsernameId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
