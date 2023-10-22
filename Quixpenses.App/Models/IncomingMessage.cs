using Telegram.Bot.Types;

namespace Quixpenses.App.Models;

public class IncomingMessage
{
    public long ChatId { get; private set; }

    public int MessageId { get; private set; }

    public string Text { get; private set; } = string.Empty;

    public static bool TryParse(Update source, out IncomingMessage result)
    {
        result = new IncomingMessage();

        if (source.Message is null)
        {
            return false;
        }

        result.ChatId = source.Message.Chat.Id;
        result.MessageId = source.Message.MessageId;
        result.Text = source.Message?.Text ?? string.Empty;

        return true;
    }
}