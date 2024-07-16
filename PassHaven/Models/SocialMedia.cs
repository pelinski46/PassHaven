namespace PassHaven.Models;

public class SocialMedia
{
    public int Id { get; set; }
    public string PlatformName { get; set; }
    public string PasswordHash { get; set; }
    public int VaultId { get; set; }
    public Vault Vault { get; set; } = null!;
}
