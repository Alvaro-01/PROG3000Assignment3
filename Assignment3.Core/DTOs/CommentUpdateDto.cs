using System.ComponentModel.DataAnnotations;

namespace Assignment3.Core.Dtos;

public class CommentUpdateDto
{
    
    [Required]
    public string? Name { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public string? Content { get; set; }

    public string? Description { get; set; }
}