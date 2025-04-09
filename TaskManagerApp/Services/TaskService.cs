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
    public async Task<List<Task>> GetTasksAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    // Method to get a task by ID
    public async Task<Task?> GetTaskByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    // Method to add a new task
    public async Task AddTaskAsync(Task task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
    }

    // Method to update an existing task
    public async Task UpdateTaskAsync(Task task)
    {
        _context.Tasks.Update(task);
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
}