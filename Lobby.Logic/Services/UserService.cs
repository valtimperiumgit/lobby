using Lobby.Data.Interfaces;
using Lobby.Logic.Interfaces;
using Lobby.Models.Entities.Icon;
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

    public async Task<User> GetUserByEmail(string email)
    {
        return await _userRepository.GetUserByEmail(email);
    }

    public async Task<User> CreateUser(User user)
    {
        var createdUser = await _userRepository.CreateUser(user);

        return createdUser;
    }

    public async Task AddUserIcons(List<UserIcon> icons)
    {
        await _userRepository.AddUserIcons(icons);
    }

    public async Task UpdateLastLogin(Guid userId)
    {
        await _userRepository.UpdateLastLogin(userId);
    }
}