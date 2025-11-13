using System.ComponentModel.DataAnnotations;

namespace Assignment3.Core.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        

        [Required]

        public string? Name { get; set; }



        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        
        [Required]
        public string? Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? Description { get; set; }

        public Post? Post { get; set; }

    
        public int PostId { get; set; }



        

        
        
    }
}