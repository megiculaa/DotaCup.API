namespace DotaCup.API.Models.Requests;

public class CreateTournament
{
    public string ImgUrl { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public string AdditionalInfo { get; set; }
}
