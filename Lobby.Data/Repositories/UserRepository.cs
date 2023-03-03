using Lobby.Data.EFCore;
using Lobby.Data.Interfaces;
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
}