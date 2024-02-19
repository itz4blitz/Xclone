using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public string Username { get; set; } = string.Empty;
    }
}
