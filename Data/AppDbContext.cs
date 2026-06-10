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
    public DbSet<Person> Persons { get; set; }
    public DbSet<ContactMessage> ContactMessages => Set<ContactMessage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Image>(image =>
        {
            // XOR ownership: exactly one of ProjectId / PersonId is set.
            image.ToTable(t => t.HasCheckConstraint(
                "CK_Image_Owner_XOR",
                "(\"ProjectId\" IS NOT NULL AND \"PersonId\" IS NULL) " +
                "OR (\"ProjectId\" IS NULL AND \"PersonId\" IS NOT NULL)"));

            // Project (1) -> Images (many), cascade delete.
            image.HasOne<Project>()
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Person (1) -> Image (1), cascade delete, enforced by unique index on PersonId.
            image.HasOne<Person>()
                .WithOne()
                .HasForeignKey<Image>(i => i.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}