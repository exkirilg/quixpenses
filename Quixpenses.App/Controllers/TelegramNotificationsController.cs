using Microsoft.AspNetCore.Mvc;
using Quixpenses.App.TelegramUpdatesHandling.Interfaces;
using Telegram.Bot.Types;

namespace Quixpenses.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TelegramNotificationsController(IUpdatesHandlingService updatesHandlingService) : ControllerBase
{
    [HttpPost]
    public async Task PostUpdateAsync([FromBody] Update update)
    {
        await updatesHandlingService.HandleAsync(update);
    }
}