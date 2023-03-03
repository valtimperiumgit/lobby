namespace Lobby.Models.Dto.User;

public class CreateUserDto
{
    public string Alias { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}