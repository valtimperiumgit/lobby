using Lobby.Data.EFCore;
using Lobby.Models.Entities.Icon;

namespace Lobby.Api.GraphQL;

public class Queries
{
    public IQueryable<Icon> Icons([Service] MyDbContext context)
    {
        return context.Icons;
    }
}