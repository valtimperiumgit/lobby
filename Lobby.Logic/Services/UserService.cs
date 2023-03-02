using Lobby.Data.Interfaces;
using Lobby.Logic.Interfaces;
using Lobby.Models.Entities.User;

namespace Lobby.Logic.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUserById(Guid id)
    {
        return await _userRepository.GetUserById(id);
    }
}