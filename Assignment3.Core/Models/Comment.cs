using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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


        public Post? Post { get; set; }

        [Required]
        [ForeignKey("Post")]
        public int PostId { get; set; }



        

        
        
    }
}