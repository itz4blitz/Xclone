using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Tweet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(400, MinimumLength = 3, ErrorMessage = "The field {0} must be a string with a minimum length of {2} and a maximum length of {1}.")]
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string UserName { get; set; } = string.Empty;
    }
}
