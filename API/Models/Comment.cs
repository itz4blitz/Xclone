using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(240, MinimumLength = 3, ErrorMessage = "The field {0} must be a string with a minimum length of {2} and a maximum length of {1}.")]
        public string Content { get; set; } = string.Empty;
        public int TweetId { get; set; }
        public Tweet? Tweet { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}