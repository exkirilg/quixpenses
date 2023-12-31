﻿using Microsoft.Extensions.Options;
using Telegram.Bot;
using Quixpenses.App.ConfigurationOptions;
using Quixpenses.App.HostedServices;
using Quixpenses.App.Services;

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

        builder.Services.AddScoped<ITelegramBotMessageHandler, TelegramBotMessageHandler>();
    }

    public static void ConfigureHostedServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHostedService<WebhooksConfigurationService>();
    }
}