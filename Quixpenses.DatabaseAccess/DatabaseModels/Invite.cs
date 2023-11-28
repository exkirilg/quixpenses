using Quixpenses.DatabaseAccess.DatabaseModels.Interfaces;

namespace Quixpenses.DatabaseAccess.DatabaseModels;

public record Invite : IDbModel
{
    public Guid Id { get; set; }

    public ushort Available { get; set; }

    public ushort Used { get; set; }

    public DateTime ExpiresAt { get; set; }
}