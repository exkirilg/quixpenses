using Telegram.Bot.Types;

namespace Quixpenses.App.Services;

public interface ITelegramBotMessageHandler
{
    Task HandleUpdateAsync(Update update);
}