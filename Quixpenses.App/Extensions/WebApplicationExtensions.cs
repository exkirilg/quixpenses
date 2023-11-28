using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Quixpenses.App.ConfigurationOptions;
using Quixpenses.App.Handlers.Auth;
using Quixpenses.App.Handlers.HandlerSelection;
using Quixpenses.App.Handlers.NewTransaction;
using Quixpenses.App.Handlers.UserSettings;
using Quixpenses.App.HostedServices;
using Quixpenses.App.Services.Invites;
using Quixpenses.App.Services.MessagesHandling;
using Quixpenses.App.Services.Transactions;
using Quixpenses.App.Services.Users;
using Quixpenses.DatabaseAccess;
using Quixpenses.DatabaseAccess.Repositories.Currencies;
using Quixpenses.DatabaseAccess.Repositories.Invites;
using Quixpenses.DatabaseAccess.Repositories.Transactions;
using Quixpenses.DatabaseAccess.Repositories.Users;
using Quixpenses.DatabaseAccess.Repositories.UsersSettings;
using Quixpenses.DatabaseAccess.UnitOfWork;

namespace Quixpenses.App.Extensions;

public static class WebApplicationExtensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IInvitesServices, InvitesServices>();
        builder.Services.AddScoped<IUsersServices, UsersServices>();
        builder.Services.AddScoped<IMessageHandlingService, MessageHandlingService>();
        builder.Services.AddScoped<ITransactionsService, TransactionsService>();

        builder.Services.Configure<TelegramBotOptions>(
            builder.Configuration.GetSection(TelegramBotOptions.BotConfigurationSection));

        builder.Services.AddHttpClient(TelegramBotOptions.BotClientName)
            .AddTypedClient<ITelegramBotClient>((httpClient, serviceProvider) =>
            {
                var telegramBotOptions = serviceProvider.GetService<IOptions<TelegramBotOptions>>()!.Value;
                var options = new TelegramBotClientOptions(telegramBotOptions.BotToken);
                return new TelegramBotClient(options, httpClient);
            });

        builder.Services.AddScoped<IHandlerSelector, HandlerSelector>();
        builder.Services.AddScoped<IAuthHandler, AuthHandler>();
        builder.Services.AddScoped<INewTransactionHandler, NewTransactionHandler>();
        builder.Services.AddScoped<ISettingsModificationHandler, SettingsModificationHandler>();
    }

    public static void ConfigureHostedServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHostedService<WebhooksConfigurationService>();
    }

    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<EfContext>(options =>
            options
                .UseNpgsql(builder.Configuration.GetConnectionString("Db"))
                .UseSnakeCaseNamingConvention());

        builder.Services.AddScoped<IInvitesRepository, InvitesRepository>();
        builder.Services.AddScoped<IUsersRepository, UsersRepository>();
        builder.Services.AddScoped<IUsersSettingsRepository, UsersSettingsRepository>();
        builder.Services.AddScoped<ICurrenciesRepository, CurrenciesRepository>();
        builder.Services.AddScoped<ITransactionsRepository, TransactionsRepository>();

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}