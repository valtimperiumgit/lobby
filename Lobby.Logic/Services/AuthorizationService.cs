using Lobby.Data.Interfaces;
using Lobby.Extensions.Interfaces;
using Lobby.Extensions.Utilities;
using Lobby.Logic.Errors;
using Lobby.Logic.Interfaces;
using Lobby.Models.Dto.User;
using Lobby.Models.Entities.Icon;
using Lobby.Models.Entities.User;
using Lobby.Models.Enums;

namespace Lobby.Logic.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IIconService _iconService;
    public AuthorizationService(IUserRepository userRepository, IPasswordHasher passwordHasher, IIconService iconService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _iconService = iconService;
    }
    
    public async Task<User> Login(string email, string password)
    {
        var user = await _userRepository.GetUserByEmail(email);

        if (user == null || _passwordHasher.Hash(user.Password) != _passwordHasher.Hash(password))
        {
            throw ApiError.NotFound("User with inputed login and password was not found.");
        }

        return user;
    }

    public async Task<string> Registration(CreateUserDto dto)
    {
        await ValidateUserCreating(dto);

        List<Icon> commonIcons = await _iconService.GetIconsByRarity(Rarity.Common);

        var randomIcon = commonIcons.OrderBy(icon => icon.Id).ToList()[0];
        
        User user = new User
        (
            Guid.NewGuid(),
            dto.Alias,
            dto.Email,
            _passwordHasher.Hash(dto.Password),
            DateTime.Now,
            DateTime.Now, 
            false,
            randomIcon.Id
        );

        return "token";
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
        
        var user = await _userRepository.GetUserByEmail(dto.Email);

        if (user != null)
        {
            throw ApiError.BadRequest("User with this email already exist.", null);
        }
    }
}