using Lobby.Models.Entities.User;

namespace Lobby.Extensions.Interfaces;

public interface IJwtProvider
{
    string Generate(User user);
}