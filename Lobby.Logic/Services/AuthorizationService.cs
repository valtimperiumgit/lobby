using Lobby.Data.Interfaces;
using Lobby.Extensions.Interfaces;
using Lobby.Extensions.Utilities;
using Lobby.Logic.Errors;
using Lobby.Logic.Interfaces;
using Lobby.Models.Dto.Authorization;
using Lobby.Models.Dto.User;
using Lobby.Models.Entities.Icon;
using Lobby.Models.Entities.User;
using Lobby.Models.Enums;

namespace Lobby.Logic.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IUserService _userLogic;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IIconService _iconService;
    private readonly IJwtProvider _jwtProvider;
    public AuthorizationService( IPasswordHasher passwordHasher, IIconService iconService, IUserService userLogic, IJwtProvider jwtProvider)
    {
        _passwordHasher = passwordHasher;
        _iconService = iconService;
        _userLogic = userLogic;
        _jwtProvider = jwtProvider;
    }
    
    public async Task<AuthorizationResponseDto> Login(string email, string password)
    {
        var user = await _userLogic.GetUserByEmail(email);

        if (user == null || _passwordHasher.Hash(user.Password) != _passwordHasher.Hash(password))
        {
            throw ApiError.NotFound("User with inputed login and password was not found.");
        }

        await _userLogic.UpdateLastLogin(user.Id);

        var token = _jwtProvider.Generate(user);

        var userDto = new UserDto(user);
        userDto.Icon = _iconService.GetIconById(user.IconId).Result;
        
        return new AuthorizationResponseDto(token, userDto);
    }

    public async Task<AuthorizationResponseDto> Registration(CreateUserDto dto)
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

        var createdUser = await _userLogic.CreateUser(user);
        
        await _userLogic.AddUserIcons(commonIcons.Select(icon => 
                new UserIcon(createdUser.Id, icon.Id))
            .ToList());
    
        var authResponse = await Login(createdUser.Email, createdUser.Password);

        return authResponse;
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
        
        var user = await _userLogic.GetUserByEmail(dto.Email);

        if (user != null)
        {
            throw ApiError.BadRequest("User with this email already exist.", null);
        }
    }
}