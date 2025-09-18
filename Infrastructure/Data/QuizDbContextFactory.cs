using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data;

internal class QuizDbContextFactory : IDesignTimeDbContextFactory<QuizDbContext>
{
    public QuizDbContext CreateDbContext(string[] args)
    {
        var projectRoot = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..");
        var folderPath = Path.Combine(projectRoot, "Infrastucture", "Database");
        Directory.CreateDirectory(folderPath);
        var dbPath = Path.Combine(folderPath, "QuizDb.db");
        var optionsBuilder = new DbContextOptionsBuilder<QuizDbContext>();
        optionsBuilder.UseSqlite($"Data Source={dbPath}");


        return new QuizDbContext(optionsBuilder.Options);
    }


}
