using Quixpenses.App.TelegramUpdatesHandling.Handlers.Interfaces;
using Telegram.Bot.Types;

namespace Quixpenses.App.TelegramUpdatesHandling.Interfaces;

public interface IUpdateHandlerSelectionService
{
    IUpdateHandler? SelectHandler(Update update);
}