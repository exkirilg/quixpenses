using Quixpenses.App.Models;

namespace Quixpenses.App.Exceptions;

public class UnknownUpdateTypeException : Exception
{
    public static void ThrowIfNull(IncomingMessage? message)
    {
        if (message is null)
        {
            throw new UnknownUpdateTypeException();
        }
    }
}