using System.ComponentModel.DataAnnotations;

namespace Assignment3.Core.Dtos;

    public class PostCreateDTO
    {


        [Required]
        [MaxLength(200)]
        public string? Title { get; set; }

        [Required]
        public string? Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
