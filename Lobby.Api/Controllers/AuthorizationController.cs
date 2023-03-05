using Lobby.Logic.Interfaces;
using Lobby.Models.Dto.Authorization;
using Lobby.Models.Dto.User;
using Microsoft.AspNetCore.Mvc;

namespace Lobby.Api.Controllers;

[Route("api/authorization/")]
public class AuthorizationController : ControllerBase
{
    private readonly IUserService _userService;
    
    private readonly IAuthorizationService _authorizationService;
    
    public AuthorizationController(IUserService userService, IAuthorizationService authorizationService)
    {
        _userService = userService;
        _authorizationService = authorizationService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var authResponse = await _authorizationService.Login(dto.Email, dto.Password);
        
        return Ok(authResponse);
    }
    
    [HttpPost("registration")]
    public async Task<IActionResult> Registration(CreateUserDto dto)
    {
        var authResponse = await _authorizationService.Registration(dto);
        
        return Ok(authResponse);
    }
}