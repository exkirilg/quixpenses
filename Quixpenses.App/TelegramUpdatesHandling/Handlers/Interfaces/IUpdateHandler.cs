using Telegram.Bot.Types;

namespace Quixpenses.App.TelegramUpdatesHandling.Handlers.Interfaces;

public interface IUpdateHandler
{
    Task HandleAsync(Update update);
}