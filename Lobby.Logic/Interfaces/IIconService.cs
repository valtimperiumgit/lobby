using Lobby.Models.Entities.Icon;
using Lobby.Models.Enums;

namespace Lobby.Logic.Interfaces;

public interface IIconService
{
    Task<List<Icon>> GetIconsByRarity(Rarity? rarity);
}