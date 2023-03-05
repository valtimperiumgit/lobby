using Lobby.Models.Dto.User;

namespace Lobby.Models.Dto.Authorization;

public class AuthorizationResponseDto
{
    public AuthorizationResponseDto(string token, UserDto user)
    {
        Token = token;
        User = user;
    }

    public string Token { get; set; }
    
    public UserDto User { get; set; }
}