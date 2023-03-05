using Lobby.Models.Entities.Icon;
using Lobby.Models.Enums;

namespace Lobby.Data.Interfaces;

public interface IIconRepository
{
    Task<List<Icon>> GetIconsByRarity(Rarity? rarity);
    Task<Icon> GetIconById(Guid id);
}