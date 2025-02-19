namespace DotaCup.API.Models.Requests;

public class SetCaptainsRequest
{
    public Guid TournamentId { get; set; }
    public List<Guid> UserIds { get; set; }
}
