using ExamBot.Configuration;
using ExamBot.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using User = ExamBot.Domain.Entity.User;

namespace ExamBot.Service.DataContext;

public class DataAppContext : DbContext
{
    public DataAppContext()

    {
        
    }
    
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<ExamResult> Results { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Settings.dbConnectionString);
        base.OnConfiguring(optionsBuilder);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("ExamAppBot");

        modelBuilder
            .Entity<Exam>()
            .Property(x => x.ExamContent)
            .HasColumnType("jsonb");
        
        modelBuilder
            .Entity<ExamResult>()
            .Property(x => x.ExamQuestions)
            .HasColumnType("jsonb");
        
        modelBuilder.Entity<User>()
            .HasIndex(x => x.Login)
            .IsUnique();
        
        modelBuilder.Entity<Client>()
            .HasOne(x => x.User)
            .WithOne(x => x.Client)
            .HasForeignKey<Client>(x => x.UserId);

        modelBuilder.Entity<Client>()
            .HasMany(x=>x.ExamResults)
            .WithOne(x=>x.client)
            .HasForeignKey(x=>x.clientId);



        modelBuilder.Entity<Exam>()
            .HasMany(x => x.ExamResults)
            .WithOne(x => x.Exam)
            .HasForeignKey(x => x.Id);
        

        base.OnModelCreating(modelBuilder);
    }
}