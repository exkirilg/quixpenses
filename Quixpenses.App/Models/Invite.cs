using Quixpenses.App.Models.Interfaces;

namespace Quixpenses.App.Models;

public record Invite : IDbModel
{
    public Guid Id { get; set; }

    public ushort Available { get; set; }

    public ushort Used { get; set; }

    public DateTime ExpiresAt { get; set; }
}