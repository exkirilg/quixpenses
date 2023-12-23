using Quixpenses.App.Extensions;
using Quixpenses.App.TelegramUpdatesHandling.Interfaces;
using Quixpenses.Common.Models;
using Quixpenses.Services.Users.Interfaces;
using Telegram.Bot.Types;
using User = Quixpenses.Common.Models.DbModels.User;

namespace Quixpenses.App.TelegramUpdatesHandling;

public class UpdatesHandlingService(
    ILogger<UpdatesHandlingService> logger,
    IUserAuthenticationService authenticationService,
    IUserCreationService userCreationService,
    IUpdateHandlerSelectionService updateHandlerSelectionService)
    : IUpdatesHandlingService
{
    public async Task HandleAsync(Update update)
    {
        if (update.TryConvertToUpdateData(out var updateData) is false || updateData is null)
        {
            logger.LogError("Unable to parse telegram update");
            return;
        }

        var user = await EnsureAuthenticatedUserAsync(updateData);

        if (updateHandlerSelectionService.TrySelectHandler(user, updateData, out var handler) is false)
        {
            return;
        }

        try
        {
            await handler!.HandleAsync(user, updateData);
        }
        catch (Exception ex)
        {
            logger.LogError("Failed to handle telegram update {command} {exception}", updateData.Text, ex.Message);
        }
    }

    private async Task<User> EnsureAuthenticatedUserAsync(UpdateData update)
    {
        var result = await authenticationService.TryAuthenticateAsync(update.ChatId);
        result ??= await userCreationService.CreateUserAsync(update.ChatId);
        return result;
    }
}