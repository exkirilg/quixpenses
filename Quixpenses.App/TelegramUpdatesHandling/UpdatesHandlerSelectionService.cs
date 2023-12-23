using Quixpenses.App.TelegramUpdatesHandling.Handlers.Interfaces;
using Quixpenses.App.TelegramUpdatesHandling.Handlers.NewExpense.Interfaces;
using Quixpenses.App.TelegramUpdatesHandling.Handlers.NewInvite.Interfaces;
using Quixpenses.App.TelegramUpdatesHandling.Handlers.Start.Interfaces;
using Quixpenses.App.TelegramUpdatesHandling.Interfaces;
using Quixpenses.Common.Models;
using Quixpenses.Common.Models.Commands;
using Quixpenses.Common.Models.DbModels;

namespace Quixpenses.App.TelegramUpdatesHandling;

public class UpdatesHandlerSelectionService(
    IStartCommandHandler startCommandHandler,
    INewInviteCommandHandler newInviteCommandHandler,
    INewInviteUpdateHandler newInviteUpdateHandler,
    INewExpenseQuickHandler newExpenseQuickHandler)
    : IUpdateHandlerSelectionService
{
    public bool TrySelectHandler(User user, UpdateData update, out IUpdateHandler? result)
    {
        result = null;

        if (TrySelectQuickCommandHandler(user, update, out result))
        {
            return true;
        }

        if (TrySelectUpdateHandler(user, update, out result))
        {
            return true;
        }

        if (TrySelectCommandHandler(update, out result))
        {
            return true;
        }

        return false;
    }

    private bool TrySelectQuickCommandHandler(User user, UpdateData update, out IUpdateHandler? result)
    {
        result = null;

        if (user.CurrentSession is not null)
        {
            return false;
        }

        if (float.TryParse(update.Text, out var sum))
        {
            update.Sum = sum;
            result = newExpenseQuickHandler;
        }

        return result is not null;
    }

    private bool TrySelectCommandHandler(UpdateData update, out IUpdateHandler? result)
    {
        result = null;

        if (update.TryParseCommand(out var command) is false || command is null)
        {
            return false;
        }

        result = command switch
        {
            StartCommand => startCommandHandler,
            NewInviteCommand => newInviteCommandHandler,
            _ => null
        };

        return result is not null;
    }

    private bool TrySelectUpdateHandler(User user, UpdateData update, out IUpdateHandler? result)
    {
        result = null;

        if (user.CurrentSession?.Command is null)
        {
            return false;
        }

        if (update.PropertySetterCallbackDataDto?.SessionHashCode != user.CurrentSession?.HashCode)
        {
            return false;
        }

        result = user.CurrentSession!.Command switch
        {
            NewInviteCommand => newInviteUpdateHandler,
            _ => null
        };

        return result is not null;
    }
}