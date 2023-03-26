using Lobby.Models.Entities.Icon;

namespace Lobby.Models.Dto.User;

public class UserDto
{
    public UserDto(Entities.User.User user)
    {
        Id = user.Id;
        Alias = user.Alias;
        Email = user.Email;
        EmailVerificated = user.EmailVerificated;
    }

    public Guid Id { get; set; }
    
    public string Alias { get; set; }
    
    public string Email { get; set; }

    public bool EmailVerificated { get; set; }
    
    public Entities.Icon.Icon Icon { get; set; }
}