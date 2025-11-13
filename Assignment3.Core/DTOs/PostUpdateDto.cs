using System.ComponentModel.DataAnnotations;

namespace Assignment3.Core.Dtos;

    public class PostUpdateDto
    {
       

        [Required]
        [MaxLength(200)]
        public string? Title { get; set; }

        [Required]
        public string? Content { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }