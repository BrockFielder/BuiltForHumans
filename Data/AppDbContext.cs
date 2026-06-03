using Microsoft.EntityFrameworkCore;
using BulitForHumans.Models;

namespace BulitForHumans.Data;

public class AppDbContext : DbContext
{
    // The constructor passes configuration settings (like the connection string) to the base DbContext
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // These properties map directly to your database tables
    public DbSet<Project> Projects { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Image> Images { get; set; } 
    public DbSet<ContactMessage> ContactMessages => Set<ContactMessage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Optional: You can configure table relationships or seed data here if needed
    }
}