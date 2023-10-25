using Quixpenses.App.Models.Interfaces;

namespace Quixpenses.App.Models;

public record Transaction : IDbModel
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public long UserId { get; set; }

    public User? User { get; set; }

    public string CurrencyId { get; set; } = default!;

    public Currency? Currency { get; set; }

    public int Sum { get; set; }
}