using Lobby.Logic.Interfaces;
using Lobby.Models.Entities.Icon;
using Lobby.Models.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Lobby.Api.Controllers;

[Route("api/icons/")]
public class IconsController : ControllerBase
{
    private readonly IIconService _iconService;
    private readonly IDistributedCache _distributedCache;
    
    public IconsController(IIconService iconService, IDistributedCache distributedCache)
    {
        _iconService = iconService;
        _distributedCache = distributedCache;
    }

    [HttpGet]
    public async Task<IActionResult> GetIcons([FromQuery] Rarity rarity)
    {
        string key = $"icons-rarity-{rarity}";

        string? cashedIcons = await _distributedCache.GetStringAsync(key);

        List<Icon>? icons;
        
        if (string.IsNullOrEmpty(cashedIcons))
        {
            icons = await _iconService.GetIconsByRarity(Rarity.Common);

            if (icons is null)
                return NoContent();

            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));
            
            await _distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(icons), options);

            return Ok(icons);
        }

        icons = JsonConvert.DeserializeObject<List<Icon>>(cashedIcons);
        
        return Ok(icons);
    }
    
}