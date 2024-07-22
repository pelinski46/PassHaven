namespace PassHaven.Models;

public class PasswordEntry
{
    public int Id { get; set; }
    public string PlatformName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public int VaultId { get; set; }
    public Vault Vault { get; set; } = null!;
}
