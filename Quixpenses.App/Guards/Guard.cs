using Quixpenses.App.Exceptions;
using Quixpenses.App.Handlers;
using Quixpenses.App.Models;

namespace Quixpenses.App.Guards;

public static class Guard
{
    public static void AgainstUnknownUpdateType(IncomingMessage? message)
    {
        if (message is null)
        {
            throw new UnknownUpdateTypeException();
        }
    }

    public static void AgainstUnauthorizedUser(User? user)
    {
        if (user is null || !user.IsAuthorized)
        {
            throw new UnauthorizedException();
        }
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
        if (currency is null)
        {
            throw new UnknownCurrencyCode();
        }
    }
}