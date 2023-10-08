using JetBrains.Annotations;

namespace Quixpenses.App.DatabaseAccess.DatabaseModels;

public record DbUser
{
    public long Id { get; set; }

    public bool IsAuthorized { get; set; }

    [UsedImplicitly]
    public DbUser()
    {
    }
}