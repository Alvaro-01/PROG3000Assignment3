using Assignment3.Core.Models;

namespace Assignment3.Core.Interfaces;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId);
    Task<IEnumerable<Comment>> GetAllCommentsAsync();
    
    Task<Comment?> GetCommentByIdAsync(int id);
    Task<Comment> CreateCommentAsync(Comment comment);
    Task UpdateCommentAsync(Comment comment);
    Task DeleteCommentAsync(Comment comment);
}