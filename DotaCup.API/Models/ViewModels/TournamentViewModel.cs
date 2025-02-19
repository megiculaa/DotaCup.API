namespace DotaCup.API.Models.ViewModels;

public class TournamentViewModel
{
    public Guid Id { get; set; }

    public string ImgUrl { get; set; }

    public string Description { get; set; }

    public string AdditionalInfo { get; set; }

    public DateTime StartDate { get; set; }

    public bool IsActive { get; set; } = true;

    public List<Guid>? Captains { get; set; } = new List<Guid>();

    public List<UserViewModel>? Members { get; set; } = new List<UserViewModel>();
}
