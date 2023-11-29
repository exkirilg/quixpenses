using Quixpenses.App.Exceptions;
using Quixpenses.App.Handlers;
using Quixpenses.App.Models;
using Quixpenses.DatabaseAccess.DatabaseModels;

namespace Quixpenses.App.Guards;

public static class Guard
{
    public static void AgainstUnknownUpdateType(IncomingMessage? message)
    {
        UnknownUpdateTypeException.ThrowIfNull(message);
    }

    public static void AgainstUnauthorizedUser(User? user)
    {
        UnauthorizedException.ThrowIfUnauthorized(user);
    }

    public static void AgainstNotImplementedHandler(IHandler? handler)
    {
        if (handler is null)
        {
            throw new NotImplementedException();
        }
    }

    public static void AgainstCurrencyNotFound(Currency? currency)
    {
        UnknownCurrencyCode.ThrowIfNull(currency);
    }
}