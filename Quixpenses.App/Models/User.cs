using Quixpenses.App.Models.Interfaces;

namespace Quixpenses.App.Models;

public record User : IDbModel
{
    public long Id { get; set; }

    public bool IsAuthorized { get; set; }
}