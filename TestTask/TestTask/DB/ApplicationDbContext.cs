using Microsoft.EntityFrameworkCore;
using TestTask.Entity;

namespace TestTask.DB
{
  public class ApplicationDbContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=app.db");
    }

    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<Request> Requests => Set<Request>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Request>()
          .HasOne(r => r.User)
          .WithMany(u => u.Requests)
          .HasForeignKey(d => d.UserId);

      modelBuilder.Entity<Request>()
        .HasKey(r => r.Id);

      modelBuilder.Entity<UserEntity>()
        .HasKey(u => u.Id);
    }
  }
}

