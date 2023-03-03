using Lobby.Models.Dto.User;

namespace Lobby.Models.Dto.Authorization;

public class AuthorizationResponseDto
{
    public string Token { get; set; }
    
    public UserDto User { get; set; }
}