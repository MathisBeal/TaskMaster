using Microsoft.EntityFrameworkCore;
using TaskManagerApp;

public class TaskMasterDbContext : DbContext
{

    // Table des utilisateurs
    public DbSet<User> Users { get; set; }

    public TaskMasterDbContext(DbContextOptions<TaskMasterDbContext> options) : base(options) { }

// Permet de configurer des règles supplémentaires sur les entités si nécessaire
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Vous pouvez ajouter des configurations spécifiques si nécessaire
        // Par exemple : modelBuilder.Entity<Tache>().HasKey(t => t.Id);
    }
}
