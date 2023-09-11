namespace Quixpenses.App.ConfigurationOptions;

public class TelegramBotOptions
{
    public const string BotConfigurationSection = "TelegramBotConfiguration";
    public const string BotClientName = "quixpenses.app_client";

    public string BotToken { get; init; } = default!;
    public string HostAddress { get; init; } = default!;
    public string Route { get; init; } = default!;
    public string SecretToken { get; init; } = default!;
}