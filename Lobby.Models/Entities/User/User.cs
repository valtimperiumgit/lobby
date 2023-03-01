namespace Lobby.Models.Entities.User;

public class User
{
    public Guid Id { get; set; }
    
    public string Alias { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public DateTime Created { get; set; }
    
    public DateTime LastLogin { get; set; }
    
    public bool EmailVerificated { get; set; }
    
    public string Icon { get; set; }
}