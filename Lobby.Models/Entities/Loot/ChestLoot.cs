using Lobby.Models.Enums;

namespace Lobby.Models.Entities.Loot;

public class ChestLoot
{
    public Guid Id { get; set; }
    
    public Guid ChestId { get; set; }
    
    public LootType Type { get; set; }
    
    public decimal BlueEssenceAmount { get; set; }
    
    public decimal Chance { get; set; }
}