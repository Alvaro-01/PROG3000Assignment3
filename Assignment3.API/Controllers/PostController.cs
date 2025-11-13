using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

using Assignment3.Core.Interfaces;
using Assignment3.Core.Models;
using Assignment3.Core.Dtos;
using System.Threading.Tasks;

namespace Assignment3.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostRepository _postRepository;
    private readonly ICommentRepository _commentRepository;

    public PostController(IPostRepository postRepository, ICommentRepository commentRepository)
    {
        _postRepository = postRepository;
        _commentRepository = commentRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPosts()
    {
        var posts = await _postRepository.GetAllPostsAsync();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostById(int id)
    {
        var post = await _postRepository.GetPostByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        return Ok(post);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] PostCreateDTO postDto)
    {
        var post = new Post
        {
            Title = postDto.Title,
            Content = postDto.Content
        };

        var createdPost = await _postRepository.CreatePostAsync(post);
        return CreatedAtAction(nameof(GetPostById), new { id = createdPost.Id }, createdPost);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost(int id, [FromBody] PostUpdateDto postDto)
    {
        var existingPost = await _postRepository.GetPostByIdAsync(id);
        if (existingPost == null)
        {
            return NotFound();
        }

        existingPost.Title = postDto.Title;
        existingPost.Content = postDto.Content;
        existingPost.UpdatedAt = DateTime.UtcNow;

        await _postRepository.UpdatePostAsync(existingPost);

        return Ok(existingPost);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchPost(int id, [FromBody] JsonPatchDocument<PostUpdateDto> patchDoc)
    {
        if (patchDoc == null)
        {
            return BadRequest();
        }

        var existingPost = await _postRepository.GetPostByIdAsync(id);
        if (existingPost == null)
        {
            return NotFound();
        }

        var postToPatch = new PostUpdateDto
        {
            Title = existingPost.Title,
            Content = existingPost.Content
        };

        patchDoc.ApplyTo(postToPatch, ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        existingPost.Title = postToPatch.Title;
        existingPost.Content = postToPatch.Content;
        existingPost.UpdatedAt = DateTime.UtcNow;

        await _postRepository.UpdatePostAsync(existingPost);

        return Ok(existingPost);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var existingPost = await _postRepository.GetPostByIdAsync(id);
        if (existingPost == null)
        {
            return NotFound();
        }

        await _postRepository.DeletePostAsync(existingPost);

        return NoContent();
    }
}