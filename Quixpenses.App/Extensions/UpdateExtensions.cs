using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using Quixpenses.App.TelegramMessaging;
using Quixpenses.App.TelegramUpdatesHandling;
using Quixpenses.Common.Models;
using Quixpenses.Common.Models.Dto;
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

    public static bool TryConvertToUpdateData(this Update update, out UpdateData? result)
    {
        result = null;

        if (update.TryParseUpdateMessage(out result))
        {
            return true;
        }

        if (update.TryParseUpdateCallbackQuery(out result))
        {
            return true;
        }

        return false;
    }

    private static bool TryParseUpdateMessage(this Update update, out UpdateData? result)
    {
        result = null;

        if (update.Message is null)
        {
            return false;
        }

        result = new UpdateData(
            ChatId: update.Message.Chat.Id,
            Text: update.Message.Text ?? string.Empty);

        return true;
    }

    private static bool TryParseUpdateCallbackQuery(this Update update, out UpdateData? result)
    {
        result = null;

        if (update.CallbackQuery?.Data is null)
        {
            return false;
        }

        var propertySetterData = PropertySetterCallbackDataDto.TryParseFromBase64(update.CallbackQuery.Data);
        if (propertySetterData is null)
        {
            return false;
        }

        result = new UpdateData(
            ChatId: update.CallbackQuery.From.Id,
            PropertySetterCallbackDataDto: propertySetterData);

        return true;
    }

    public static int GetMessageId(this Update update)
    {
        return update.Message!.MessageId;
    }

    public static (ushort numberOfUses, ushort availableForHours) ParseNewInviteSettings(this Update update)
    {
        throw new NotImplementedException();
        // var match = Regex.Match(update.GetMessageText(), NewInvitePattern);
        //
        // if (!match.Success)
        // {
        //     throw new Exception("Unable to parse new invite settings");
        // }
        //
        // const ushort defaultNumberOfUses = 1;
        // if (!ushort.TryParse(match.Groups[1].Value, out var numberOfUses) || numberOfUses < 1)
        // {
        //     numberOfUses = defaultNumberOfUses;
        // }
        //
        // const ushort defaultAvailableForHours = 1;
        // if (!ushort.TryParse(match.Groups[2].Value, out var availableForHours) || availableForHours < 1)
        // {
        //     availableForHours = defaultAvailableForHours;
        // }
        //
        // return (numberOfUses, availableForHours);
    }

    public static (string name, string value) ParseSettingsUpdateValues(this Update update)
    {
        throw new NotImplementedException();
        // var match = Regex.Match(update.GetMessageText(), UpdateUserSettingsPattern);
        //
        // if (!match.Success)
        // {
        //     throw new Exception("Unable to parse settings update values");
        // }
        //
        // var name = match.Groups[1].Value;
        // var value = match.Groups[2].Value;
        //
        // return (name, value);
    }

    public static (float sum, string currencyCode, string categoryName) ParseTransaction(this Update update)
    {
        throw new NotImplementedException();
        // var match = Regex.Match(update.GetMessageText(), TransactionPattern);
        //
        // if (!match.Success)
        // {
        //     throw new Exception("Unable to parse new transaction settings");
        // }
        //
        // var sumPart = match.Groups[1].Value;
        // var sum = float.Parse(sumPart.Replace(',', '.'), CultureInfo.InvariantCulture);
        //
        // var currencyCode = match.Groups[3].Value.Trim().ToUpper();
        //
        // var categoryName = match.Groups[4].Value.Trim();
        //
        // return (sum, currencyCode, categoryName);
    }
}