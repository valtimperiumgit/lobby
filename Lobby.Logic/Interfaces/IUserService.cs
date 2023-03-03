using Lobby.Models.Entities.User;

namespace Lobby.Logic.Interfaces;

public interface IUserService
{
    public Task<User> GetUserById(Guid id);
    public Task<User> GetUserByEmail(string email);
}