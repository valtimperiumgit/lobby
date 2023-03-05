using Lobby.Data.EFCore;
using Lobby.Data.Interfaces;
using Lobby.Models.Entities.Icon;
using Lobby.Models.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Lobby.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MyDbContext _dbContext;

    public UserRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<User> GetUserById(Guid id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
    }

    public async Task<User> CreateUser(User user)
    {
        var createdUser = await _dbContext.Users.AddAsync(user);

        await _dbContext.SaveChangesAsync();
        
        return createdUser.Entity;
    }

    public async Task AddUserIcons(List<UserIcon> icons)
    {
        await _dbContext.UsersIcons.AddRangeAsync(icons);
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateLastLogin(Guid userId)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
        user.LastLogin = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();
    }
}