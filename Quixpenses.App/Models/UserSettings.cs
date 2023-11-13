using Quixpenses.App.Models.Interfaces;

namespace Quixpenses.App.Models;

public class UserSettings : IDbModel
{
    private const string DefaultCurrency = "USD";

    public Guid Id { get; set; }

    public string CurrencyId { get; set; } = DefaultCurrency;

    public Currency? Currency { get; set; }
}