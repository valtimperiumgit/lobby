using Lobby.Data.EFCore;
using Lobby.Models.Dto.Icon;
using Lobby.Models.Entities.Icon;
using Lobby.Models.Enums;

namespace Lobby.Api.GraphQL;

public class Mutations
{
    public async Task<Icon> Icon([Service] MyDbContext context, IconDto icon)
    {
        var newIcon = new Icon
        {
            Name = icon.Name,
            Description = icon.Description,
            Id = Guid.NewGuid(),
            RarityId = (Int16)Rarity.Common,
            ImageUrl = icon.ImageUrl
        };
        var createdIcon = await context.Icons.AddAsync(newIcon);

        await context.SaveChangesAsync();
        
       return createdIcon.Entity;
    }
}