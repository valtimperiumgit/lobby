using Lobby.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lobby.Api.Controllers;

[Route("api/authorization/")]
public class AuthorizationController : ControllerBase
{
    private readonly IUserService _userService;
    
    public AuthorizationController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(Guid id)
    {
        var user = await _userService.GetUserById(id);
        
        return Ok(user);
    }
}