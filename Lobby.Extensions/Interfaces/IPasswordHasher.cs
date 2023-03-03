namespace Lobby.Extensions.Interfaces;

public interface IPasswordHasher
{
    string Hash(string password);
}