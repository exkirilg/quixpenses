using Quixpenses.App.Extensions;
using Quixpenses.App.TelegramUpdatesHandling.Interfaces;
using Telegram.Bot.Types;

namespace Quixpenses.App.TelegramUpdatesHandling;

public class UpdatesHandlingService(
    ILogger<UpdatesHandlingService> logger,
    IUpdateHandlerSelectionService updateHandlerSelectionService)
    : IUpdatesHandlingService
{
    public async Task HandleAsync(Update update)
    {
        logger.LogInformation("Handling telegram update {chatId}, {message}",
            update.GetChatIdSafe(), update.GetMessageTextSafe());

        var handler = updateHandlerSelectionService.SelectHandler(update);
        if (handler is null)
        {
            logger.LogError("Unable to select telegram update handler: {message}",
                update.GetMessageTextSafe());
            return;
        }

        try
        {
            await handler.HandleAsync(update);
        }
        catch (Exception ex)
        {
            logger.LogError("Failed to handle telegram update {message} {exception}",
                update.GetMessageTextSafe(), ex.Message);
        }
    }
}