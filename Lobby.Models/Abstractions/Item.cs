using Lobby.Models.Enums;

namespace Lobby.Models.Abstractions;

public class Item
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public Rarity Rarity { get; set; }
    
    public string ImageUrl { get; set; }
}