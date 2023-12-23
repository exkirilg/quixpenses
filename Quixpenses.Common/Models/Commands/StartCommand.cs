using Quixpenses.Common.Models.Commands.Abstract;

namespace Quixpenses.Common.Models.Commands;

public record StartCommand : Command
{
    public override string TypeName => nameof(StartCommand);

    public override string Name => "start";

    public override string Description => string.Empty;
}