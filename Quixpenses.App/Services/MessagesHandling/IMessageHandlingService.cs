using Telegram.Bot.Types;

namespace Quixpenses.App.Services.MessagesHandling;

public interface IMessageHandlingService
{
    Task HandleUpdateAsync(Update update);
}