namespace DotaCup.API.Models.Requests;

public class CreateUserFromSocialLogin
{
    public string Email { get; set; }
    public string AvatarUrl { get; set; }
    public string UserName { get; set; }
    public string LoginProviderSubject { get; set; }
}
