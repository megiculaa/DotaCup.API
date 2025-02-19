using DotaCup.API.Models.Entities;
using DotaCup.API.Models.Responses;
using DotaCup.API.Models.ViewModels;

namespace DotaCup.API.Data.Interfaces;

public interface IGoogleAuthService
{
    Task<BaseResponse<ApplicationUser>> GoogleSignIn(GoogleAuthViewModel model);
}
