using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using Quixpenses.App.Services.MessagesHandling;

namespace Quixpenses.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TelegramNotificationsController : ControllerBase
{
    private readonly ILogger<TelegramNotificationsController> _logger;
    private readonly IMessageHandler _messageHandler;

    public TelegramNotificationsController(
        ILogger<TelegramNotificationsController> logger,
        IMessageHandler messageHandler)
    {
        _logger = logger;
        _messageHandler = messageHandler;
    }

    [HttpPost]
    public async Task<IActionResult> PostUpdateAsync(
        [FromBody] Update update,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Received update from chat {chatId}: {message}",
            update.Message?.Chat.Id,
            update.Message?.Text);

        try
        {
            await _messageHandler.HandleUpdateAsync(update);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                "Exception thrown while handling update from chat {chatId}: {message} - {exception}",
                update.Message?.Chat.Id,
                update.Message?.Text,
                ex.Message);
            return Problem();
        }

        return Ok();
    }
}