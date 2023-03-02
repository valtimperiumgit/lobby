using Lobby.Models.Entities.User;

namespace Lobby.Data.Interfaces;

public interface IUserRepository
{
    public Task<User> GetUserById(Guid id);
}