using Lobby.Data.Interfaces;
using Lobby.Logic.Errors;
using Lobby.Logic.Interfaces;
using Lobby.Models.Dto.User;
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
    
    public async Task ValidateUserCreating(CreateUserDto dto)
    {
        if (dto.Email.Split('@').Length < 2)
        {
            throw ApiError.BadRequest("Invalid email format.", null);
        }

        if (dto.Password.Length < 4)
        {
            throw ApiError.BadRequest("Invalid password.", null);
        }

        if (dto.Alias.Length < 2)
        {
            throw ApiError.BadRequest("Alias length must be at least 2 characters.", null);
        }
        
        var user = await GetUserByEmail(dto.Email);

        if (user != null)
        {
            throw ApiError.BadRequest("User with this email already exist.", null);
        }
    }
}