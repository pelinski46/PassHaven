namespace PassHaven.Models;

public class Vault
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string MasterPassword { get; set; }
    public List<SocialMedia>? SocialMedias { get; set; }
}
