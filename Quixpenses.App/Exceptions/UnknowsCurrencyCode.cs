using Quixpenses.DatabaseAccess.DatabaseModels;

namespace Quixpenses.App.Exceptions;

public class UnknownCurrencyCode : Exception
{
    public static void ThrowIfNull(Currency? currency)
    {
        if (currency is null)
        {
            throw new UnknownCurrencyCode();
        }
    }
}