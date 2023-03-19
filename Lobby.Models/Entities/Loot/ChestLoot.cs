using Lobby.Models.Enums;

namespace Lobby.Models.Entities.Loot;

public class ChestLoot
{
    public Guid Id { get; set; }
    
    public Guid IdChest { get; set; }
    
    public TypeOfLoot TypeOfLoot { get; set; }
    
    public decimal BlueEssence { get; set; }
    
    public decimal Chance { get; set; }
}