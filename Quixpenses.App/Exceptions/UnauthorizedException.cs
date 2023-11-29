using Quixpenses.DatabaseAccess.DatabaseModels;

namespace Quixpenses.App.Exceptions;

public class UnauthorizedException : Exception
{
    public static void ThrowIfUnauthorized(User? user)
    {
        if (user is null || !user.IsAuthorized)
        {
            throw new UnauthorizedException();
        }
    }
}