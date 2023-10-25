using Quixpenses.App.Models.Interfaces;

namespace Quixpenses.App.Models;

public record Currency : IDbModel
{
    public string Id { get; set; } = default!;

    public ushort FractionDigits { get; set; }
}