using Quixpenses.App.TelegramUpdatesHandling;
using Quixpenses.App.TelegramUpdatesHandling.Handlers;
using Quixpenses.App.TelegramUpdatesHandling.Handlers.Interfaces;
using Quixpenses.App.TelegramUpdatesHandling.Interfaces;

namespace Quixpenses.App.DIConfiguration;

public static class UpdatesHandlingConfigurationExtensions
{
    public static IServiceCollection ConfigureUpdatesHandling(this IServiceCollection services)
    {
        services.AddScoped<IUpdatesHandlingService, UpdatesHandlingService>();
        services.AddScoped<IUpdateHandlerSelectionService, UpdatesHandlerSelectionService>();
        services.AddScoped<IUserAuthHandler, UserAuthHandler>();
        services.AddScoped<ICreateInviteHandler, CreateInviteHandler>();
        services.AddScoped<IUpdateUserSettingsHandler, UpdateUserSettingsHandler>();
        services.AddScoped<ICreateTransactionHandler, CreateTransactionHandler>();

        return services;
    }
}