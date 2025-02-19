using DotaCup.API.Models.Entities;
using DotaCup.API.Models.Responses;

namespace DotaCup.API.Data.Interfaces;

public interface IJwtService
{
    AuthenticationResponse CreateToken(ApplicationUser user);
}
