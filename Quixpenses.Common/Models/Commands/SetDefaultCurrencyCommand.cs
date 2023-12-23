using Quixpenses.Common.Models.Commands.Abstract;

namespace Quixpenses.Common.Models.Commands;

public record SetDefaultCurrencyCommand : Command
{
    public override string TypeName => nameof(SetDefaultCurrencyCommand);

    public override string Name => "setcurrency";

    public override string Description => "setup default currency";
}