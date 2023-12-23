using System.Text.Json.Serialization;
using Quixpenses.Common.Models.Commands.Abstract;
using Quixpenses.Common.Models.DbModels;

namespace Quixpenses.Common.Models.Commands;

public record NewExpenseCommand : Command
{
    [JsonIgnore]
    public override string TypeName => nameof(NewExpenseCommand);

    [JsonIgnore]
    public override string Name => "newexpense";

    [JsonIgnore]
    public override string Description => "create new expense";

    [JsonPropertyName("sum")]
    public float? Sum { get; set; }

    [JsonPropertyName("currency")]
    public Currency? Currency { get; set; }
}