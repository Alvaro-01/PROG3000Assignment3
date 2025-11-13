using Assignment3.Core.Models;

namespace Assignment3.Core.Interfaces;
public interface IPostRepository
{
    Task<IEnumerable<Post>> GetAllPostsAsync();
    Task<Post?> GetPostByIdAsync(int id);
    Task<Post> CreatePostAsync(Post post);
    Task UpdatePostAsync(Post post);
    Task DeletePostAsync(Post post);
}