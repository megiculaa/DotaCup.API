namespace DotaCup.API.Models.Requests;

public class EnterTournamentRequest
{
    public Guid TournamentId { get; set; }
    public Guid UserId { get; set; }
}
    