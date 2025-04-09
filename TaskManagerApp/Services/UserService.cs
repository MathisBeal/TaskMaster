using Microsoft.EntityFrameworkCore;
using TaskManagerApp;

public class UserService
{
    private readonly TaskMasterDbContext _context;

    public UserService(TaskMasterDbContext context)
    {
        _context = context;
    }

    // Method to get all users from the database
    public async Task<List<User>> ObtenirUtilisateursAsync()
    {
        return await _context.Users.ToListAsync();
    }

    // Method to get a user by ID
    public async Task<User?> ObtenirUtilisateurParIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    // Method to get a user by email
    public async Task<User?> ObtenirUtilisateurParEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.email == email);
    }

    // Method to add a new user
    public async Task AjouterUtilisateurAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    // Method to update an existing user
    public async Task ModifierUtilisateurAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    // Method to delete a user by ID
    public async Task SupprimerUtilisateurAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}