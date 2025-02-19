using Microsoft.AspNetCore.Identity;

namespace DotaCup.API.Models.Entities;

public class ApplicationUser : IdentityUser
{
    public string? SteamUrl { get; set; }

    public string? DiscordName { get; set; }

    public string? PlayerPosition { get; set; }

    public List<Tournament>? Tournaments { get; set; } = new List<Tournament>();

    public int PTS { get; set; }

    public string? AvatarUrl { get; set; }
}
