using Microsoft.EntityFrameworkCore;
using TaskManagerApp;

public class TaskService
{
    private readonly TaskMasterDbContext _context;

    public TaskService(TaskMasterDbContext context)
    {
        _context = context;
    }

    // Method to get all tasks from the database
    public async Task<List<Tache>> GetTasksAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    // Method to get a task by ID
    public async Task<Tache?> GetTaskByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    // Method to add a new task
    public async Task AddTaskAsync(Tache tache)
    {
        _context.Tasks.Add(tache);
        await _context.SaveChangesAsync();
    }

    // Method to update an existing task
    public async Task UpdateTaskAsync(Tache tache)
    {
        _context.Tasks.Update(tache);
        await _context.SaveChangesAsync();
    }

    // Method to delete a task by ID
    public async Task DeleteTaskAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task != null)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }

    // Method to get tasks by user ID
    public async Task<List<Tache>> GetTasksByUserIdAsync(int userId)
    {
        return await _context.Tasks
            .Where(t => t.auteur == userId)
            .ToListAsync();
    }
}