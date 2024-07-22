using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PassHaven.Models;

namespace PassHaven.Data;


public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vault>()
                .HasMany(v => v.PasswordEntries)
                .WithOne(sm => sm.Vault)
                .HasForeignKey(sm => sm.VaultId)
                .IsRequired(); // Ensure the relationship is required
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Vault> Vaults { get; set; }
    public DbSet<PasswordEntry> PasswordEntries { get; set; }
}
