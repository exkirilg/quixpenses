using Telegram.Bot.Types;

namespace Quixpenses.App.TelegramUpdatesHandling.Interfaces;

public interface IUpdatesHandlingService
{
    Task HandleAsync(Update update);
}