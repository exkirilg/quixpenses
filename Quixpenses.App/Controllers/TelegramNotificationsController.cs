using Microsoft.AspNetCore.Mvc;
using Quixpenses.App.Exceptions;
using Telegram.Bot.Types;
using Quixpenses.App.Services.MessagesHandling;

namespace Quixpenses.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TelegramNotificationsController(
        ILogger<TelegramNotificationsController> logger,
        IMessageHandlingService messageHandlingService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostUpdateAsync(
        [FromBody] Update update)
    {
        logger.LogInformation(
            "Received update from chat {chatId}: {message}",
            update.Message?.Chat.Id,
            update.Message?.Text);

        try
        {
            await messageHandlingService.HandleUpdateAsync(update);
        }
        catch (UnauthorizedException)
        {
            logger.LogWarning("Unauthorized {chatId}", update.Message?.Chat.Id);
        }
        catch (UnknownUpdateTypeException)
        {
            logger.LogWarning("Unable to parse update");
        }
        catch (Exception ex)
        {
            logger.LogError(
                "Exception thrown while handling update from chat {chatId} {message} {exception}",
                update.Message?.Chat.Id,
                update.Message?.Text,
                ex.Message);
        }

        return Ok();
    }
}