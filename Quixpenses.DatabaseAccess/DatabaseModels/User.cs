using Quixpenses.DatabaseAccess.DatabaseModels.Interfaces;

namespace Quixpenses.DatabaseAccess.DatabaseModels;

public record User : IDbModel
{
    public long Id { get; set; }

    public bool IsAuthorized { get; set; }

    public Guid UserSettingsId { get; set; }

    public UserSettings? UserSettings { get; set; }
}