using DotaCup.API.Data.Interfaces;
using DotaCup.API.Models.Entities;
using DotaCup.API.Models.Requests;
using DotaCup.API.Models.Responses;
using DotaCup.API.Models.ViewModels;
using DotaCup.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotaCup.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtService _jwtService;
    private readonly IGoogleAuthService _googleAuthService;

    public AuthController(
        UserManager<ApplicationUser> userManager,
        IJwtService jwtService,
        IGoogleAuthService googleAuthService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
        _googleAuthService = googleAuthService;
    }

    // POST: api/Auth/Registration
    [HttpPost("registration")]
    public async Task<ActionResult> RegisterUser([FromForm] RegisterRequest user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var exist = await _userManager.FindByNameAsync(user.UserName);

        if (exist != null)
        {
            return BadRequest("Username already exists.");
        }

        var result = await _userManager.CreateAsync(
            new ApplicationUser() { UserName = user.UserName, Email = user.Email },
            user.Password
        );

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        user.Password = null;
        return Ok(user);
    }

    // POST: api/Auth/Login
    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationResponse>> LoginUser([FromForm] AuthenticationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Bad credentials");
        }

        var user = await _userManager.FindByNameAsync(request.UserName);

        if (user == null)
        {
            return BadRequest("Bad credentials");
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!isPasswordValid)
        {
            return BadRequest("Bad credentials");
        }

        var token = _jwtService.CreateToken(user);

        return Ok(token);
    }

    [HttpPost("google-signin")]
    [ProducesResponseType(typeof(BaseResponse<bool>), 200)]
    public async Task<IActionResult> GoogleSignIn(GoogleAuthViewModel model)
    {
        try
        {
            var response = await _googleAuthService.GoogleSignIn(model);

            if (response.Errors.Any())
                return BadRequest(new BaseResponse<AuthenticationResponse>(response.ResponseMessage, response.Errors));

            var jwtResponse = _jwtService.CreateToken(response.Data);

            return Ok(new AuthenticationResponse { Token = jwtResponse.Token, Expiration = jwtResponse.Expiration});
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}
