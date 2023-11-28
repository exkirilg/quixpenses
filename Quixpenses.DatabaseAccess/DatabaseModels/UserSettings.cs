using Quixpenses.DatabaseAccess.DatabaseModels.Interfaces;

namespace Quixpenses.DatabaseAccess.DatabaseModels;

public class UserSettings : IDbModel
{
    public Guid Id { get; set; }

    public string CurrencyId { get; set; } = default!;

    public Currency? Currency { get; set; }
}