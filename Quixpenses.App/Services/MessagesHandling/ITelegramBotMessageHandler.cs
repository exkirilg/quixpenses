using Telegram.Bot.Types;

namespace Quixpenses.App.Services.MessagesHandling;

public interface ITelegramBotMessageHandler
{
    Task HandleUpdateAsync(Update update);
}