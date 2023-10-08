using JetBrains.Annotations;

namespace Quixpenses.App.DatabaseAccess.DatabaseModels;

public record DbTransaction
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public long UserId { get; set; }

    public DbUser? User { get; set; }

    public string CurrencyId { get; set; } = default!;

    public DbCurrency? Currency { get; set; }

    public float Sum { get; set; }

    [UsedImplicitly]
    public DbTransaction()
    {
    }
}