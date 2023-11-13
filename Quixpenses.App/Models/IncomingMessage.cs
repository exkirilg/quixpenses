using System.Globalization;
using System.Text.RegularExpressions;
using Telegram.Bot.Types;

namespace Quixpenses.App.Models;

public class IncomingMessage
{
    private const string StartCommand = "/start";
    private const string SetCommand = "/set";

    private const string TransactionPattern = @"^(\d+([.,]\d{1,2})?)?\s*([a-zA-Z]{3})?$";
    private const string SettingsModificationPattern = @"^/set\s+(\w+)\s+(\w+)$";

    public long ChatId { get; private set; }

    public int MessageId { get; private set; }

    public string Text { get; private set; } = string.Empty;

    public static IncomingMessage? TryParse(Update source)
    {
        if (source.Message is null)
        {
            return null;
        }

        return new IncomingMessage
        {
            ChatId = source.Message.Chat.Id,
            MessageId = source.Message.MessageId,
            Text = source.Message?.Text ?? string.Empty,
        };
    }

    public bool IsStartCommand()
    {
        return Text.StartsWith(StartCommand);
    }

    public bool IsNewTransactionCommand()
    {
        return Regex.IsMatch(Text, TransactionPattern);
    }

    public bool IsSetCommand()
    {
        return Text.StartsWith(SetCommand);
    }

    public (float sum, string currencyCode) ParseTransaction()
    {
        var match = Regex.Match(Text, TransactionPattern);

        if (!match.Success)
        {
            throw new NotImplementedException();
        }

        var sumPart = match.Groups[1].Value;
        var sum = float.Parse(sumPart.Replace(',', '.'), CultureInfo.InvariantCulture);

        var currency = match.Groups[3].Value.Trim().ToUpper();

        return (sum, currency);
    }

    public (string name, string value) ParseSettingsModification()
    {
        var match = Regex.Match(Text, SettingsModificationPattern);

        if (!match.Success)
        {
            throw new NotImplementedException();
        }

        var name = match.Groups[1].Value;
        var value = match.Groups[2].Value;

        return (name, value);
    }
}