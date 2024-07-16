using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PassHaven.Models;

namespace PassHaven.Data;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vault>()
                .HasMany(v => v.SocialMedias)
                .WithOne(sm => sm.Vault)
                .HasForeignKey(sm => sm.VaultId)
                .IsRequired(); // Ensure the relationship is required
    }
    public DbSet<Vault> Vaults { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
}
