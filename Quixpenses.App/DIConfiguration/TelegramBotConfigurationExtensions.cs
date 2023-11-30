using Microsoft.Extensions.Options;
using Quixpenses.Common.ConfigurationOptions;
using Telegram.Bot;

namespace Quixpenses.App.DIConfiguration;

public static class TelegramBotConfigurationExtensions
{
    public static WebApplicationBuilder ConfigureTelegramBotOptions(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<TelegramBotOptions>(
            builder.Configuration.GetSection(TelegramBotOptions.BotConfigurationSectionName));

        return builder;
    }

    public static IServiceCollection ConfigureTelegramBotHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient(TelegramBotOptions.BotClientName)
            .AddTypedClient<ITelegramBotClient>((httpClient, serviceProvider) =>
            {
                var telegramBotOptions = serviceProvider.GetService<IOptions<TelegramBotOptions>>()!.Value;
                var options = new TelegramBotClientOptions(telegramBotOptions.BotToken);
                return new TelegramBotClient(options, httpClient);
            });

        return services;
    }
}