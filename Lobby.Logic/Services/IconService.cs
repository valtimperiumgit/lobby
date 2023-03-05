using Lobby.Data.Interfaces;
using Lobby.Logic.Interfaces;
using Lobby.Models.Entities.Icon;
using Lobby.Models.Enums;

namespace Lobby.Logic.Services;

public class IconService : IIconService
{
    private readonly IIconRepository _iconRepository;
    
    public IconService(IIconRepository iconRepository)
    {
        _iconRepository = iconRepository;
    }
    
    public async Task<List<Icon>> GetIconsByRarity(Rarity? rarity)
    {
        return await _iconRepository.GetIconsByRarity(rarity);
    }

    public async Task<Icon> GetIconById(Guid id)
    {
        return await _iconRepository.GetIconById(id);
    }
}