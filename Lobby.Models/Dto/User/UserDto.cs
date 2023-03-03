using Lobby.Models.Entities.Icon;

namespace Lobby.Models.Dto.User;

public class UserDto
{
    public Guid Id { get; set; }
    
    public string Alias { get; set; }
    
    public string Email { get; set; }

    public bool EmailVerificated { get; set; }
    
    public Icon Icon { get; set; }
}