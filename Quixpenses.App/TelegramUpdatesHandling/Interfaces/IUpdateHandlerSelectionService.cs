using Quixpenses.App.TelegramUpdatesHandling.Handlers.Interfaces;
using Quixpenses.Common.Models;
using Quixpenses.Common.Models.DbModels;

namespace Quixpenses.App.TelegramUpdatesHandling.Interfaces;

public interface IUpdateHandlerSelectionService
{
    bool TrySelectHandler(User user, UpdateData update, out IUpdateHandler? result);
}