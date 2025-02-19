using DotaCup.API.Data.Interfaces;
using DotaCup.API.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotaCup.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtService _jwtService;
    public UserController(
        UserManager<ApplicationUser> userManager,
        IJwtService jwtService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
    }

    // GET: api/User/{username}
    [HttpGet("{username}")]
    public async Task<ActionResult<ApplicationUser>> Get(string username)
    {
        var user = await _userManager.FindByNameAsync(username);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    // GET: api/User/
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = _userManager.Users;

        if (users == null)
        {
            return NotFound();
        }

        return Ok(users);
    }

    // PUT: api/User/{username}
    [HttpPut("{id}")]
    public async Task<ActionResult<ApplicationUser>> Put(ApplicationUser user)
    {
        return Ok(await _userManager.UpdateAsync(user));
    }
}
