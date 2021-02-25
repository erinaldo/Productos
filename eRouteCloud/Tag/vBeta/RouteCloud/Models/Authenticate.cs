using System.ComponentModel.DataAnnotations;

namespace RouteCloud.Models
{
    public partial class Authenticate
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}