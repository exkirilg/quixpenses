using Quixpenses.App.TelegramMessaging;
using Quixpenses.App.TelegramMessaging.Interfaces;
using Quixpenses.App.TelegramUpdatesHandling;
using Quixpenses.App.TelegramUpdatesHandling.Handlers.NewExpense;
using Quixpenses.App.TelegramUpdatesHandling.Handlers.NewExpense.Interfaces;
using Quixpenses.App.TelegramUpdatesHandling.Handlers.NewInvite;
using Quixpenses.App.TelegramUpdatesHandling.Handlers.NewInvite.Interfaces;
using Quixpenses.App.TelegramUpdatesHandling.Handlers.Start;
using Quixpenses.App.TelegramUpdatesHandling.Handlers.Start.Interfaces;
using Quixpenses.App.TelegramUpdatesHandling.Interfaces;

namespace Quixpenses.App.DIConfiguration;

public static class UpdatesHandlingConfigurationExtensions
{
    public static IServiceCollection ConfigureUpdatesHandling(this IServiceCollection services)
    {
        services.AddScoped<IMessagingService, MessagingService>();

        services.AddScoped<IUpdatesHandlingService, UpdatesHandlingService>();
        services.AddScoped<IUpdateHandlerSelectionService, UpdatesHandlerSelectionService>();

        services.AddScoped<IStartCommandHandler, StartCommandHandler>();

        services.AddScoped<INewInviteCommandHandler, NewInviteCommandHandler>();
        services.AddScoped<INewInviteUpdateHandler, NewInviteUpdateHandler>();

        services.AddScoped<INewExpenseQuickHandler, NewExpenseQuickHandler>();

        return services;
    }
}