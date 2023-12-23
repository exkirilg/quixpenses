using System.Text.Json.Serialization;
using Quixpenses.Common.Models.Commands.Abstract;

namespace Quixpenses.Common.Models.Commands;

public record NewInviteCommand : Command
{
    public static readonly ushort[] NumberOfUsesVariants = [1, 5, 10];
    public static readonly ushort[] HoursAvailableVariants = [1, 24, 168];

    [JsonIgnore]
    public override string TypeName => nameof(NewInviteCommand);

    [JsonIgnore]
    public override string Name => "newinvite";

    [JsonIgnore]
    public override string Description => "create new invite";

    [JsonIgnore]
    public override bool IsFilled => NumberOfUses is not null && HoursAvailable is not null;

    [JsonPropertyName("numberOfUses")]
    public ushort? NumberOfUses { get; set; }

    [JsonPropertyName("hoursAvailable")]
    public ushort? HoursAvailable { get; set; }
}