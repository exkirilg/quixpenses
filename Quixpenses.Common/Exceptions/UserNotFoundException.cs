using Quixpenses.Common.Models.DbModels;

namespace Quixpenses.Common.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException() : base()
    {
    }

    public UserNotFoundException(string message) : base(message)
    {
    }

    public UserNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }

    public static void ThrowIfNull(User? user)
    {
        if (user is null) throw new UserNotFoundException("User not found");
    }
}