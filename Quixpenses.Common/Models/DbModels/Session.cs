using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json;
using Quixpenses.Common.Models.Commands;
using Quixpenses.Common.Models.Commands.Interfaces;
using Quixpenses.Common.Models.Interfaces;

namespace Quixpenses.Common.Models.DbModels;

[Table("users_sessions")]
public class Session : IDbModel
{
    private ICommand? command;

    private string? commandType;
    private string? commandJson;

    [Key]
    [Column("id")]
    public long Id { get; init; }

    [NotMapped]
    public ICommand? Command
    {
        get
        {
            if (command is not null)
            {
                return command;
            }

            if (string.IsNullOrWhiteSpace(commandJson))
            {
                return command;
            }

            command = commandType switch
            {
                nameof(NewInviteCommand) => JsonSerializer.Deserialize<NewInviteCommand>(commandJson),
                _ => throw new NotImplementedException()
            };

            return command;
        }
        set
        {
            command = value;
            commandType = command?.TypeName;
            commandJson = command is null ? null : JsonSerializer.Serialize(command, command.GetType());
        }
    }

    [Column("created_at")]
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    public int HashCode => GetHashCode();

    public override string ToString()
    {
        return CreatedAt.ToString(CultureInfo.InvariantCulture);
    }

    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }
}