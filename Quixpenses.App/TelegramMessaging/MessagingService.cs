using Quixpenses.App.TelegramMessaging.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Quixpenses.App.TelegramMessaging;

public class MessagingService(ITelegramBotClient telegramBotClient) : IMessagingService
{
    public async Task<Message> SendTextMessageAsync(
        long chatId,
        string text,
        InlineKeyboardMarkup? replyMarkup = null)
    {
        return await telegramBotClient.SendTextMessageAsync(
            chatId,
            text,
            replyMarkup: replyMarkup);
    }

    public async Task EditMessageKeyboardAsync(long chatId, int messageId, InlineKeyboardMarkup replyMarkup)
    {
        await telegramBotClient.EditMessageReplyMarkupAsync(chatId, messageId, replyMarkup);
    }
}