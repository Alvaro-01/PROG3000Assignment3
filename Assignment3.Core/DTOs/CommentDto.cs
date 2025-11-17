using System.ComponentModel.DataAnnotations;

namespace Assignment3.Core.Dtos;

public class CommentDto
{
    [Key]
    public int Id { get; set; }

    public int PostId { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public string? Content { get; set; }

    public string? PostTitle { get; set; }

    public DateTime CreatedAt { get; set;  } = DateTime.UtcNow;
}