using Lobby.Data.EFCore;
using Lobby.Data.Interfaces;
using Lobby.Models.Entities.Icon;
using Lobby.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Lobby.Data.Repositories;

public class IconRepository : IIconRepository
{
    public IconRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private readonly MyDbContext _dbContext;
    
    public async Task<List<Icon>> GetIconsByRarity(Rarity? rarity)
    {
        if (rarity == null)
        {
            return await _dbContext.Icons.AsNoTracking().ToListAsync();
        }
        
        return await _dbContext.Icons.AsNoTracking().Where(icon => icon.RariryId == (int)rarity).ToListAsync();
    }
}