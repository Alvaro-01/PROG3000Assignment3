using System.ComponentModel.DataAnnotations;

namespace Assignment3.Core.Dtos;

    public class PostCreateDTO
    {


        [Required]
        [MaxLength(200)]
        public string? Title { get; set; }

        [Required]
        public string? Content { get; set; }

        

    }
