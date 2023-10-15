namespace Quixpenses.App.DatabaseAccess.DatabaseModels;

public record DbInvite : IDbModel
{
    public Guid Id { get; set; }

    public ushort Available { get; set; }

    public ushort Used { get; set; }

    public DateTime ExpiresAt { get; set; }
}