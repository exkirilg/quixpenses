namespace Quixpenses.App.Exceptions;

public class UnknownCurrencyCode : Exception
{
    public string CurrencyCode { get; }

    public UnknownCurrencyCode(string currencyCode)
    {
        CurrencyCode = currencyCode;
    }
}