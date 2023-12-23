using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Quixpenses.App.TelegramMessaging.Interfaces;

public interface IMessagingService
{
    Task<Message> SendTextMessageAsync(
        long chatId,
        string text,
        InlineKeyboardMarkup? replyMarkup = null);

    Task EditMessageKeyboardAsync(
        long chatId,
        int messageId,
        InlineKeyboardMarkup replyMarkup);
}