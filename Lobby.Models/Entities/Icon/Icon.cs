namespace Lobby.Models.Entities.Icon;

public class Icon
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string ImageUrl { get; set; }
    
    public Int16 RarityId { get; set; }
}