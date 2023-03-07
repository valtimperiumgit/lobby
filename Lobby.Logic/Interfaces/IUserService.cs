using Lobby.Models.Dto.User;
using Lobby.Models.Entities.Icon;
using Lobby.Models.Entities.User;

namespace Lobby.Logic.Interfaces;

public interface IUserService
{
    public Task<User> GetUserById(Guid id);
    public Task<User> GetUserByEmail(string email);
    public Task<User> CreateUser(User user);
    public Task AddUserIcons(List<UserIcon> icons);

    public Task UpdateLastLogin(Guid userId);
    
    Task ValidateUserCreating(CreateUserDto user);
}