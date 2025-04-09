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
    public async Task<List<SubTask>> GetSubTasksAsync()
    {
        return await _context.SubTasks.ToListAsync();
    }

    // Method to get subtasks by task ID
    public async Task<List<SubTask>> GetSubTasksByTaskIdAsync(int taskId)
    {
        return await _context.SubTasks.Where(st => st.idTask == taskId).ToListAsync();
    }

    // Method to add a new subtask
    public async Task AddSubTaskAsync(SubTask subTask)
    {
        _context.SubTasks.Add(subTask);
        await _context.SaveChangesAsync();
    }

    // Method to update an existing subtask
    public async Task UpdateSubTaskAsync(SubTask subTask)
    {
        _context.SubTasks.Update(subTask);
        await _context.SaveChangesAsync();
    }

    // Method to delete a subtask by ID
    public async Task DeleteSubTaskAsync(int id)
    {
        var subTask = await _context.SubTasks.FindAsync(id);
        if (subTask != null)
        {
            _context.SubTasks.Remove(subTask);
            await _context.SaveChangesAsync();
        }
    }
}