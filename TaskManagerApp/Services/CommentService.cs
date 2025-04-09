using Microsoft.EntityFrameworkCore;
using TaskManagerApp;

public class CommentService
{
    private readonly TaskMasterDbContext _context;

    public CommentService(TaskMasterDbContext context)
    {
        _context = context;
    }

    // Method to get all comments
    public async Task<List<Comment>> GetCommentsAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    // Method to get comments by task ID
    public async Task<List<Comment>> GetCommentsByTaskIdAsync(int taskId)
    {
        return await _context.Comments.Where(c => c.idTask == taskId).ToListAsync();
    }

    // Method to add a new comment
    public async Task AddCommentAsync(Comment comment)
    {
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
    }

    // Method to delete a comment by ID
    public async Task DeleteCommentAsync(int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment != null)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}