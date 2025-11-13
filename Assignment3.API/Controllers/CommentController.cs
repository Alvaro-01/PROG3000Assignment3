using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

using Assignment3.Core.Interfaces;
using Assignment3.Core.Models;
using Assignment3.Core.Dtos;
using System.Threading.Tasks;

namespace Assignment3.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _commentRepository;

    public CommentController(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllComments()
    {
        var comments = await _commentRepository.GetAllCommentsAsync();
        return Ok(comments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCommentById(int id)
    {
        var comment = await _commentRepository.GetCommentByIdAsync(id);
        if (comment == null)
        {
            return NotFound();
        }
        return Ok(comment);
    }

    [HttpGet("posts/{postId}/comments")]
    public async Task<IActionResult> GetCommentsByPostId(int postId)
    {
        var comments = await _commentRepository.GetCommentsByPostIdAsync(postId);
        return Ok(comments);
    }

    [HttpPost("posts/{postId}/comments")]
    public async Task<IActionResult> CreateComment([FromBody] CommentCreateDTO commentDto)
    {
        var comment = new Comment
        {
            Content = commentDto.Content,
            PostId = commentDto.PostId
        };

        var createdComment = await _commentRepository.CreateCommentAsync(comment);
        return CreatedAtAction(nameof(GetCommentById), new { id = createdComment.Id }, createdComment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateComment(int id, [FromBody] CommentUpdateDto commentDto)
    {
        var existingComment = await _commentRepository.GetCommentByIdAsync(id);
        if (existingComment == null)
        {
            return NotFound();
        }

        existingComment.Content = commentDto.Content;

        await _commentRepository.UpdateCommentAsync(existingComment);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchComment(int id, [FromBody] JsonPatchDocument<CommentUpdateDto> patchDoc)
    {
        var existingComment = await _commentRepository.GetCommentByIdAsync(id);
        if (existingComment == null)
        {
            return NotFound();
        }

        var commentToPatch = new CommentUpdateDto
        {
            Content = existingComment.Content
        };

        patchDoc.ApplyTo(commentToPatch, ModelState);

        if (!TryValidateModel(commentToPatch))
        {
            return ValidationProblem(ModelState);
        }

        existingComment.Content = commentToPatch.Content;

        await _commentRepository.UpdateCommentAsync(existingComment);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var existingComment = await _commentRepository.GetCommentByIdAsync(id);
        if (existingComment == null)
        {
            return NotFound();
        }

        await _commentRepository.DeleteCommentAsync(existingComment);
        return NoContent();
    }

    



}