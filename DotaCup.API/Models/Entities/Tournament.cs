using DotaCup.API.Models.Entities.Base;

namespace DotaCup.API.Models.Entities;

public class Tournament : BaseEntity
{
    public string ImgUrl { get; set; }
    public string Description { get; set; }
    public string AdditionalInfo { get; set; }
    public DateTime StartDate { get; set; }
    public bool IsActive { get; set; } = true;
    public List<Guid>? Captains { get; set; } = new List<Guid>();

    public List<ApplicationUser>? Members { get; set; } = new List<ApplicationUser>();
}
