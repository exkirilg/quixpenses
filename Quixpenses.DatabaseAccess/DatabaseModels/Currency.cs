using Quixpenses.DatabaseAccess.DatabaseModels.Interfaces;

namespace Quixpenses.DatabaseAccess.DatabaseModels;

public record Currency : IDbModel
{
    public string Id { get; set; } = default!;

    public ushort FractionDigits { get; set; }
}