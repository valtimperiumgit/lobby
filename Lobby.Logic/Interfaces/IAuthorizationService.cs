using Lobby.Logic.Errors;
using Lobby.Models.Dto.Authorization;
using Lobby.Models.Dto.User;
using Lobby.Models.Entities.User;

namespace Lobby.Logic.Interfaces;

public interface IAuthorizationService
{
    Task<AuthorizationResponseDto> Login(string email, string password);

    Task<AuthorizationResponseDto> Registration(CreateUserDto user);


}