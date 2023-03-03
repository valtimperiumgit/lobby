using Lobby.Logic.Errors;
using Lobby.Models.Dto.User;
using Lobby.Models.Entities.User;

namespace Lobby.Logic.Interfaces;

public interface IAuthorizationService
{
    Task<User> Login(string email, string password);

    Task<string> Registration(CreateUserDto user);
    
    Task ValidateUserCreating(CreateUserDto user);


}