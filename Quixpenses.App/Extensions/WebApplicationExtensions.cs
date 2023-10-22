using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Quixpenses.App.ConfigurationOptions;
using Quixpenses.App.DatabaseAccess;
using Quixpenses.App.DatabaseAccess.Repositories.Invites;
using Quixpenses.App.DatabaseAccess.Repositories.Users;
using Quixpenses.App.HostedServices;
using Quixpenses.App.Services.Invites;
using Quixpenses.App.Services.MessagesHandling;
using Quixpenses.App.Services.Users;

namespace Quixpenses.App.Extensions;

public static class WebApplicationExtensions
{
    public static void ConfigureTelegramBotServices(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<TelegramBotOptions>(
            builder.Configuration.GetSection(TelegramBotOptions.BotConfigurationSection));

        builder.Services.AddHttpClient(TelegramBotOptions.BotClientName)
            .AddTypedClient<ITelegramBotClient>((httpClient, serviceProvider) =>
            {
                var telegramBotOptions = serviceProvider.GetService<IOptions<TelegramBotOptions>>()!.Value;
                var options = new TelegramBotClientOptions(telegramBotOptions.BotToken);
                return new TelegramBotClient(options, httpClient);
            });

        builder.Services.AddScoped<IInvitesServices, InvitesServices>();
        builder.Services.AddScoped<IUsersServices, UsersServices>();

        builder.Services.AddScoped<ITelegramBotMessageHandler, TelegramBotMessageHandler>();
    }

    public static void ConfigureHostedServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHostedService<WebhooksConfigurationService>();
    }

    public static void ConfigureDataAccessServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<EfContext>(options =>
            options
                .UseNpgsql(builder.Configuration.GetConnectionString("Db"))
                .UseSnakeCaseNamingConvention());

        builder.Services.AddScoped<IInvitesRepository, InvitesRepository>();
        builder.Services.AddScoped<IUsersRepository, UsersRepository>();
    }
}