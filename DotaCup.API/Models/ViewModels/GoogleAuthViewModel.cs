using System.ComponentModel.DataAnnotations;

namespace DotaCup.API.Models.ViewModels;

public class GoogleAuthViewModel
{
    [Required]
    public string IdToken { get; set; }
}
