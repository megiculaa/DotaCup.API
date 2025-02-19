using System.ComponentModel.DataAnnotations;

namespace DotaCup.API.Models.Requests;

public class RegisterRequest
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}
