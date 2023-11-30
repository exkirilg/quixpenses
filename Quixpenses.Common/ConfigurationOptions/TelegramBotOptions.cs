namespace Quixpenses.Common.ConfigurationOptions;

public class TelegramBotOptions
{
    public const string BotConfigurationSectionName = "TelegramBotConfiguration";
    public const string BotClientName = "quixpenses.app_client";

    public string BotToken { get; init; } = default!;
    public string HostAddress { get; init; } = default!;
    public string Route { get; init; } = default!;
    public string SecretToken { get; init; } = default!;
    public string Link { get; init; } = default!;
}