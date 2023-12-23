using System.Globalization;
using System.Text.RegularExpressions;
using Telegram.Bot.Types;

namespace Quixpenses.App.Extensions;

public static class UpdateExtensions
{
    private const string StartCommand = "/start";
    private const string NewInviteCommand = "/invite";
    private const string UpdateUserSettingsCommand = "/set";

    private const string NewInvitePattern = @"/invite(?:\s*(\d+))?(?:\s*(\d+))?";
    private const string UpdateUserSettingsPattern = @"^/set\s+(\w+)\s+(\w+)$";
    private const string TransactionPattern = @"^(\d+([.,]\d{1,2})?)?\s*([a-zA-Z]{3})?\s*([a-zA-Z]{0-50})?";

    public static string GetMessageTextSafe(this Update update)
    {
        return update.Message?.Text ?? string.Empty;
    }

    public static long GetChatIdSafe(this Update update)
    {
        return update.Message?.Chat.Id ?? default;
    }

    public static int GetMessageId(this Update update)
    {
        return update.Message!.MessageId;
    }

    public static bool IsStartCommand(this Update update)
    {
        return update.GetMessageTextSafe().StartsWith(StartCommand);
    }

    public static bool IsCreateInviteCommand(this Update update)
    {
        return update.GetMessageTextSafe().StartsWith(NewInviteCommand);
    }

    public static bool IsUpdateUserSettingsCommand(this Update update)
    {
        return update.GetMessageTextSafe().StartsWith(UpdateUserSettingsCommand);
    }

    public static bool IsCreateTransactionCommand(this Update update)
    {
        return Regex.IsMatch(update.GetMessageTextSafe(), TransactionPattern);
    }

    public static bool TryParseInviteId(this Update update, out Guid inviteId)
    {
        inviteId = Guid.Empty;

        var inviteIdString = update.GetMessageTextSafe().Replace($"{StartCommand} ", string.Empty);

        if (Guid.TryParse(inviteIdString, out inviteId))
        {
            return true;
        }

        return false;
    }

    public static (ushort numberOfUses, ushort availableForHours) ParseNewInviteSettings(this Update update)
    {
        var match = Regex.Match(update.GetMessageTextSafe(), NewInvitePattern);

        if (!match.Success)
        {
            throw new Exception("Unable to parse new invite settings");
        }

        const ushort defaultNumberOfUses = 1;
        if (!ushort.TryParse(match.Groups[1].Value, out var numberOfUses) || numberOfUses < 1)
        {
            numberOfUses = defaultNumberOfUses;
        }

        const ushort defaultAvailableForHours = 1;
        if (!ushort.TryParse(match.Groups[2].Value, out var availableForHours) || availableForHours < 1)
        {
            availableForHours = defaultAvailableForHours;
        }

        return (numberOfUses, availableForHours);
    }

    public static (string name, string value) ParseSettingsUpdateValues(this Update update)
    {
        var match = Regex.Match(update.GetMessageTextSafe(), UpdateUserSettingsPattern);

        if (!match.Success)
        {
            throw new Exception("Unable to parse settings update values");
        }

        var name = match.Groups[1].Value;
        var value = match.Groups[2].Value;

        return (name, value);
    }

    public static (float sum, string currencyCode, string categoryName) ParseTransaction(this Update update)
    {
        var match = Regex.Match(update.GetMessageTextSafe(), TransactionPattern);

        if (!match.Success)
        {
            throw new Exception("Unable to parse new transaction settings");
        }

        var sumPart = match.Groups[1].Value;
        var sum = float.Parse(sumPart.Replace(',', '.'), CultureInfo.InvariantCulture);

        var currencyCode = match.Groups[3].Value.Trim().ToUpper();

        var categoryName = match.Groups[4].Value.Trim();

        return (sum, currencyCode, categoryName);
    }
}