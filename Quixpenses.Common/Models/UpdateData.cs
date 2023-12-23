using System.Reflection;
using Quixpenses.Common.Models.Commands;
using Quixpenses.Common.Models.Commands.Interfaces;
using Quixpenses.Common.Models.Dto;

namespace Quixpenses.Common.Models;

public record UpdateData(
    long ChatId,
    string? Text = null,
    PropertySetterCallbackDataDto? PropertySetterCallbackDataDto = null)
{
    public float Sum { get; set; }

    public bool TryParseCommand(out ICommand? command)
    {
        var commands = Assembly.GetExecutingAssembly().GetTypes()
            .Where(x => x.IsClass && x.Namespace == typeof(StartCommand).Namespace)
            .Select(x => Activator.CreateInstance(x)! as ICommand)
            .Where(x => x is not null)
            .ToArray();
        command = commands.FirstOrDefault(x => Text is not null && Text.StartsWith($"/{x!.Name}"));
        return command is not null;
    }

    public bool TryParseStartCommandInviteId(out Guid inviteId)
    {
        var startCommand = new StartCommand();

        inviteId = Guid.Empty;

        if (Text is null)
        {
            return false;
        }

        var inviteIdString = Text[$"/{startCommand.Name}".Length..].Trim();

        return Guid.TryParse(inviteIdString, out inviteId);
    }
}