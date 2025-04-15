#define DEBUG

using DotNetEnv;
using DotNetEnv.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace TaskManagerApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        // Use the .env
        Env.Load("./../.env");
        builder.Configuration.AddDotNetEnv();
        // ============

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Configurer le DbContext avec MySQL et la chaîne de connexion
        builder.Services.AddDbContext<TaskMasterDbContext>(options =>
        {
            string dbServer = "localhost";

            // Use null-coalescing operator to provide a fallback value or throw an exception
            // string dbDatabase = Environment.GetEnvironmentVariable("DB_DATABASE") ?? throw new InvalidOperationException("DB_DATABASE environment variable is not set.");
            string dbDatabase = "task_master";
            dbDatabase = Env.GetString("DB_DATABASE", dbDatabase);
            // string dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? throw new InvalidOperationException("DB_USER environment variable is not set.");
            string dbUser = "user";
            dbUser = Env.GetString("DB_USER", dbUser);
            // string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? throw new InvalidOperationException("DB_PASSWORD environment variable is not set.");
            string dbPassword = "password";
            dbPassword = Env.GetString("DB_PASSWORD", dbPassword);

            string connectionString = $"Server={dbServer};Database={dbDatabase};User={dbUser};Password={dbPassword};";

            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });


#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<UserService>();
        builder.Services.AddSingleton<TaskService>();
        builder.Services.AddSingleton<SubTaskService>();
        builder.Services.AddSingleton<CommentService>();

        return builder.Build();
    }
}
