using Microsoft.EntityFrameworkCore;
using TaskManagerApp;

public class UserService
{
    private readonly TaskMasterDbContext _context;

    public UserService(TaskMasterDbContext context)
    {
        _context = context;
    }

        // Méthode pour obtenir tous les utilisateurs depuis la base de données
    public async Task<List<User>> ObtenirUtilisateursAsync()
    {
        // Récupère tous les utilisateurs
        return await _context.Users.ToListAsync();
    }
}