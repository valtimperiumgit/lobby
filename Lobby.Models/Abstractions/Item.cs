using Lobby.Models.Enums;

namespace Lobby.Models.Abstractions;

public class Item
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public Int16 RarityId { get; set; }
    
    public string ImageUrl { get; set; }
}