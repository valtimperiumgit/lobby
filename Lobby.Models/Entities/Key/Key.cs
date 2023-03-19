using Lobby.Models.Abstractions;

namespace Lobby.Models.Entities.Key;

public class Key : Item
{
    public Guid Id { get; set; }

    public Guid ChestId { get; set; }
}