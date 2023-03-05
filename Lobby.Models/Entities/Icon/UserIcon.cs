namespace Lobby.Models.Entities.Icon;

public class UserIcon
{
    public UserIcon(Guid userId, Guid iconId)
    {
        UserId = userId;
        IconId = iconId;
    }

    public Guid UserId { get; set; }
    
    public Guid IconId { get; set; }
}