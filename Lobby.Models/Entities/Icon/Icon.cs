using Lobby.Models.Abstractions;

namespace Lobby.Models.Entities.Icon;

public class Icon : Item
{
    public Guid Id { get; set; }
    public Int16 RarityId { get; set; }
}