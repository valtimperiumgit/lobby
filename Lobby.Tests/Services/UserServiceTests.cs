using Lobby.Data.Interfaces;
using Lobby.Logic.Errors;
using Lobby.Logic.Services;
using Lobby.Models.Dto.User;
using Lobby.Models.Entities.Icon;
using Lobby.Models.Entities.User;
using Moq;

namespace Lobby.Tests.Services;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _userService = new UserService(_userRepositoryMock.Object);
    }

    [Fact]
    public async Task GetUserById_ShouldCallRepository_WithCorrectParameter()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var expectedUser = new User
        (
            userId, 
            "test", 
            "test@gmail.com",
            "212121",
            DateTime.Now,
            DateTime.Now,
            false,
            Guid.NewGuid()
        );
        _userRepositoryMock.Setup(x => x.GetUserById(userId)).ReturnsAsync(expectedUser);

        // Act
        var result = await _userService.GetUserById(userId);

        // Assert
        _userRepositoryMock.Verify(x => x.GetUserById(userId), Times.Once);
        Assert.Equal(expectedUser, result);
    }
    
    [Fact]
    public async Task GetUserByEmail_ShouldCallRepository_WithCorrectParameter()
    {
        // Arrange
        var email = "test@example.com";
        var userId = Guid.NewGuid();
        var expectedUser = new User
        (
            userId, 
            "test", 
            "test@gmail.com",
            "212121",
            DateTime.Now,
            DateTime.Now,
            false,
            Guid.NewGuid()
        );
        _userRepositoryMock.Setup(x => x.GetUserByEmail(email)).ReturnsAsync(expectedUser);

        // Act
        var result = await _userService.GetUserByEmail(email);

        // Assert
        _userRepositoryMock.Verify(x => x.GetUserByEmail(email), Times.Once);
        Assert.Equal(expectedUser, result);
    }
    
    [Fact]
    public async Task CreateUser_ShouldCallRepository_WithCorrectParameter()
    {
        // Arrange
        
        var userId = Guid.NewGuid();
        
        var user = new User
        (
            userId, 
            "test", 
            "test@gmail.com",
            "212121",
            DateTime.Now,
            DateTime.Now,
            false,
            Guid.NewGuid()
        );
        
        var expectedUser = new User
        (
            userId, 
            "test", 
            "test@gmail.com",
            "212121",
            DateTime.Now,
            DateTime.Now,
            false,
            Guid.NewGuid()
        );
        _userRepositoryMock.Setup(x => x.CreateUser(user)).ReturnsAsync(expectedUser);

        // Act
        var result = await _userService.CreateUser(user);

        // Assert
        _userRepositoryMock.Verify(x => x.CreateUser(user), Times.Once);
        Assert.Equal(expectedUser, result);
    }
    
    [Fact]
    public async Task AddUserIcons_ShouldCallRepository_WithCorrectParameter()
    {
        // Arrange
        var icons = new List<UserIcon>();
        _userRepositoryMock.Setup(x => x.AddUserIcons(icons)).Returns(Task.CompletedTask);

        // Act
        await _userService.AddUserIcons(icons);

        // Assert
        _userRepositoryMock.Verify(x => x.AddUserIcons(icons), Times.Once);
    }

    [Fact]
    public async Task UpdateLastLogin_ShouldCallRepository_WithCorrectParameter()
    {
        // Arrange
        var userId = Guid.NewGuid();
        _userRepositoryMock.Setup(x => x.UpdateLastLogin(userId)).Returns(Task.CompletedTask);

        // Act
        await _userService.UpdateLastLogin(userId);

        // Assert
        _userRepositoryMock.Verify(x => x.UpdateLastLogin(userId), Times.Once);
    }

    [Fact]
    public async Task ValidateUserCreating_ShouldThrowApiError_WhenEmailIsInvalid()
    {
        // Arrange
        var dto = new CreateUserDto { Email = "invalid_email", Password = "password", Alias = "alias" };

        // Act & Assert
        await Assert.ThrowsAsync<ApiError>(() => _userService.ValidateUserCreating(dto));
    }

    [Fact]
    public async Task ValidateUserCreating_ShouldThrowApiError_WhenPasswordIsInvalid()
    {
        // Arrange
        var dto = new CreateUserDto { Email = "valid_email@example.com", Password = "pw", Alias = "alias" };

        // Act & Assert
        await Assert.ThrowsAsync<ApiError>(() => _userService.ValidateUserCreating(dto));
    }
    
    [Fact]
    public async Task ValidateUserCreating_ShouldThrowApiError_WhenAliasIsInvalid()
    {
        // Arrange
        var dto = new CreateUserDto { Email = "valid_email@example.com", Password = "password", Alias = "a" };

        // Act & Assert
        await Assert.ThrowsAsync<ApiError>(() => _userService.ValidateUserCreating(dto));
    }

    [Fact]
    public async Task ValidateUserCreating_ShouldThrowApiError_WhenUserWithEmailAlreadyExists()
    {
        // Arrange
        var dto = new CreateUserDto { Email = "existing_email@example.com", Password = "password", Alias = "alias" };
        var userId = Guid.NewGuid();
        var existingUser = new User
        (
            userId, 
            "test", 
            "test@gmail.com",
            "212121",
            DateTime.Now,
            DateTime.Now,
            false,
            Guid.NewGuid()
        );
        _userRepositoryMock.Setup(x => x.GetUserByEmail(dto.Email)).ReturnsAsync(existingUser);

        // Act & Assert
        await Assert.ThrowsAsync<ApiError>(() => _userService.ValidateUserCreating(dto));
    }

    [Fact]
    public async Task ValidateUserCreating_ShouldNotThrowApiError_WhenDtoIsValid()
    {
        // Arrange
        var dto = new CreateUserDto { Email = "valid_email@example.com", Password = "password", Alias = "alias" };
        _userRepositoryMock.Setup(x => x.GetUserByEmail(dto.Email)).ReturnsAsync((User)null);

        // Act & Assert
        await _userService.ValidateUserCreating(dto);
    }
}