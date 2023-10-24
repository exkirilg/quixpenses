using Telegram.Bot.Types;

namespace Quixpenses.App.Services.MessagesHandling;

public interface IMessageHandler
{
    Task HandleUpdateAsync(Update update);
}