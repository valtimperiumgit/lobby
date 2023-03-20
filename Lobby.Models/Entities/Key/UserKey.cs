namespace Lobby.Models.Entities.Key;

public class UserKey
{
    public Guid UserId { get; set; }

    public Guid KeyId { get; set; }

    public DateTime ReceiveDate { get; set; }
    
    public bool Used { get; set; }
    
    public DateTime UseDate { get; set; }
}