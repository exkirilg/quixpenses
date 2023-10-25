using Microsoft.AspNetCore.Mvc;
using Quixpenses.App.Exceptions;
using Telegram.Bot.Types;
using Quixpenses.App.Services.MessagesHandling;

namespace Quixpenses.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TelegramNotificationsController : ControllerBase
{
    private readonly ILogger<TelegramNotificationsController> _logger;
    private readonly IMessageHandlingService _messageHandlingService;

    public TelegramNotificationsController(
        ILogger<TelegramNotificationsController> logger,
        IMessageHandlingService messageHandlingService)
    {
        _logger = logger;
        _messageHandlingService = messageHandlingService;
    }

    [HttpPost]
    public async Task<IActionResult> PostUpdateAsync(
        [FromBody] Update update)
    {
        _logger.LogInformation(
            "Received update from chat {chatId}: {message}",
            update.Message?.Chat.Id,
            update.Message?.Text);

        try
        {
            await _messageHandlingService.HandleUpdateAsync(update);
        }
        catch (UnauthorizedException ex)
        {
            _logger.LogWarning("Unauthorized {chatId}", ex.ChatId);
        }
        catch (UnknownUpdateTypeException)
        {
            _logger.LogWarning("Unable to parse update");
        }
        catch (Exception ex)
        {
            _logger.LogError(
                "Exception thrown while handling update from chat {chatId} {message} {exception}",
                update.Message?.Chat.Id,
                update.Message?.Text,
                ex.Message);
        }

        return Ok();
    }
}