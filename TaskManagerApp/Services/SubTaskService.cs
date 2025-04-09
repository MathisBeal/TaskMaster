using Microsoft.EntityFrameworkCore;
using TaskManagerApp;

public class SubTaskService
{
    private readonly TaskMasterDbContext _context;

    public SubTaskService(TaskMasterDbContext context)
    {
        _context = context;
    }

    // Method to get all subtasks
    public async Task<List<SousTache>> GetSubTasksAsync()
    {
        return await _context.SousTaches.ToListAsync();
    }

    // Method to get subtasks by task ID
    public async Task<List<SousTache>> GetSubTasksByTaskIdAsync(int taskId)
    {
        return await _context.SousTaches.Where(st => st.idTask == taskId).ToListAsync();
    }

    // Method to add a new subtask
    public async Task AddSubTaskAsync(SousTache subTask)
    {
        _context.SousTaches.Add(subTask);
        await _context.SaveChangesAsync();
    }

    // Method to update an existing subtask
    public async Task UpdateSubTaskAsync(SousTache subTask)
    {
        _context.SousTaches.Update(subTask);
        await _context.SaveChangesAsync();
    }

    // Method to delete a subtask by ID
    public async Task DeleteSubTaskAsync(int id)
    {
        var subTask = await _context.SousTaches.FindAsync(id);
        if (subTask != null)
        {
            _context.SousTaches.Remove(subTask);
            await _context.SaveChangesAsync();
        }
    }
}