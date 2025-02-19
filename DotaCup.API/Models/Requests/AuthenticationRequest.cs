using System.ComponentModel.DataAnnotations;

namespace DotaCup.API.Models.Requests;

public class AuthenticationRequest
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}
