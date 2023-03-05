using Lobby.Models.Entities.Icon;
using Lobby.Models.Entities.User;

namespace Lobby.Data.Interfaces;

public interface IUserRepository
{
    public Task<User> GetUserById(Guid id);
    public Task<User> GetUserByEmail(string email);
    public Task<User> CreateUser(User user);
    
    public Task AddUserIcons(List<UserIcon> icons);
    Task UpdateLastLogin(Guid userId);
}