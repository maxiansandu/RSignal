using Microsoft.EntityFrameworkCore;
using Chat.Domain.Entities;
using Chat.Repository.Configurations;

namespace Chat.Repository;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users{get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());

    }
}
