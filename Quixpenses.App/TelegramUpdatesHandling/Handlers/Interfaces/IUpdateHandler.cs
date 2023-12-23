using Quixpenses.Common.Models;
using Quixpenses.Common.Models.DbModels;

namespace Quixpenses.App.TelegramUpdatesHandling.Handlers.Interfaces;

public interface IUpdateHandler
{
    Task HandleAsync(User user, UpdateData update);
}