using Microsoft.EntityFrameworkCore;
using Models;

namespace Infrastructure.Data;

public class QuizDbContext : DbContext
{
    public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
    {
    }
    public DbSet<Question> Questions { get; set; }

    public DbSet<Reponse> Reponses { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasMany(q => q.Reponses)
                  .WithOne(r => r.Question)
                  .HasForeignKey(r => r.QuestionId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
        base.OnModelCreating(modelBuilder);
    }

}
