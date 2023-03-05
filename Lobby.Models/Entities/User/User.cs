using System.ComponentModel.DataAnnotations;

namespace Lobby.Models.Entities.User;

public class User
{
    public User(Guid id, string alias, string email, string password, DateTime created, DateTime lastLogin, bool emailVerificated, Guid iconId)
    {
        Id = id;
        Alias = alias;
        Email = email;
        Password = password;
        Created = created;
        LastLogin = lastLogin;
        EmailVerificated = emailVerificated;
        IconId = iconId;
    }

    public Guid Id { get; set; }
    
    [MaxLength(300)]
    public string Alias { get; set; }
    [MaxLength(300)]
    public string Email { get; set; }
    [MaxLength(600)]
    public string Password { get; set; }
    
    public DateTime Created { get; set; }
    
    public DateTime LastLogin { get; set; }
    
    public bool EmailVerificated { get; set; }
    
    public Guid IconId { get; set; }
}