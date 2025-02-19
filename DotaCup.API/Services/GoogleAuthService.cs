using DotaCup.API.Data;
using DotaCup.API.Data.Interfaces;
using DotaCup.API.Extensions;
using DotaCup.API.Models.Config;
using DotaCup.API.Models.Entities;
using DotaCup.API.Models.Requests;
using DotaCup.API.Models.Responses;
using DotaCup.API.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace DotaCup.API.Services;

public class GoogleAuthService : IGoogleAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationContext _context;
    private readonly GoogleAuthConfig _googleAuthConfig;

    public GoogleAuthService(
        UserManager<ApplicationUser> userManager,
        ApplicationContext context,
        IOptions<GoogleAuthConfig> googleAuthConfig
        )
    {
        _userManager = userManager;
        _context = context;
        _googleAuthConfig = googleAuthConfig.Value;
    }

    public async Task<BaseResponse<ApplicationUser>> GoogleSignIn(GoogleAuthViewModel model)
    {

        Payload payload = new();

        try
        {
            payload = await ValidateAsync(model.IdToken, new ValidationSettings
            {
                Audience = new[] { _googleAuthConfig.ClientId }
            });

        }
        catch (Exception ex)
        {
            return new BaseResponse<ApplicationUser>(null, new List<string> { "Failed to get a response." });
        }

        var userToBeCreated = new CreateUserFromSocialLogin
        {
            UserName = payload.Name,
            Email = payload.Email,
            AvatarUrl = payload.Picture,
            LoginProviderSubject = payload.Subject,
        };

        var user = await _userManager.CreateUserFromSocialLogin(_context, userToBeCreated);

        if (user is not null)
            return new BaseResponse<ApplicationUser>(user);

        else
            return new BaseResponse<ApplicationUser>(null, new List<string> { "Failed to get response." });
    }
}
