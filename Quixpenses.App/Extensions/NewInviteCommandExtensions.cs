using Quixpenses.App.TelegramMessaging;
using Quixpenses.Common.Models.Commands;
using Quixpenses.Common.Models.DbModels;
using Quixpenses.Common.Models.Dto;
using Telegram.Bot.Types.ReplyMarkups;

namespace Quixpenses.App.Extensions;

public static class NewInviteCommandExtensions
{
    public static InlineKeyboardMarkup GetCommandSettingsKeyboard(this NewInviteCommand command, Session session)
    {
        var numberOfUsesRow = GetNumberOfUsesRow(command, session);
        var hoursAvailableRow = GetHoursAvailableRow(command, session);

        var result = new InlineKeyboardMarkup(new[]
        {
            numberOfUsesRow,
            hoursAvailableRow
        });

        return result;
    }

    private static InlineKeyboardButton[] GetNumberOfUsesRow(this NewInviteCommand command, Session session)
    {
        const string templateFirstRow = "{0}for {1} use";
        const string templateRow = "{0}... {1}";

        return GetDataRow(
            templateRow,
            templateFirstRow,
            NewInviteCommand.NumberOfUsesVariants.Select(x => x.ToString()).ToArray(),
            command.NumberOfUses.HasValue ? command.NumberOfUses.Value.ToString() : string.Empty,
            session.HashCode,
            nameof(command.NumberOfUses));
    }

    private static InlineKeyboardButton[] GetHoursAvailableRow(this NewInviteCommand command, Session session)
    {
        const string templateFirstRow = "{0}for {1} hour";
        const string templateRow = "{0}... {1}";

        return GetDataRow(
            templateRow,
            templateFirstRow,
            NewInviteCommand.HoursAvailableVariants.Select(x => x.ToString()).ToArray(),
            command.HoursAvailable.HasValue ? command.HoursAvailable.Value.ToString() : string.Empty,
            session.HashCode,
            nameof(command.HoursAvailable));
    }

    private static InlineKeyboardButton[] GetDataRow(
        string templateRow,
        string templateFirstRow,
        string[] variants,
        string currentValue,
        int sessionHashCode,
        string propertyName)
    {
        var result = new InlineKeyboardButton[variants.Length];

        for (var i = 0; i < variants.Length; i++)
        {
            var value = variants[i];

            var dataDto = new PropertySetterCallbackDataDto(sessionHashCode, propertyName, value);
            var callbackData = dataDto.ToBase64();

            var mark = value == currentValue
                ? MessagingConstants.SelectedSettingMark
                : string.Empty;

            if (i == 0)
            {
                result[i] = InlineKeyboardButton.WithCallbackData(
                    string.Format(templateFirstRow, mark, value), callbackData);
            }
            else
            {
                result[i] = InlineKeyboardButton.WithCallbackData(
                    string.Format(templateRow, mark, value), callbackData);
            }
        }

        return result;
    }
}